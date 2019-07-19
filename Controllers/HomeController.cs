using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BeltExam.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
     
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }

        DateTime Now = DateTime.Now;

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(dbContext.Users.Any(user => user.Email == newUser.Email))
                {
                    ModelState.AddModelError("NewUser.Email", "Email already in use!");
                    return View("Index");
                }
                else
                {
                    Console.WriteLine(newUser.UserId);
                    HttpContext.Session.SetInt32("Id", newUser.UserId);
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    newUser.Password = Hasher.HashPassword(newUser, newUser.Password); 
                    dbContext.Add(newUser);
                    dbContext.SaveChanges();
                    Console.WriteLine(newUser.UserId);
                    HttpContext.Session.SetInt32("Id", newUser.UserId);
                    return Redirect("home");

                }
            }
            return View("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser LoggedUser)
        {

            if(ModelState.IsValid)
            {
                var confirmUser = dbContext.Users.FirstOrDefault(user => user.Email == LoggedUser.Email);
                if(confirmUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                
                var hasher = new PasswordHasher<LogUser>();
                
                var result = hasher.VerifyHashedPassword(LoggedUser, confirmUser.Password, LoggedUser.Password);
                
                if(result == 0)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                else
                {
                    HttpContext.Session.SetInt32("Id", confirmUser.UserId);
                    return Redirect("home");
                }
            }
            return View("Index");
        }
        [HttpGet("home")]
        public IActionResult Home()
        {
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                ModelState.AddModelError("Email", "Please log in or register!");
                return View("Index");
            }
            var Activities = dbContext.Events
            .Include(act => act.GuestList)
            .ThenInclude(user => user.Guest)
            .Include(act => act.Creator)
            .OrderBy(x => x.Time)
            .OrderBy(x => x.Date)
            .ToList();

            User loggedUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));
            ViewBag.LoggedIn = loggedUser;
            ViewBag.Activities = Activities;

            return View("Dashboard");

        }

        [HttpGet("activity/new")]
        public IActionResult NewActivity()
        {
            return View();
        }

        [HttpPost("add/activity")]
        public IActionResult AddActivity(Event newActivity)
        {
            if(ModelState.IsValid)
            {
                if (newActivity.Date < Now)
                {
                    ModelState.AddModelError("Date", "You cant go back in time!?");
                    return View("NewActivity");
                }
                Console.WriteLine("************************");
                User Creator = dbContext.Users.FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));
                newActivity.UserId = Creator.UserId;
                newActivity.Creator = Creator;
                dbContext.Add(newActivity);
                dbContext.SaveChanges();
                return Redirect($"/activity/{newActivity.EventId}");
            }
            return View("NewActivity");
        }

        [HttpGet("activity/{id}")]
        public IActionResult SoloEvent(int id)
        {
            var thisEvent = dbContext.Events
            .Include(thisE => thisE.Creator)
            .Include(thisE => thisE.GuestList)
            .ThenInclude(guest => guest.Guest)
            .Where(x => x.EventId == id)
            .ToList();
            User loggedUser = dbContext.Users
            .FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));
            ViewBag.LoggedIn = loggedUser;
            return View("Event", thisEvent);
        }

        [HttpGet("rsvp/{id}")]
        public IActionResult Rsvp(int id)
        {
            var CheckRsvps = dbContext.Rsvps
            .Include(rsvp => rsvp.EventToRsvp)
            .Include(rsvp => rsvp.Guest)
            .Where(user => user.UserId == HttpContext.Session.GetInt32("Id"));

            Event EventToRsvp = dbContext.Events
            .FirstOrDefault(thisevent => thisevent.EventId == id);

            User UserRsvp = dbContext.Users
            .FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));


            foreach(var rsvp in CheckRsvps)
            {
                if(rsvp.EventToRsvp.Date == EventToRsvp.Date)
                {
                    ModelState.AddModelError("Date", "Conflicting date with another Event!");
                    var Activities = dbContext.Events
                    .Include(act => act.GuestList)
                    .ThenInclude(user => user.Guest)
                    .Include(act => act.Creator)
                    .ToList();

                    User loggedUser = dbContext.Users
                    .FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));
                    ViewBag.LoggedIn = loggedUser;
                    ViewBag.Activities = Activities;

                    return View("Dashboard");
                }
            }

            Rsvp NewRsvp = new Rsvp();
            NewRsvp.UserId = UserRsvp.UserId;
            NewRsvp.ActivityId = EventToRsvp.EventId;
            NewRsvp.Guest = UserRsvp;
            NewRsvp.EventToRsvp = EventToRsvp;
            dbContext.Add(NewRsvp);
            dbContext.SaveChanges();
            return Redirect("/home");

        }

        [HttpGet("unrsvp/{id}")]
        public IActionResult UnRsvp(int id)
        {
            Event EventToUnRsvp = dbContext.Events
            .FirstOrDefault(thiswed => thiswed.EventId == id);

            User UserUnRsvp = dbContext.Users
            .FirstOrDefault(user => user.UserId == HttpContext.Session.GetInt32("Id"));

            var Rsvps = dbContext.Rsvps
            .Where(rs => rs.ActivityId == EventToUnRsvp.EventId)
            .ToList();

            Rsvp Unrsvp = Rsvps.FirstOrDefault(user => user.UserId == UserUnRsvp.UserId);
            dbContext.Remove(Unrsvp);
            dbContext.SaveChanges();
            return Redirect("/home");
        }

        [HttpGet("delete/{id}")]
        public IActionResult Destroy(int id)
        {
            Event thisEvent = dbContext.Events
            .FirstOrDefault(even => even.EventId == id);
            dbContext.Remove(thisEvent);
            dbContext.SaveChanges();
            return Redirect("/home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

    }
}