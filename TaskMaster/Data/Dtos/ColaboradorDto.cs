using Microsoft.VisualBasic;

namespace TaskMaster.Data.Dtos;

public record ColaboradorDto(
    int Id,
    string InviterUserId,
    string InvitedUserId,
    int TareaId,
    DateTime InvitationDate,
    bool IsAccepted
    )
{
public ColaboradorRequest ToRequestColaboradorDto()
=> new()
{ 
    Id = this.Id,
    InviterUserId = this.InviterUserId,
    InvitedUserId = this.InvitedUserId,
    TareaId = this.TareaId,
    IsAccepted = this.IsAccepted
};
};
public class ColaboradorRequest
{
    public int Id { get; set; }
    public string InviterUserId { get; set; } = string.Empty;
    public string InvitedUserId { get; set; } = string.Empty;
    public int TareaId { get; set; }
    public DateTime InvitationDate { get; set; }
    public bool IsAccepted { get; set; }
}