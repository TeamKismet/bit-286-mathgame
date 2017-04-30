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
        private int SQuestionID { get; set; }

        private int SubtractAnswer { get; set; }

        private int SubtractionVariable { get; set; }

        private bool SCorrect { get; set; }

        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }
}