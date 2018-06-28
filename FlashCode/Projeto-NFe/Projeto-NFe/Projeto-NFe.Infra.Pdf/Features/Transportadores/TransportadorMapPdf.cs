using DanfeSharp.Modelo;
using Projeto_NFe.Dominio.Features.Transportadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_NFe.Infra.Pdf.Features.Transportadores
{
    public static class TransportadorMapPdf
    {
        public static TransportadoraViewModel MapParaTransportadoraViewModel(Transportador transportador)
        {
            return new TransportadoraViewModel()
            {
                CnpjCpf = transportador.Cpf != null ? transportador.Cpf.ToString() : transportador.Cnpj.ToString(),
                Email = String.Empty,
                EnderecoBairro = transportador.Endereco.Bairro,
                EnderecoCep = transportador.Endereco.Cep,
                EnderecoLogadrouro = transportador.Endereco.Rua,
                EnderecoNumero = transportador.Endereco.Numero.ToString(),
                EnderecoUf = transportador.Endereco.UF,
                Municipio = transportador.Endereco.Cidade,
                CodigoAntt = String.Empty,
                EnderecoComplemento = String.Empty,
                Especie = String.Empty,
                Ie = (transportador.Cpf != null ? String.Empty : transportador.InscricaoEstadual),
                IeSt = String.Empty,
                IM = String.Empty,
                ModalidadeFrete = Convert.ToInt32(transportador.Responsabilidade_Frete),
                Marca = String.Empty,
                NomeFantasia = transportador.Nome,
                RazaoSocial = transportador.RazaoSocial,
                Numeracao = String.Empty,
                PesoBruto = null,
                PesoLiquido = null,
                Placa = String.Empty,
                QuantidadeVolumes = null,
                Telefone = String.Empty,
                VeiculoUf = transportador.Endereco.UF
            };
        }
    }
}
