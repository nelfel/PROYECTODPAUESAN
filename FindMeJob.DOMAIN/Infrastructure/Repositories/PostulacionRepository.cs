using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class PostulacionRepository : IPostulacionRepository
    {
        private readonly FindMeJobContext _dbContext;

        public PostulacionRepository(FindMeJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext
                            .Postulacion
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            if (item == null)
                return false;

            _dbContext.Postulacion.Remove(item);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Postulacion>> GetAll()
        {
            var result = await _dbContext.Postulacion.ToListAsync();
            return result;
        }

        public Task<Postulacion> GetById(int id)
        {
            var result = _dbContext
                .Postulacion
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<Postulacion>> GetPostulacionesByOfertaTrabajo(int idOfertaTrabajo)
        {
            var result = await _dbContext
                .Postulacion
                .Where(x => x.OfertaId == idOfertaTrabajo)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<Postulacion>> GetPostulacionesByUsuario(int idUsuario)
        {
            var result = await _dbContext
                .Postulacion
                .Where(x => x.UsuarioId == idUsuario)
                .ToListAsync();

            return result;
        }

        public async Task<bool> Insert(Postulacion postulacion)
        {
            await _dbContext.Postulacion.AddAsync(postulacion);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Postulacion postulacion)
        {
            _dbContext.Postulacion.Update(postulacion);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
