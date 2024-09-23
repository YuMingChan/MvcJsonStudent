using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCrudJson.Models
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Date of Birth")] 
        public DateTime DateOfBirth { get; set; }
        public string Grade { get; set; }
     
    }
}