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
        public int GQuestionID { get; set; }

        public int GeometryAnswer { get; set; }

        public int GeometryVariable { get; set; }

        public bool GCorrect { get; set; }

        Random rnd = new Random();

        SkillTracker Counter = new SkillTracker();
    }
}