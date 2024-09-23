using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCrudJson.Models
{
    public class StudentModel
    {
        [Key]
        [Required]
       
        public int ID { get; set; }

        [Required] 
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Grade { get; set; }
     
    }

    
}