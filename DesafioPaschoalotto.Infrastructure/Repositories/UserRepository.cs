using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DesafioPaschoalotto.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(AppDbContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<User>> GetAllUsersDetailed()
        {
            return await _ctx.Users
                           .Include(x => x.Contact)
                           .Include(x => x.Location)
                           .Include(x => x.Document).OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<User?> GetDetailedUserById(int id)
        {
            return await _ctx.Users
                            .Include(x => x.Contact)
                            .Include(x => x.Location)
                            .Include(x => x.Document).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
