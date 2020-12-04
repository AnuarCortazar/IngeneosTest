using System.Threading.Tasks;

namespace IngeneosTest.Application.Contract
{
    public interface IManageService
    {
        Task<bool> SynchronizeInformation();
    }
}