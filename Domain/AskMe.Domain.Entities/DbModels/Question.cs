using AskMe.Domain.Entities.Common;

namespace AskMe.Domain.Entities.DbModels
{
    public class Question: BaseDomainEntity
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public ICollection<Answer> Answers { get; set; }
    }
}
