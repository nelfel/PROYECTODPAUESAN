using FindMeJob.DOMAIN.Core.Entities;

namespace FindMeJob.DOMAIN.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAll();
        Task<Usuario> GetById(int id);
        Task<bool> Insert(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(int id);
        Task<Usuario> Login(string correoElectronico, string contrasena);
    }
}
