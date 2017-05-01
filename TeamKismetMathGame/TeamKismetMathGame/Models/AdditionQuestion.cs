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

        public int AdditionSkillCounter { get; set; }

        public int AddAnswer { get; set; }

        public int AddVariable { get; set; }

        public bool ACorrect { get; set; }

        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }
}