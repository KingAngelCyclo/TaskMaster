using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Data.Entities
{
    [Table("Comentarios")]
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        public string Cometario {  get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
