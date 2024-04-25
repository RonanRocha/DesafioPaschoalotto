using DesafioPaschoalotto.Application.Dto;
using DesafioPaschoalotto.Application.ViewModels;

namespace DesafioPaschoalotto.Application.Interfaces
{
    public interface IRandomUserGeneratorApiService
    {
        Task<bool> ImportRandomUsers();
    
       
    }
}
