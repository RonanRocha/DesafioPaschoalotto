using DesafioPaschoalotto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioPaschoalotto.Domain.Repositories
{
    public interface IUserRepository : IRepository<User, int>
    {

        public Task<User?> GetDetailedUserById(int id);
        public Task<IEnumerable<User>> GetAllUsersDetailed();
    }
}
