using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PasswordPolicy.Models.MMPAY
{
    [Table("CPSPasswordQuestions")]
    public class CPSPasswordQuestions
    {
        [Key]
        public int CPSPasswordQuestionsId { get; set; }
        public string CPSPasswordQuestion { get; set; }
        public string Language { get; set; }
        public string CPSPasswordQuestionCode { get; set; }
    }
}