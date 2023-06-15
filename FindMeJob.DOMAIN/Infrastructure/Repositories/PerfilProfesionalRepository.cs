using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Data.Entity.SqlServer;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class PerfilProfesionalRepository : IPerfilProfesionalRepository
    {
        private readonly FindMeJobContext _dbContext;

        public PerfilProfesionalRepository(FindMeJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var item = await _dbContext
                            .PerfilProfesional
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            if (item == null)
                return false;

            _dbContext.PerfilProfesional.Remove(item);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<PerfilProfesional>> GetAll()
        {
            var result = await _dbContext.PerfilProfesional.ToListAsync();
            return result;
        }

        public async Task<PerfilProfesional> GetById(int id)
        {
            var result = await _dbContext
                .PerfilProfesional
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IEnumerable<PerfilProfesional>> GetPerfilProfesionalByDescripcion(string descripcion)
        {
            var result = await _dbContext
                .PerfilProfesional
                .Where(x => x.Descripcion.Contains(descripcion))
                .ToListAsync();

            return result;
        }

        public async Task<bool> Insert(PerfilProfesional perfilProfesional)
        {
            await _dbContext.PerfilProfesional.AddAsync(perfilProfesional);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(PerfilProfesional perfilProfesional)
        {
            _dbContext.PerfilProfesional.Update(perfilProfesional);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
