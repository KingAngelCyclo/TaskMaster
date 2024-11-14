using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace TaskMaster.Data.Entities
{
    [Table("Tareas")]
    public class Tarea
    {
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string Prioridad { get; set; } = string.Empty;
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaLimite {  get; set; }
        public bool IsCompleted { get; set; }
        public string UserId { get; set; } = string.Empty;

        public static Tarea Create
            (
            string titulo, 
            string descripcion,
            string estado,
            string prioridad,
            DateTime? fechaCreacion,
            DateTime? fechaLimite,
            bool isCompleted,
            string UserId
            )
        => new() 
        { 
            Titulo = titulo,
            Descripcion = descripcion,
            Estado = estado,
            Prioridad = prioridad,
            FechaCreacion = fechaCreacion,
            FechaLimite = fechaLimite,
            IsCompleted = isCompleted,
            UserId = UserId
        };
        public bool Update(
            string titulo, 
            string descripcion,
            string estado,
            string prioridad,
            DateTime? fechaCreacion,
            DateTime? fechaLimite,
            bool isCompleted,
            string userId
            )
        {
            var save = false;
            if (Titulo != titulo)
            {
                Titulo = titulo; save = true;
            }
            if (Descripcion != descripcion)
            {
                Descripcion = descripcion; save = true;
            }
            if (Estado != estado)
            {
                Estado = estado; save = true;
            }
            if (Prioridad != prioridad)
            {
                Prioridad = prioridad; save = true;
            }
            if (FechaCreacion != fechaCreacion)
            {
                FechaCreacion = fechaCreacion; save = true;
            }
            if (FechaLimite != fechaLimite)
            {
                FechaLimite = fechaLimite; save = true;
            }
            if (IsCompleted != isCompleted)
            {
                IsCompleted = isCompleted; save = true;
            }
            if (UserId != userId)
            {
                UserId = userId; save = true;
            }
            return save;
        }
    }

}

