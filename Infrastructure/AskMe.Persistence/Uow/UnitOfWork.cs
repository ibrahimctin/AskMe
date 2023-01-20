

using AskMe.Domain.Application.Constants;
using AskMe.Domain.Application.Contracts.Persistence;
using AskMe.Persistence.Context;
using AskMe.Persistence.Repositories;
using Microsoft.AspNetCore.Http;

namespace AskMe.Persistence.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private  IQuestionRepository _questionRepository;
        private  IAnswerRepository _answerRepository;

        public UnitOfWork(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public IQuestionRepository QuestionRepository => _questionRepository ??= new QuestionRepository(_context);
        public IAnswerRepository AnswerRepository => _answerRepository??= new AnswerRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
