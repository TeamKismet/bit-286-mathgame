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

        public int MathSkill { get; set; }

        public int AdditionSkill { get; set; }

        public int SubtractionSkill { get; set; }

        public int GeometrySkill { get; set; }

    }
}