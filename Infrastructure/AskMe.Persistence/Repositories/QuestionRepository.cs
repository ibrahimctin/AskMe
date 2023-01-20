using AskMe.Domain.Application.Contracts.Persistence;
using AskMe.Domain.Entities.DbModels;
using AskMe.Persistence.Context;

namespace AskMe.Persistence.Repositories
{
    public class QuestionRepository : RepositoryBase<Question>, IQuestionRepository
    {
        private readonly AppDbContext _context;
        public QuestionRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
