
using System;
using System.Linq;
namespace Hotel_Booking_System.Models
{
    public class myhotelDb
    {
        public void addUser(User u)
        {
            //get data from controller
            User user = new User();
            user.FirstName = u.FirstName;
            user.LastName = u.LastName;
            user.Email = u.Email;
            user.Password = u.Password;

            //add to database
            var db= new HotelDbContext();
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void booking(Booking b)
        {
            Booking booking = new Booking();    
            booking.FullName = b.FullName;
            booking.CheckOut = b.CheckOut;
            booking.CheckIn  = b.CheckIn;
            booking.Perons = b.Perons;
            booking.Email = b.Email;
            booking.PhoneNumber = b.PhoneNumber;

            //add to database
            var db = new HotelDbContext();
            db.Bookings.Add(booking);
            db.SaveChanges();
        }
        public void checkout(string name,string email)
        {
            var db = new HotelDbContext();
            Booking booking = new Booking();

            var b = db.Bookings.Where(s1 => booking.Email == email).First();
            db.Bookings.Remove(b);
            db.SaveChanges();
        }
      
    }
}
