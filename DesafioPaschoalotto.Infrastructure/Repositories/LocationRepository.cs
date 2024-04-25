using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;

namespace DesafioPaschoalotto.Infrastructure.Repositories
{
    public class LocationRepository : Repository<Location, int>, ILocationRepository
    {
        public LocationRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
