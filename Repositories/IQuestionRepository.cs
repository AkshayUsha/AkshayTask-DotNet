using AkshayTask.Models;
using System.Threading.Tasks;

namespace AkshayTask.Repositories
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(Question question);
        Task UpdateQuestionAsync(int id, Question question);
    }
}
