using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeamKismetMathGame.Models
{
    public class AdditionQuestion
    {
        [Key]
        public int AQuestionID { get; set; }

        public int AdditionSkillCounter;

        public int? AddAnswer { get; set; }

        public int? AddVariable;

        public int? AddInput { get; set; }

        public bool ACorrect { get; set; }

        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }    
}