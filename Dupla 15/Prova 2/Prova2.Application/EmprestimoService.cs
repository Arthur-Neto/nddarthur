using Prova2.Domain;
using Prova2.Infra;
using Prova2.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova2.Applications
{
    public class EmprestimoService
    {
        public EmprestimoDAO emprestimoDAO = new EmprestimoDAO();
        public TestPDF _pdfCreator;

        public EmprestimoService()
        {

        }

        public Emprestimo AddEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimo = emprestimoDAO.Add(emprestimo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return emprestimo;
        }

        public Emprestimo UpdateEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimoDAO.Update(emprestimo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return emprestimo;
        }

        public Emprestimo GetEmprestimo(int idEmprestimo)
        {
            try
            {
                return emprestimoDAO.GetById(idEmprestimo);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //public IQueryable<Emprestimo> GetAllEmprestimo()
        public IList<Emprestimo> GetAllEmprestimo()
        {
            try
            {
                 return emprestimoDAO.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                emprestimoDAO.Delete(emprestimo.Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ReportList(string fileName)
        {
            try
            {

                IList<Emprestimo> emprestimoList = emprestimoDAO.GetAll();

                _pdfCreator = new TestPDF(fileName);

                _pdfCreator.AbrirDocumento();

                _pdfCreator.Escrever("Lista de Emprestimos:");

                foreach (var item in emprestimoList)
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
