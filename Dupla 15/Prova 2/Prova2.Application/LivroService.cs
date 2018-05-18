using Prova2.Domain;
using Prova2.Infra.Data;
using Prova2.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Applications
{
    public class LivroService
    {
        public LivroDAO livroDAO = new LivroDAO();
        public TestPDF _pdfCreator;

        public LivroService()
        {

        }
        
        public Livro AddLivro(Livro livro)
        {
    
            try
            {
                livro.Validate(); 

                livro = livroDAO.Add(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return livro;
        }

        public Livro UpdateLivro(Livro livro)
        {
            try
            {
                livro.Validate(); 

                livroDAO.Update(livro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return livro;
        }

        public Livro GetLivro(int IdLivro)
        {
            try
            {
                return livroDAO.GetById(IdLivro);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public IQueryable<Livro> GetAll()
        public IList<Livro> GetAll()
        {
            try
            {
                return livroDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }

        public void DeleteLivro(Livro livro)
        {
            try
            {
                livroDAO.Delete(livro.Id);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ReportList(string fileName)
        {
            try
            {

                IList<Livro> livroList = livroDAO.GetAll();

                _pdfCreator = new TestPDF(fileName);

                _pdfCreator.AbrirDocumento();

                _pdfCreator.Escrever("Lista de Livros:");

                foreach (var item in livroList)
                {
                    _pdfCreator.Escrever(item.ToString());
                }

                _pdfCreator.FecharDocumento();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }

}
