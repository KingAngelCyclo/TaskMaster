using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Data.Entities
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Cometario { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }


        public static Comentario Create
       (
       string cometario,
       DateTime fechaCreacion
       )
       => new()
       {
           Cometario = cometario,
           FechaCreacion = fechaCreacion
       };
        public bool Update(
            string cometario,
            DateTime fechaCreacion
            )
        {
            var save = false;
            if (Cometario != cometario)
            {
                Cometario = cometario; save = true;
            }
            if (FechaCreacion != fechaCreacion)
            {
                FechaCreacion = fechaCreacion; save = true;
            }
            return save;
        }
    }
}
