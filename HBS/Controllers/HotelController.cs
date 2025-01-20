using Microsoft.AspNetCore.Mvc;
using Hotel_Booking_System.Models;
using System.Web;
using RestSharp;

namespace Hotel_Booking_System.Controllers
{
    public class HotelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
      
        public ViewResult gallery()
        {
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
        public IActionResult Payment()
        {
            return View();
        }


        [HttpGet]
        public ViewResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string email,string password)
        {
            //Create cookie
            var options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(7);
            
            //USE COOKIES
            HttpContext.Response.Cookies.Append("Email",email,options);
            HttpContext.Response.Cookies.Append("Password", password,options);

            //USE SESSION
            {

                HttpContext.Session.SetString("Email", email);
                HttpContext.Session.SetString("Password", password);
            }

            using (var dbContext = new HotelDbContext())
            {
                // Check if the username and password match in the database
                User user = dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Incorrect email or password.";
                    return View();
                }
            }
        }


        [HttpGet]
        public ViewResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Signup(User user)
        {
            myhotelDb myhotelDb = new myhotelDb();
            myhotelDb.addUser(user);
            return View();
        }
        [HttpGet]
        public ViewResult Booking()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Booking(Booking b)
        {
            //var userData2 = HttpContext.Session.GetString("Email");
            if (Request.Cookies["Email"] != null)
            {
                var emailCookie = Request.Cookies["Email"];
                var passCookie = Request.Cookies["Password"];

            }
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Email")))
            {
                var email = HttpContext.Session.GetString("Email");
                var password = HttpContext.Session.GetString("Passowrd");

                //store data in the database
                myhotelDb myhotelDb = new myhotelDb();
                myhotelDb.booking(b);
                return RedirectToAction("Payment", "Hotel");
            }

            else
            {
                return View("login","Hotel");
            }
            //store data in repository
            //HotelRepository.addBooking(b);
            //return View("ViewBooking",b);
        }


        public ViewResult bookingList()
        {
            return View(HotelRepository.bookings);
        }

        public ViewResult Admin()
        {
            return View();
        }
        public ViewResult UpdateBooking()
        {
            return View();
        }
        [HttpGet]
        public ViewResult DeleteBooking()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteBooking(string email,string name)
        {
            using (var _dbContext = new HotelDbContext())
            {
                Booking booking = _dbContext.Bookings.FirstOrDefault(u => u.Email == email && u.FullName == name);

                if (booking != null)
                {
                    _dbContext.Bookings.Remove(booking);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "No user found with the provided email.";
                    return View();
                }
            }            
        }
        public ViewResult logout()
        {
            HttpContext.Response.Cookies.Delete("Email");
            HttpContext.Response.Cookies.Delete("Password");

            return View();
        }


    }
}
