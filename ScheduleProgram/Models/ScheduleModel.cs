using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleProgram.Models
{
    public class ScheduleModel
    {
        public int ScheduleCode { get; set; }
        public System.DateTime ValidForm { get; set; }
        public System.DateTime ValidTo { get; set; }
        public int Uploader { get; set; }
    }
}