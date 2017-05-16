using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamKismetMathGame.Models
{
        public class Activity
        {
            public int ActivityID { get; set; }
            public string ActivityName { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime ActivityDate { get; set; }
        }
}