using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public string Job_Title { get; set; }
        public string Service_Team { get; set; }
        public string Contact_Tel_No { get; set; }
        public string Work_Base_Address { get; set; }
        public string Mobile_No { get; set; }
        public string Email_Address { get; set; }
        public string Courier_Code_Internal_Post { get; set; }
        public string Applicants_Name { get; set; }
        public string Applicant_Date { get; set; }
        public string Managers_Name { get; set; }
        public string Managers_Date { get; set; }
        public string Print_Managers_Name { get; set; }
        public string Managers_Base { get; set; }
        public string Organisation { get; set; } 
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
