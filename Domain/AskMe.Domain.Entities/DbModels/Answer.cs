using AskMe.Domain.Entities.Common;
using AskMe.Domain.Entities.IdentityEntities;

namespace AskMe.Domain.Entities.DbModels
{
    public class Answer: BaseDomainEntity
    {
        public string QuestionId { get; set; }
        public string ContentBody { get; set; }

        public bool IsPrivate { get; set; }
        public Question Question  { get; set; }

        public AppUser   AppUser { get; set; }
    }
}
