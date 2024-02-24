using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> Verificar(int metaId)
        {
            return await _context.Metas.AnyAsync(m => m.MetaId == metaId);
        }
        public async Task<bool> Modificar(Metas meta)
        {
            _context.Update(meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Agregar(Metas meta)
        {
            _context.Metas.Add(meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Eliminar(Metas meta)
        {
            _context.Metas.Remove(meta);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Guardar(Metas meta)
        {
            if (!await Verificar(meta.MetaId))
                return await Agregar(meta);
            else
                return await Modificar(meta);
        }
        public async Task<Metas?> Buscar(int metaId)
        {
            return await _context.Metas
                   .AsNoTracking()
                   .FirstOrDefaultAsync(m => m.MetaId == metaId);
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
