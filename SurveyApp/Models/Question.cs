using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SurveyApp.Models
{
    [Table("Questions")]
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Answer> Answers { get; set; } = new List<Answer>();
        public ICollection<Survey> Surveys { get; set; } = new List<Survey>();


    }
}
