using Retech.Core.Identify;
using Retech.DataAccess.DataContext;
using Retech.DataAccess.Repositories.Interfaces;

namespace Retech.DataAccess.Repositories.Implementations;

public class UserRepository : BaseRepository<ApplicationUser>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
