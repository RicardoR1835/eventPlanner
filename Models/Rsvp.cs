using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BeltExam.Models
{
    public class Rsvp
    {
        [Key]
        public int RsvpId {get;set;}

        public int UserId {get;set;}

        public User Guest {get;set;}

        public int ActivityId {get;set;}

        public Event EventToRsvp {get;set;}
       
        public DateTime CreatedAt {get;set;} = DateTime.Now;

        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}

//***********************************adjust model names******************************************* */