using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Parcial1_AP1_RuthCasillaGarcia.DAL;
using Parcial1_AP1_RuthCasillaGarcia.Models;
using System.Linq.Expressions;

namespace Parcial1_AP1_RuthCasillaGarcia.Services
{
    public class MetasService
    {
        private readonly Context _context;
        public MetasService(Context context)
        {
            _context = context;
        }

        public async Task<bool> Verificar(int MetaId)
        {
            return await _context.Metas.AnyAsync(m => m.MetaId == MetaId);
        }
        public async Task<bool> Modificar(Metas Meta)
        {
            _context.Update(Meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Agregar(Metas Meta)
        {
            _context.Metas.Add(Meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(Metas Meta)
        {
            _context.Metas.Remove(Meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Metas Meta)
        {
            if (!await Verificar(Meta.MetaId))
                return await Agregar(Meta);
            else
                return await Modificar(Meta);
        }
        public async Task<Metas?> Buscar(int MetaId)
        {
            return await _context.Metas
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.MetaId == MetaId);
        }
        public async Task<List<Metas>> Listar(Expression<Func<Metas, bool>> criterio)
        {
            return await _context.Metas
                         .AsNoTracking()
                         .Where(criterio)
                         .ToListAsync();
        }
    }
}
