using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduleProgram.Models
{
    public class PersonalInfoModel
    {
        public int Id { get; set; }
        public string PersonellNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ScheduleCode { get; set; }
    }
}