using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    [Table("Answers")]
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Point { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
