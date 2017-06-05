using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeamKismetMathGame.Models
{
    public class SubtractionQuestion
    {
        [Key]
        public int SQuestionID { get; set; }

        public int SubSkillCounter;

        public int? SubAnswer { get; set; }

        public int? SubVariable;

        public int SubInput { get; set; }

        public bool SCorrect { get; set; }


        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }
}