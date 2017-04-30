using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TeamKismetMathGame.Models
{
    public class GeometryQuestion
    {
        [Key]
        private int GQuestionID { get; set; }

        private int GeometryAnswer { get; set; }

        private int GeometryVariable { get; set; }

        private bool GCorrect { get; set; }

        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }
}