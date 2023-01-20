using AskMe.Domain.Application.Contracts.Persistence;
using AskMe.Domain.Entities.DbModels;
using AskMe.Persistence.Context;

namespace AskMe.Persistence.Repositories
{
    public class AnswerRepository : RepositoryBase<Answer>, IAnswerRepository
    {

        private readonly AppDbContext _context;
        public AnswerRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
