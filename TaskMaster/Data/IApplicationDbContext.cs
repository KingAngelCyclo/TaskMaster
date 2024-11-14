using Microsoft.EntityFrameworkCore;
using TaskMaster.Data.Entities;

namespace TaskMaster.Data
{
    public interface IApplicationDbContext
    {
        public DbSet<Tarea> Tareas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}