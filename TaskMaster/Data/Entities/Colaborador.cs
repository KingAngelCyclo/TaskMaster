using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Data.Entities
{
    [Table("Colaboradores")]
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }
        public string InviterUserId { get; set; } 
        public string InvitedUserId { get; set; } 
        public int TareaId { get; set; } 
        public DateTime InvitationDate { get; set; }
        public bool IsAccepted { get; set; } 
    }
}
