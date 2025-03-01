using EmprestimosLivros.Models;
using System.Data;

namespace EmprestimosLivros.Services.EmprestimoService
{
    public interface IEmprestimosInterface
    {   
        Task<ResponseModel<List<EmprestimosModel>>> BuscarEmprestimos();
        Task<ResponseModel<EmprestimosModel>> BuscarEmprestimoPorId(int? id);
        Task<ResponseModel<EmprestimosModel>> CadastrarEmprestimo(EmprestimosModel emprestimosModel);
        Task<ResponseModel<EmprestimosModel>> EditarEmprestimo(EmprestimosModel emprestimosModel);
        Task<ResponseModel<EmprestimosModel>> RemoveEmprestimo(EmprestimosModel emprestimosModel);
        Task<DataTable> BuscaDadosEmprestimosExcel();

    }
}
