using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MathGameBIT286.Models
{
    public class AdditionQuestion1
    {
        //key for database to easily pull up question info
        [Key]
        private int QuestionID { get; set; }

        private int Answer { get; set; }

        private int OtherVariable { get; set; }

        private bool Correct { get; set; }

        //FullCounter

        //AdditionCounter


    }
}