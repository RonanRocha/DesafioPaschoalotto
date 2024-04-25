using DesafioPaschoalotto.Application.Dto;
using DesafioPaschoalotto.Application.ViewModels;
using System.Data;

namespace DesafioPaschoalotto.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAllUsers();
        Task<UserDetailViewModel> GetUserDetailById(int id);
        Task UpdateUser(UpdateUserDto updateUserDto);
        Task<DataTable> GetUsersToReport();
    }
}
