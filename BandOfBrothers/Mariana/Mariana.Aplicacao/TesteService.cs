using Mariana.Dominio;
using Mariana.Dominio.Exceptions;
using Mariana.Dominio.Exceptions.Disciplina;
using Mariana.Dominio.Interfaces;
using Mariana.Infra;
using Mariana.Infra.Data.Nucleo;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Mariana.Aplicacao
{
    public class TesteService : Servico<Teste>
    {
        private PDF _testePDF = new PDF();
        private QuestaoService _questaoService;

        public TesteService(QuestaoService questaoService) : base(RepositorioIoC.Teste)
        {
            _questaoService = questaoService;
        }

        private IQuestaoRepositorio questaoRepositorio = RepositorioIoC.Questao;
        private IRespostaRepositorio respostaRepositorio = RepositorioIoC.Resposta;

        public IList<Questao> BuscarQuestoes(Teste teste)
        {
            try
            {
                return questaoRepositorio.ObterQuestoesTeste(teste);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<Resposta> BuscarRespostas(Questao questao)
        {
            try
            {
                return respostaRepositorio.ObterRespostas(questao.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Teste Adicionar(Teste teste)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                teste.Validar();

                IList<Questao> questoesFiltradas = ListaFiltradaDesordenada(teste);

                if (questoesFiltradas.Count >= teste.NumeroQuestoes)
                {
                    //se a quantidade de questões filtradas for maior ou igual a número de questões inseridas, adicione teste, questões de testes e gere pdf
                    teste = Repositorio.Adicionar(teste);
                    teste.Questoes = questoesFiltradas;

                    foreach (var questao in questoesFiltradas)
                        testeRepositorio.AdicionarQuestoes(questao, teste);

                    if (!CriarPDFTeste(teste))
                        throw new Exception("Não foi possível criar o PDF no caminho especificado. Verifique se o arquivo está sendo utilizado ou não existe");
                }
                else
                {
                    throw new Exception("Quantidade de questões superior ao número de questões cadastradas para este Teste");
                }

                return teste;
            }
            catch (DuplicadaException e)
            {
                throw new DuplicadaException(e.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override IList<Teste> Pesquisar(string pesquisa)
        {
            ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;

            try
            {
                return testeRepositorio.PesquisarTeste(pesquisa);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override Teste Atualizar(Teste teste)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                teste.Validar();

                IList<Questao> questoesFiltradas = ListaFiltradaDesordenada(teste);

                testeRepositorio.ExcluirQuestoes(teste.Id);

                if (questoesFiltradas.Count >= teste.NumeroQuestoes)
                {
                    //se a quantidade de questões filtradas for maior ou igual a número de questões inseridas, adicione teste, questões de testes e gere pdf
                    teste = Repositorio.Atualizar(teste);
                    teste.Questoes = questoesFiltradas;

                    foreach (var questao in questoesFiltradas)
                        testeRepositorio.AdicionarQuestoes(questao, teste);

                    if (!CriarPDFTeste(teste))
                        throw new Exception("Não foi possível criar o PDF no caminho especificado. Verifique se o arquivo está sendo utilizado ou não existe");
                }
                else
                {
                    throw new Exception("Quantidade de questões superior ao número de questões cadastradas para este Teste");
                }

                return teste;
            }
            catch (DuplicadaException e)
            {
                throw new DuplicadaException(e.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IList<Teste> CarregarPorNome(string nome)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                return testeRepositorio.ConsultarPorNome(nome);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ValidarExistenciaNome(string nome, int id)
        {
            try
            {
                ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;
                IList<Teste> questoes = testeRepositorio.ConsultarPorNomeEId(nome, id);
                if (questoes.Count > 0)
                {
                    throw new ValidacaoException("Esta resposta já foi cadastrada.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override int Excluir(Teste entidade)
        {
            try
            {
                return base.Excluir(entidade);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool CriarPDFTeste(Teste teste)
        {
            int i = 0, j = 0;

            string listaQuestoes = "", listaRespostas = "", listaGabaritos = "";

            try
            {
                IList<string> listaEnunciado = new List<string>();
                IList<string> listaResp = new List<string>();
                IList<string> listaGabarito = new List<string>();

                foreach (var itemQuestao in teste.Questoes)
                {
                    IList<Resposta> listaResposta = _questaoService.BuscarTodasRespostas(itemQuestao.Id);

                    listaQuestoes += itemQuestao.Enunciado + "\n";

                    listaEnunciado.Add(listaQuestoes);
                    listaQuestoes = "";

                    j++;

                    foreach (var itemResposta in listaResposta)
                    {
                        i++;

                        switch (i)
                        {
                            case 1:
                                {
                                    listaRespostas += "A) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (A) \n";
                                    break;
                                }
                            case 2:
                                {
                                    listaRespostas += "B) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (B) \n";
                                    break;
                                }
                            case 3:
                                {
                                    listaRespostas += "C) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (C) \n";
                                    break;
                                }
                            case 4:
                                {
                                    listaRespostas += "D) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (D) \n";
                                    break;
                                }
                            case 5:
                                {
                                    listaRespostas += "E) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (E) \n";
                                    break;
                                }
                            case 6:
                                {
                                    listaRespostas += "F) " + itemResposta.CorpoResposta + "\n";
                                    if (itemResposta.Correta == true)
                                        listaGabaritos += j + " - (F) \n";
                                    break;
                                }
                        }
                    }

                    listaGabarito.Add(listaGabaritos);
                    listaResp.Add(listaRespostas);
                    listaRespostas = "";
                    listaGabaritos = "";

                    i = 0;
                }

                if (!EnviarPDF(teste, listaEnunciado, listaResp, listaGabarito))
                    return false;

                return true;
            }
            catch (NullReferenceException)
            {
                throw;
            }
        }

        public bool EnviarPDF(Teste teste, IList<string> listaEnunciado, IList<string> listaResposta, IList<string> listaGabarito)
        {
            if (teste.CaminhoDestino != "")
            {
                try
                {
                    _testePDF.GeneratePdf(teste, listaEnunciado, listaResposta, listaGabarito);

                    System.Diagnostics.Process.Start(teste.CaminhoDestino);

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override void GerarArquivo(Teste teste, string caminho, int tipo)
        {
            ITesteRepositorio testeRepositorio = base.Repositorio as ITesteRepositorio;

            XML xml = new XML();
            CSV csv = new CSV();

            if (teste == null)
            {
                IList<Teste> ListaTeste = new List<Teste>();
                ListaTeste = testeRepositorio.BuscarTodos();

                foreach (var item in ListaTeste)
                {
                    item.Questoes = BuscarQuestoes(item);
                    foreach (var itemQuestao in item.Questoes)
                        itemQuestao.Respostas = BuscarRespostas(itemQuestao);
                }

                if (tipo == 2)
                    csv.GeraCSV(caminho, ListaTeste);
                else if (tipo == 3)
                    xml.GeraXml(caminho, ListaTeste);
            }
            else
            {
                teste.Questoes = BuscarQuestoes(teste);
                foreach (var itemQuestao in teste.Questoes)
                    itemQuestao.Respostas = BuscarRespostas(itemQuestao);

                if (tipo == 2)
                    csv.GeraCSVPorItem(teste, caminho);
                else if (tipo == 3)
                    xml.GeraItemXML(caminho, teste);
                else
                    if (!CriarPDFTeste(teste))
                    throw new Exception("Não foi possível criar o PDF no caminho especificado. Verifique se o arquivo está sendo utilizado ou não existe");
            }

        }

        public IList<Questao> ListaFiltradaDesordenada(Teste teste)
        {
            IList<Questao> questoes = _questaoService.BuscarTodos();
            IList<Questao> questoesFIltradas = new List<Questao>();

            if (questoes.Count >= teste.NumeroQuestoes)
            {
                for (int i = 0; i < questoes.Count; i++)
                {
                    if (questoes[i].Disciplina.Id == teste.Disciplina.Id
                        && questoes[i].Materia.Serie.Id == teste.Serie.Id
                        && questoes[i].Materia.Id == teste.Materia.Id)
                    {
                        questoesFIltradas.Add(questoes[i]);
                    }
                }
            }
            else
            {
                throw new Exception("Quantidade de questões superior ao número de questões cadastradas para este Teste");
            }

            return DesordenarLista(questoesFIltradas);
        }

        public static IList<T> DesordenarLista<T>(IList<T> input)
        {
            IList<T> arr = input;
            IList<T> arrDes = new List<T>();

            Random randNum = new Random();
            while (arr.Count > 0)
            {
                int val = randNum.Next(0, arr.Count - 1);
                arrDes.Add(arr[val]);
                arr.RemoveAt(val);
            }
            return arrDes;
        }
    }
}
