using CrudDapper.Dto;
using CrudDapper.Models;

namespace CrudDapper.Service
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
    }       
}
