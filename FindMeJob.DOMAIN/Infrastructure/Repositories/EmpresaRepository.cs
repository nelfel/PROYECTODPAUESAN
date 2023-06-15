using FindMeJob.DOMAIN.Core.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using FindMeJob.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FindMeJob.DOMAIN.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly FindMeJobContext _dbContext;

        public EmpresaRepository(FindMeJobContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Delete(int id)
        {
            var empresa = await _dbContext
                            .Empresa
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();

            if (empresa == null)
                return false;

            _dbContext.Empresa.Remove(empresa);

            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;    
        }

        public async Task<IEnumerable<Empresa>> GetAll()
        {
            var result = await _dbContext.Empresa.ToListAsync();
            return result;
        }

        public async Task<Empresa> GetById(int id)
        {
            var result = await _dbContext
                .Empresa
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> Insert(Empresa empresa)
        {
            await _dbContext.Empresa.AddAsync(empresa);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public Task<Empresa> Login(string correoElectronico, string contrasena)
        {
            var result = _dbContext
                .Empresa
                .Where(x => x.CorreoElectronico == correoElectronico && x.Contrasena == contrasena)
                .FirstOrDefaultAsync();
            return result;
        }

        public async Task<bool> Update(Empresa empresa)
        {
            _dbContext.Empresa.Update(empresa);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
