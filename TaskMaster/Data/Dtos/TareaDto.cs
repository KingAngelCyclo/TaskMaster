using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Data.Dtos;
public record TareaDto(
    int Id,
    string Titulo = null!,
    string Descripcion = null!,
    string Estado = null!,
    string Prioridad = null!,
    DateTime? FechaCreacion = null!,
    DateTime? FechaLimite = null!,
    bool IsCompleted = false,
    string UserId = null!
    ) 
    {
    public TareaRequest ToRequest()
=> new()
{
    Id = this.Id,
    Titulo = this.Titulo,
    Descripcion = this.Descripcion,
    Prioridad = this.Prioridad,
    Estado = this.Estado,
    FechaCreacion = this.FechaCreacion,
    FechaLimite = this.FechaLimite,
    IsCompleted = this.IsCompleted,
    UserId = this.UserId

};
};
public class TareaRequest
{
    public int Id { get; set; } = 0;
    public string Titulo { get; set; } = "";
    public string Descripcion { get; set; } = "";
    public string Estado { get; set; } = "";
    public string Prioridad { get; set; } = "";
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaLimite { get; set; } 
    public bool IsCompleted { get; set; }
    public string UserId { get; set; } = string.Empty;
}

