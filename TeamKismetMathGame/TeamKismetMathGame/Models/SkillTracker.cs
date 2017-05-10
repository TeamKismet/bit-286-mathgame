using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TeamKismetMathGame.Models;
using System.Web.Mvc;

namespace TeamKismetMathGame.Models
{
    public class SkillTracker
    {
        [Key]
        public int SkillID { get; set; }

        public int MathPoints { get; set; }

        public int AdditionPoints { get; set; }

        public int SubtractionPoints { get; set; }

        public int GeometryPoints { get; set; }

    }

    public class AdditionSkill
    {
        
    }
}