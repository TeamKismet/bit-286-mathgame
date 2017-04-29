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
        private int AQuestionID { get; set; }

        private int AddAnswer { get; set; }

        private int AddVariable { get; set; }

        Random rnd = new Random();

        //SkillTracker addCounter = new skillTracker();

        //MathTracker FullCounter = new MathTracker();

    }
}