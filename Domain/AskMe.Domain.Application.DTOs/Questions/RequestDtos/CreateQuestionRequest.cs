using AskMe.Domain.Application.DTOs.Common;

namespace AskMe.Domain.Application.DTOs.Questions.RequestDtos
{
    public class CreateQuestionRequest:BaseDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
    }
}
