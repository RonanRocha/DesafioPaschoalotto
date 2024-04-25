using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;

namespace DesafioPaschoalotto.Infrastructure.Repositories
{
    public class ContactRepository : Repository<Contact, int>, IContactRepository
    {
        public ContactRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
