using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    [Table("SurveyAnswers")]
    public class SurveyAnswer
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public int SurveyResponseId { get; set; }
        public SurveyResponse SurveyResponse { get; set; }
    }
}
