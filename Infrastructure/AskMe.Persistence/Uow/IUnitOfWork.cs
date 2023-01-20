using AskMe.Domain.Application.Contracts.Persistence;

namespace AskMe.Persistence.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        IQuestionRepository QuestionRepository { get; }
        IAnswerRepository AnswerRepository { get; } 
        Task Save();
    }
}
