using System.Threading.Tasks;
using AkshayTask.Models;
namespace AkshayTask.Repositories
{
    public interface IApplicationRepository
    {
        Task SubmitApplicationAsync(Application application);
    }
}
