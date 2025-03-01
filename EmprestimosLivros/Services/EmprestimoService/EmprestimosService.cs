using Azure;
using EmprestimosLivros.Data;
using EmprestimosLivros.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmprestimosLivros.Services.EmprestimoService
{
    public class EmprestimosService : IEmprestimosInterface
    {

        readonly private ApplicationDbContext _context;

        public EmprestimosService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<EmprestimosModel>>> BuscarEmprestimos()
        {
            ResponseModel<List<EmprestimosModel>> response = new ResponseModel<List<EmprestimosModel>>();

            try
            {
                var emprestimos = await _context.Emprestimos.ToListAsync();
                response.Dados = emprestimos;
                response.Mensagem = "Emprestimos encontrados com sucesso!";

                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<EmprestimosModel>> BuscarEmprestimoPorId(int? id)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {
                if (id == null)
                {
                    response.Mensagem = "Emprestimo não encontrado!";
                    response.Status = false;
                    return response;
                }


                var emprestimo = await _context.Emprestimos.FirstOrDefaultAsync(x => x.Id == id);

                if (emprestimo == null)
                {
                    response.Mensagem = "Emprestimo não encontrado!";
                    response.Status = false;
                    return response;
                }

                response.Dados = emprestimo;
                response.Mensagem = "Emprestimo encontrado com sucesso!";
                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<DataTable> BuscaDadosEmprestimosExcel()
        {
            DataTable dt = new DataTable();

            dt.TableName = "Dados empréstimos";

            dt.Columns.Add("Recebedor", typeof(string));
            dt.Columns.Add("Fornecedor", typeof(string));
            dt.Columns.Add("LivroEmprestado", typeof(string));
            dt.Columns.Add("DataEmprestimo", typeof(DateTime));

            var emprestimos = await BuscarEmprestimos();

            if (emprestimos.Dados.Count > 0)
            {
                emprestimos.Dados.ForEach(emprestimo =>
                {
                    dt.Rows.Add(emprestimo.Recebedor, emprestimo.Fornecedor, emprestimo.LivroEmprestado, emprestimo.DataEmprestimo);
                });
            }

            return dt;
        }

        public async Task<ResponseModel<EmprestimosModel>> CadastrarEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {
                _context.Add(emprestimosModel);
                await _context.SaveChangesAsync();
                response.Mensagem = "Emprestimo cadastrado com sucesso!";
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmprestimosModel>> EditarEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();


            try
            {
                var emprestimo = await BuscarEmprestimoPorId(emprestimosModel.Id);

                if (emprestimo.Status == false)
                {
                    return emprestimo;

                }

                emprestimo.Dados.LivroEmprestado = emprestimosModel.LivroEmprestado;
                emprestimo.Dados.Fornecedor = emprestimosModel.Fornecedor;
                emprestimo.Dados.Recebedor = emprestimosModel.Recebedor;

                _context.Update(emprestimo.Dados);

                await _context.SaveChangesAsync();

                response.Mensagem = "Emprestimo editado com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;

            }
        }

        public async Task<ResponseModel<EmprestimosModel>> RemoveEmprestimo(EmprestimosModel emprestimosModel)
        {
            ResponseModel<EmprestimosModel> response = new ResponseModel<EmprestimosModel>();

            try
            {
                _context.Remove(emprestimosModel);
                await _context.SaveChangesAsync();

                response.Mensagem = "Emprestimo removido com sucesso!";

                return response;

            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
