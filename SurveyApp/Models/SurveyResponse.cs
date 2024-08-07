using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    [Table("SurveyResponses")]
    public class SurveyResponse
    {
        [Key]
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public Survey Survey { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime ResponseDate { get; set; } = DateTime.Now;
        public ICollection<SurveyAnswer> SurveyAnswers { get; set; } = new List<SurveyAnswer>();
    }
}
