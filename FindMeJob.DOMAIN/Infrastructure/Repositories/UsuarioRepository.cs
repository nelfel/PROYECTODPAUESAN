using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly FindMeJobContext _dbContext;

        public UsuarioRepository(FindMeJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _dbContext
                            .Usuario
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            if (usuario == null)
                return false;

            _dbContext.Usuario.Remove(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            var result = await _dbContext.Usuario.ToListAsync();
            return result;
        }

        public async Task<Usuario> GetById(int id)
        {
            var result = await _dbContext
               .Usuario
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Insert(Usuario usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public Task<Usuario> Login(string correoelectronico, string contrasena)
        {
            var result = _dbContext
                .Usuario
                .Where(x => x.CorreoElectronico == correoelectronico && x.Contrasena == contrasena)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _dbContext.Usuario.Update(usuario);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
