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
        private int SkillID { get; set; }

        private int MathSkill { get; set; }

        private int AdditionSkill { get; set; }

        private int SubtractionSkill { get; set; }

        private int GeometrySkill { get; set; }

    }
}