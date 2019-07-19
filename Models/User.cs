using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}

        [Required(ErrorMessage = "Please enter your First name.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string FName {get;set;}

        [Required(ErrorMessage = "Please enter your Last name.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters.")]
        public string LName {get;set;}

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress]
        public string Email {get;set;}

        public List<Rsvp> Rsvps {get;set;}

        public List<Event> CreatedEvents {get;set;}

        [Required(ErrorMessage = "Please enter your Password.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password must contain a minimum of eight characters, at least one letter, one number and one special character")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

        [Required(ErrorMessage = "We need to confirm your password, please fill this field out.")]
        [NotMapped]
        [MinLength(8)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

    public class LogUser
    {
        [Required(ErrorMessage = "Please enter your Email for Login.")]
        [EmailAddress]
        public string Email {get;set;}

        [Required(ErrorMessage = "Please enter your Password for Login.")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password {get;set;}
    }

    public class IndexViewModel
    {
        public User NewUser {get;set;}
        public LogUser OldUser {get;set;}
    }
}