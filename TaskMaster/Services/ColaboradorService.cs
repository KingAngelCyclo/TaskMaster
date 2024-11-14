using Microsoft.AspNetCore.Identity;
using TaskMaster.Data;

namespace TaskMaster.Services;

public partial class ColaboradorService : IColaboradorService
{
    private readonly IApplicationDbContext dbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public ColaboradorService(IApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
    {
        this.dbContext = dbContext;
        this._userManager = userManager;

    }
}
