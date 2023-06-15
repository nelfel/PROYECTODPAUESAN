using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<IEnumerable<Empresa>> GetAll();
        Task<Empresa> GetById(int id);
        Task<bool> Insert(Empresa empresa);
        Task<bool> Update(Empresa empresa);
        Task<bool> Delete(int id);
        Task<Empresa> Login(string correoElectronico, string contrasena);
    }
}
