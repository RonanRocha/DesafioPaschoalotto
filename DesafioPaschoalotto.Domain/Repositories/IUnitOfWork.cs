using System.Data;

namespace DesafioPaschoalotto.Domain.Repositories
{
    public interface IUnitOfWork 
    {
        Task SaveChangesAsync();
    }
}
