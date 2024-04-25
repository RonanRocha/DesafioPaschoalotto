using DesafioPaschoalotto.Domain.Entities;
using DesafioPaschoalotto.Domain.Repositories;
using DesafioPaschoalotto.Infrastructure.Context;

namespace DesafioPaschoalotto.Infrastructure.Repositories
{
    public class DocumentRepository : Repository<Document, int>, IDocumentRepository
    {
        public DocumentRepository(AppDbContext ctx) : base(ctx)
        {
        }
    }
}
