using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class Event
    {
        [Key]
        public int EventId {get;set;}

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title {get;set;}

        public string Time {get;set;}

        public DateTime Date {get;set;}

        public int Duration {get;set;}

        public string TimeType {get;set;}
       
        [Required(ErrorMessage = "Please enter a Description.")]
        public string Description {get;set;}

        public int UserId {get;set;}

        public User Creator {get;set;}

        public List<Rsvp> GuestList {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;


    }
}

        //***********************************adjust model names******************************************* */