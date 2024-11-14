using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TaskMaster.Data;
using TaskMaster.Data.Entities;

namespace TaskMaster.Services;

public partial class ColaboradorService : IColaboradorService
{
    private readonly IApplicationDbContext dbContext;
    private readonly UserManager<ApplicationUser> _userManager;


    public ColaboradorService(IApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        this.dbContext = dbContext;
        _userManager = userManager;
    }
    public async Task SendInvitationAsync(string inviterUserId, string invitedUserEmail, int tareaId)
    {
        var invitedUser = await _userManager.FindByEmailAsync(invitedUserEmail);
        if (invitedUser == null)
        {
            throw new Exception("El usuario invitado no existe.");
        }

        var Colaborador = new Colaborador
        {
            InviterUserId = inviterUserId,
            InvitedUserId = invitedUser.Id,
            TareaId = tareaId,
            InvitationDate = DateTime.Now,
            IsAccepted = false
        };

        dbContext.Colaboradores.Add(Colaborador);
        await dbContext.SaveChangesAsync();
    }
    public async Task<bool> UserHasAccessAsync(string userId, int contentId)
    {
        return await dbContext.Colaboradores
            .AnyAsync(i => i.TareaId == contentId && i.InvitedUserId == userId && i.IsAccepted);
    }

    public async Task AcceptInvitationAsync(int invitationId)
    {
        var Colaborador = await dbContext.Colaboradores.FindAsync(invitationId);
        if (Colaborador == null) throw new Exception("Invitación no encontrada.");

        Colaborador.IsAccepted = true;
        await dbContext.SaveChangesAsync();
    }
}

