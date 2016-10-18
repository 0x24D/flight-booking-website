using flight_booking_website.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace flight_booking_website.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home/Index/
        private FlightsBookingsDBEntities flightsBookingsDB = new FlightsBookingsDBEntities();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult Flights()
        {
            return View(flightsBookingsDB.FlightsTbls.ToList());
        }
        public ActionResult Bookings()
        {
            ViewBag.BookingID = new SelectList(flightsBookingsDB.BookingsTbls, "Id", "Id");
            return View(flightsBookingsDB.BookingsTbls.ToList());
        }
        [HttpGet]
        public ActionResult CreateBooking()
        {
            List<BookingsTbl> outDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> retArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> outArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> retDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> outDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> outArrTimes = new List<BookingsTbl>();
            List<BookingsTbl> retDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> retArrTimes = new List<BookingsTbl>();

            ////Airports
            outDepAirports.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Airport = "LTN" });
            outDepAirports.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Airport = "MAN" });
            outDepAirports.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Airport = "EDI" });
            retArrAirports.Add(new BookingsTbl() { Id = 0, Return_Arrival_Airport = "LTN" });
            retArrAirports.Add(new BookingsTbl() { Id = 1, Return_Arrival_Airport = "MAN" });
            retArrAirports.Add(new BookingsTbl() { Id = 2, Return_Arrival_Airport = "EDI" });
            outArrAirports.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Airport = "AMS" });
            outArrAirports.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Airport = "CDG" });
            outArrAirports.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Airport = "BCN" });
            outArrAirports.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Airport = "MAD" });
            outArrAirports.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Airport = "PRG" });
            outArrAirports.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Airport = "NCE" });
            outArrAirports.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Airport = "MXP" });
            outArrAirports.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Airport = "GVA" });
            outArrAirports.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Airport = "FCO" });
            retDepAirports.Add(new BookingsTbl() { Id = 0, Return_Departure_Airport = "AMS" });
            retDepAirports.Add(new BookingsTbl() { Id = 1, Return_Departure_Airport = "CDG" });
            retDepAirports.Add(new BookingsTbl() { Id = 2, Return_Departure_Airport = "BCN" });
            retDepAirports.Add(new BookingsTbl() { Id = 3, Return_Departure_Airport = "MAD" });
            retDepAirports.Add(new BookingsTbl() { Id = 4, Return_Departure_Airport = "PRG" });
            retDepAirports.Add(new BookingsTbl() { Id = 5, Return_Departure_Airport = "NCE" });
            retDepAirports.Add(new BookingsTbl() { Id = 6, Return_Departure_Airport = "MXP" });
            retDepAirports.Add(new BookingsTbl() { Id = 7, Return_Departure_Airport = "GVA" });
            retDepAirports.Add(new BookingsTbl() { Id = 8, Return_Departure_Airport = "FCO" });

            ////Times
            outDepTimes.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Time = "9:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Time = "10:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Time = "10:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 3, Outbound_Departure_Time = "11:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 4, Outbound_Departure_Time = "12:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 5, Outbound_Departure_Time = "13:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 6, Outbound_Departure_Time = "13:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 7, Outbound_Departure_Time = "14:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 8, Outbound_Departure_Time = "14:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 9, Outbound_Departure_Time = "15:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 10, Outbound_Departure_Time = "16:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 11, Outbound_Departure_Time = "17:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 12, Outbound_Departure_Time = "17:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 13, Outbound_Departure_Time = "19:00" });
            ////outArrTimes
            outArrTimes.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Time = "10:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Time = "10:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Time = "11:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Time = "11:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Time = "12:35" });
            outArrTimes.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Time = "14:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Time = "14:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Time = "14:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Time = "15:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 9, Outbound_Arrival_Time = "16:20" });
            outArrTimes.Add(new BookingsTbl() { Id = 10, Outbound_Arrival_Time = "16:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 11, Outbound_Arrival_Time = "17:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 12, Outbound_Arrival_Time = "17:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 13, Outbound_Arrival_Time = "18:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 14, Outbound_Arrival_Time = "21:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 15, Outbound_Arrival_Time = "21:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 16, Outbound_Arrival_Time = "23:10" });
            retDepTimes.Add(new BookingsTbl() { Id = 0, Return_Departure_Time = "9:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 1, Return_Departure_Time = "10:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 2, Return_Departure_Time = "11:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 3, Return_Departure_Time = "12:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 4, Return_Departure_Time = "12:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 5, Return_Departure_Time = "14:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 6, Return_Departure_Time = "15:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 7, Return_Departure_Time = "15:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 8, Return_Departure_Time = "16:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 9, Return_Departure_Time = "16:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 10, Return_Departure_Time = "18:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 11, Return_Departure_Time = "19:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 12, Return_Departure_Time = "19:30" });
            retArrTimes.Add(new BookingsTbl() { Id = 0, Return_Arrival_Time = "10:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 1, Return_Arrival_Time = "11:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 2, Return_Arrival_Time = "12:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 3, Return_Arrival_Time = "12:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 4, Return_Arrival_Time = "14:45" });
            retArrTimes.Add(new BookingsTbl() { Id = 5, Return_Arrival_Time = "14:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 6, Return_Arrival_Time = "15:05" });
            retArrTimes.Add(new BookingsTbl() { Id = 7, Return_Arrival_Time = "16:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 8, Return_Arrival_Time = "16:40" });
            retArrTimes.Add(new BookingsTbl() { Id = 9, Return_Arrival_Time = "17:20" });
            retArrTimes.Add(new BookingsTbl() { Id = 10, Return_Arrival_Time = "17:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 11, Return_Arrival_Time = "18:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 12, Return_Arrival_Time = "18:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 13, Return_Arrival_Time = "19:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 14, Return_Arrival_Time = "19:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 15, Return_Arrival_Time = "21:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 16, Return_Arrival_Time = "22:40" });
            //ViewBags
            ViewBag.outDepAirports = outDepAirports;
            ViewBag.retArrAirports = retArrAirports;
            ViewBag.retDepAirports = retDepAirports;
            ViewBag.outArrAirports = outArrAirports;
            ViewBag.outDepTimes = outDepTimes;
            ViewBag.outArrTimes = outArrTimes;
            ViewBag.retDepTimes = retDepTimes;
            ViewBag.retArrTimes = retArrTimes;
            return View();
        }
        [HttpPost]
        public ActionResult CreateBooking(BookingsTbl booking)
        {
            List<BookingsTbl> outDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> retArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> outArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> retDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> outDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> outArrTimes = new List<BookingsTbl>();
            List<BookingsTbl> retDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> retArrTimes = new List<BookingsTbl>();

            ////Airports
            outDepAirports.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Airport = "LTN" });
            outDepAirports.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Airport = "MAN" });
            outDepAirports.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Airport = "EDI" });
            retArrAirports.Add(new BookingsTbl() { Id = 0, Return_Arrival_Airport = "LTN" });
            retArrAirports.Add(new BookingsTbl() { Id = 1, Return_Arrival_Airport = "MAN" });
            retArrAirports.Add(new BookingsTbl() { Id = 2, Return_Arrival_Airport = "EDI" });
            outArrAirports.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Airport = "AMS" });
            outArrAirports.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Airport = "CDG" });
            outArrAirports.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Airport = "BCN" });
            outArrAirports.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Airport = "MAD" });
            outArrAirports.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Airport = "PRG" });
            outArrAirports.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Airport = "NCE" });
            outArrAirports.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Airport = "MXP" });
            outArrAirports.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Airport = "GVA" });
            outArrAirports.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Airport = "FCO" });
            retDepAirports.Add(new BookingsTbl() { Id = 0, Return_Departure_Airport = "AMS" });
            retDepAirports.Add(new BookingsTbl() { Id = 1, Return_Departure_Airport = "CDG" });
            retDepAirports.Add(new BookingsTbl() { Id = 2, Return_Departure_Airport = "BCN" });
            retDepAirports.Add(new BookingsTbl() { Id = 3, Return_Departure_Airport = "MAD" });
            retDepAirports.Add(new BookingsTbl() { Id = 4, Return_Departure_Airport = "PRG" });
            retDepAirports.Add(new BookingsTbl() { Id = 5, Return_Departure_Airport = "NCE" });
            retDepAirports.Add(new BookingsTbl() { Id = 6, Return_Departure_Airport = "MXP" });
            retDepAirports.Add(new BookingsTbl() { Id = 7, Return_Departure_Airport = "GVA" });
            retDepAirports.Add(new BookingsTbl() { Id = 8, Return_Departure_Airport = "FCO" });

            ////Times
            outDepTimes.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Time = "9:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Time = "10:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Time = "10:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 3, Outbound_Departure_Time = "11:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 4, Outbound_Departure_Time = "12:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 5, Outbound_Departure_Time = "13:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 6, Outbound_Departure_Time = "13:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 7, Outbound_Departure_Time = "14:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 8, Outbound_Departure_Time = "14:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 9, Outbound_Departure_Time = "15:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 10, Outbound_Departure_Time = "16:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 11, Outbound_Departure_Time = "17:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 12, Outbound_Departure_Time = "17:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 13, Outbound_Departure_Time = "19:00" });
            ////outArrTimes
            outArrTimes.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Time = "10:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Time = "10:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Time = "11:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Time = "11:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Time = "12:35" });
            outArrTimes.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Time = "14:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Time = "14:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Time = "14:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Time = "15:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 9, Outbound_Arrival_Time = "16:20" });
            outArrTimes.Add(new BookingsTbl() { Id = 10, Outbound_Arrival_Time = "16:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 11, Outbound_Arrival_Time = "17:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 12, Outbound_Arrival_Time = "17:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 13, Outbound_Arrival_Time = "18:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 14, Outbound_Arrival_Time = "21:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 15, Outbound_Arrival_Time = "21:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 16, Outbound_Arrival_Time = "23:10" });
            retDepTimes.Add(new BookingsTbl() { Id = 0, Return_Departure_Time = "9:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 1, Return_Departure_Time = "10:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 2, Return_Departure_Time = "11:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 3, Return_Departure_Time = "12:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 4, Return_Departure_Time = "12:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 5, Return_Departure_Time = "14:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 6, Return_Departure_Time = "15:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 7, Return_Departure_Time = "15:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 8, Return_Departure_Time = "16:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 9, Return_Departure_Time = "16:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 10, Return_Departure_Time = "18:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 11, Return_Departure_Time = "19:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 12, Return_Departure_Time = "19:30" });
            retArrTimes.Add(new BookingsTbl() { Id = 0, Return_Arrival_Time = "10:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 1, Return_Arrival_Time = "11:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 2, Return_Arrival_Time = "12:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 3, Return_Arrival_Time = "12:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 4, Return_Arrival_Time = "14:45" });
            retArrTimes.Add(new BookingsTbl() { Id = 5, Return_Arrival_Time = "14:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 6, Return_Arrival_Time = "15:05" });
            retArrTimes.Add(new BookingsTbl() { Id = 7, Return_Arrival_Time = "16:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 8, Return_Arrival_Time = "16:40" });
            retArrTimes.Add(new BookingsTbl() { Id = 9, Return_Arrival_Time = "17:20" });
            retArrTimes.Add(new BookingsTbl() { Id = 10, Return_Arrival_Time = "17:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 11, Return_Arrival_Time = "18:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 12, Return_Arrival_Time = "18:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 13, Return_Arrival_Time = "19:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 14, Return_Arrival_Time = "19:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 15, Return_Arrival_Time = "21:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 16, Return_Arrival_Time = "22:40" });
            //ViewBags
            ViewBag.outDepAirports = outDepAirports;
            ViewBag.retArrAirports = retArrAirports;
            ViewBag.retDepAirports = retDepAirports;
            ViewBag.outArrAirports = outArrAirports;
            ViewBag.outDepTimes = outDepTimes;
            ViewBag.outArrTimes = outArrTimes;
            ViewBag.retDepTimes = retDepTimes;
            ViewBag.retArrTimes = retArrTimes;
            if (!Regex.IsMatch(booking.Name, @"^[a-zA-Z]+$"))
                ModelState.AddModelError("Name", "Your name needs to be alphabetical!");

            if (booking.Age >= 75 || booking.Age < 18)
                ModelState.AddModelError("Age", "The Booker needs to be over 18, and younger than 75!");

            if (!Regex.IsMatch(Convert.ToString(booking.Mobile_Number), "^([0])([0-9]{10})$"))
                ModelState.AddModelError("Mobile_Number", "The Mobile number needs a leading 0 followed by 10 digits!");

            if (!Regex.IsMatch(Convert.ToString(booking.Phone_Number), "^([0-9]{4})(\\s)([0-9]{7})$"))
                ModelState.AddModelError("Phone_Number", "The Telephone number needs 4 digits, followed by a space, followed by the last 7 digits");


            if (!Regex.IsMatch(booking.Email_Address, "^(.+)([0-9]{0,3})(@gmail.com)$"))
                if (!Regex.IsMatch(booking.Email_Address, "^(.+)([0-9]{0,3})(@hotmail.co.uk)$"))
                    ModelState.AddModelError("Email_Address", "The Email needs to be any combination of Letters and Numbers, followed by an @ sign and then gmail.com or hotmail.co.uk");


            if (booking.Number_of_Passengers > 4 || booking.Number_of_Passengers <= 0)
                ModelState.AddModelError("Number_of_Passengers", "The number of passengers needs to be at least 1 but no more than 4");

            if (booking.Number_of_Passengers == 4)
            {
                if (booking.Passenger_1_Age > 75 || booking.Passenger_1_Age < 18)
                {
                    ModelState.AddModelError("Passenger_1_Age", "The 2nd Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (booking.Passenger_2_Age >= 3)
            {
                if (booking.Passenger_2_Age > 75 || booking.Passenger_2_Age < 18)
                {
                    ModelState.AddModelError("Passenger_2_Age", "The 3rd Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (booking.Passenger_3_Age >= 2)
            {
                if (booking.Passenger_3_Age > 75 || booking.Passenger_3_Age < 18)
                {
                    ModelState.AddModelError("Passenger_3_Age", "The 4th Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (ModelState.IsValid)
            {
                flightsBookingsDB.BookingsTbls.Add(booking);
                flightsBookingsDB.SaveChanges();
                return RedirectToAction("Bookings");
            }
            return View(booking);
        }
        [HttpGet]
        public ActionResult DeleteBooking()
        {
            return View(flightsBookingsDB.BookingsTbls.ToList());
        }
        [HttpPost, ActionName("DeleteBooking")]
        public ActionResult DeleteConfirmed(IEnumerable<int> bookingIDs)
        {
            List<BookingsTbl> lstID = flightsBookingsDB.BookingsTbls.Where(x => bookingIDs.Contains(x.Id)).ToList();
            foreach (BookingsTbl item in lstID)
            {
                flightsBookingsDB.BookingsTbls.Remove(item);
            }
            flightsBookingsDB.SaveChanges();
            return RedirectToAction("Bookings");
        }
        public ActionResult EditBooking(int id = 0)
        {
            List<BookingsTbl> outDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> retArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> outArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> retDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> outDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> outArrTimes = new List<BookingsTbl>();
            List<BookingsTbl> retDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> retArrTimes = new List<BookingsTbl>();

            ////Airports
            outDepAirports.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Airport = "LTN" });
            outDepAirports.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Airport = "MAN" });
            outDepAirports.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Airport = "EDI" });
            retArrAirports.Add(new BookingsTbl() { Id = 0, Return_Arrival_Airport = "LTN" });
            retArrAirports.Add(new BookingsTbl() { Id = 1, Return_Arrival_Airport = "MAN" });
            retArrAirports.Add(new BookingsTbl() { Id = 2, Return_Arrival_Airport = "EDI" });
            outArrAirports.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Airport = "AMS" });
            outArrAirports.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Airport = "CDG" });
            outArrAirports.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Airport = "BCN" });
            outArrAirports.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Airport = "MAD" });
            outArrAirports.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Airport = "PRG" });
            outArrAirports.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Airport = "NCE" });
            outArrAirports.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Airport = "MXP" });
            outArrAirports.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Airport = "GVA" });
            outArrAirports.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Airport = "FCO" });
            retDepAirports.Add(new BookingsTbl() { Id = 0, Return_Departure_Airport = "AMS" });
            retDepAirports.Add(new BookingsTbl() { Id = 1, Return_Departure_Airport = "CDG" });
            retDepAirports.Add(new BookingsTbl() { Id = 2, Return_Departure_Airport = "BCN" });
            retDepAirports.Add(new BookingsTbl() { Id = 3, Return_Departure_Airport = "MAD" });
            retDepAirports.Add(new BookingsTbl() { Id = 4, Return_Departure_Airport = "PRG" });
            retDepAirports.Add(new BookingsTbl() { Id = 5, Return_Departure_Airport = "NCE" });
            retDepAirports.Add(new BookingsTbl() { Id = 6, Return_Departure_Airport = "MXP" });
            retDepAirports.Add(new BookingsTbl() { Id = 7, Return_Departure_Airport = "GVA" });
            retDepAirports.Add(new BookingsTbl() { Id = 8, Return_Departure_Airport = "FCO" });

            ////Times
            outDepTimes.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Time = "9:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Time = "10:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Time = "10:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 3, Outbound_Departure_Time = "11:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 4, Outbound_Departure_Time = "12:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 5, Outbound_Departure_Time = "13:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 6, Outbound_Departure_Time = "13:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 7, Outbound_Departure_Time = "14:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 8, Outbound_Departure_Time = "14:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 9, Outbound_Departure_Time = "15:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 10, Outbound_Departure_Time = "16:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 11, Outbound_Departure_Time = "17:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 12, Outbound_Departure_Time = "17:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 13, Outbound_Departure_Time = "19:00" });
            ////outArrTimes
            outArrTimes.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Time = "10:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Time = "10:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Time = "11:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Time = "11:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Time = "12:35" });
            outArrTimes.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Time = "14:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Time = "14:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Time = "14:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Time = "15:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 9, Outbound_Arrival_Time = "16:20" });
            outArrTimes.Add(new BookingsTbl() { Id = 10, Outbound_Arrival_Time = "16:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 11, Outbound_Arrival_Time = "17:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 12, Outbound_Arrival_Time = "17:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 13, Outbound_Arrival_Time = "18:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 14, Outbound_Arrival_Time = "21:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 15, Outbound_Arrival_Time = "21:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 16, Outbound_Arrival_Time = "23:10" });
            retDepTimes.Add(new BookingsTbl() { Id = 0, Return_Departure_Time = "9:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 1, Return_Departure_Time = "10:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 2, Return_Departure_Time = "11:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 3, Return_Departure_Time = "12:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 4, Return_Departure_Time = "12:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 5, Return_Departure_Time = "14:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 6, Return_Departure_Time = "15:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 7, Return_Departure_Time = "15:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 8, Return_Departure_Time = "16:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 9, Return_Departure_Time = "16:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 10, Return_Departure_Time = "18:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 11, Return_Departure_Time = "19:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 12, Return_Departure_Time = "19:30" });
            retArrTimes.Add(new BookingsTbl() { Id = 0, Return_Arrival_Time = "10:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 1, Return_Arrival_Time = "11:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 2, Return_Arrival_Time = "12:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 3, Return_Arrival_Time = "12:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 4, Return_Arrival_Time = "14:45" });
            retArrTimes.Add(new BookingsTbl() { Id = 5, Return_Arrival_Time = "14:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 6, Return_Arrival_Time = "15:05" });
            retArrTimes.Add(new BookingsTbl() { Id = 7, Return_Arrival_Time = "16:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 8, Return_Arrival_Time = "16:40" });
            retArrTimes.Add(new BookingsTbl() { Id = 9, Return_Arrival_Time = "17:20" });
            retArrTimes.Add(new BookingsTbl() { Id = 10, Return_Arrival_Time = "17:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 11, Return_Arrival_Time = "18:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 12, Return_Arrival_Time = "18:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 13, Return_Arrival_Time = "19:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 14, Return_Arrival_Time = "19:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 15, Return_Arrival_Time = "21:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 16, Return_Arrival_Time = "22:40" });
            //ViewBags
            ViewBag.outDepAirports = outDepAirports;
            ViewBag.retArrAirports = retArrAirports;
            ViewBag.retDepAirports = retDepAirports;
            ViewBag.outArrAirports = outArrAirports;
            ViewBag.outDepTimes = outDepTimes;
            ViewBag.outArrTimes = outArrTimes;
            ViewBag.retDepTimes = retDepTimes;
            ViewBag.retArrTimes = retArrTimes;
            BookingsTbl booking = flightsBookingsDB.BookingsTbls.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
        [HttpPost]
        public ActionResult EditBooking(BookingsTbl booking)
        {
            List<BookingsTbl> outDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> retArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> outArrAirports = new List<BookingsTbl>();
            List<BookingsTbl> retDepAirports = new List<BookingsTbl>();
            List<BookingsTbl> outDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> outArrTimes = new List<BookingsTbl>();
            List<BookingsTbl> retDepTimes = new List<BookingsTbl>();
            List<BookingsTbl> retArrTimes = new List<BookingsTbl>();

            ////Airports
            outDepAirports.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Airport = "LTN" });
            outDepAirports.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Airport = "MAN" });
            outDepAirports.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Airport = "EDI" });
            retArrAirports.Add(new BookingsTbl() { Id = 0, Return_Arrival_Airport = "LTN" });
            retArrAirports.Add(new BookingsTbl() { Id = 1, Return_Arrival_Airport = "MAN" });
            retArrAirports.Add(new BookingsTbl() { Id = 2, Return_Arrival_Airport = "EDI" });
            outArrAirports.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Airport = "AMS" });
            outArrAirports.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Airport = "CDG" });
            outArrAirports.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Airport = "BCN" });
            outArrAirports.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Airport = "MAD" });
            outArrAirports.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Airport = "PRG" });
            outArrAirports.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Airport = "NCE" });
            outArrAirports.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Airport = "MXP" });
            outArrAirports.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Airport = "GVA" });
            outArrAirports.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Airport = "FCO" });
            retDepAirports.Add(new BookingsTbl() { Id = 0, Return_Departure_Airport = "AMS" });
            retDepAirports.Add(new BookingsTbl() { Id = 1, Return_Departure_Airport = "CDG" });
            retDepAirports.Add(new BookingsTbl() { Id = 2, Return_Departure_Airport = "BCN" });
            retDepAirports.Add(new BookingsTbl() { Id = 3, Return_Departure_Airport = "MAD" });
            retDepAirports.Add(new BookingsTbl() { Id = 4, Return_Departure_Airport = "PRG" });
            retDepAirports.Add(new BookingsTbl() { Id = 5, Return_Departure_Airport = "NCE" });
            retDepAirports.Add(new BookingsTbl() { Id = 6, Return_Departure_Airport = "MXP" });
            retDepAirports.Add(new BookingsTbl() { Id = 7, Return_Departure_Airport = "GVA" });
            retDepAirports.Add(new BookingsTbl() { Id = 8, Return_Departure_Airport = "FCO" });

            ////Times
            outDepTimes.Add(new BookingsTbl() { Id = 0, Outbound_Departure_Time = "9:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 1, Outbound_Departure_Time = "10:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 2, Outbound_Departure_Time = "10:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 3, Outbound_Departure_Time = "11:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 4, Outbound_Departure_Time = "12:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 5, Outbound_Departure_Time = "13:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 6, Outbound_Departure_Time = "13:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 7, Outbound_Departure_Time = "14:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 8, Outbound_Departure_Time = "14:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 9, Outbound_Departure_Time = "15:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 10, Outbound_Departure_Time = "16:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 11, Outbound_Departure_Time = "17:00" });
            outDepTimes.Add(new BookingsTbl() { Id = 12, Outbound_Departure_Time = "17:30" });
            outDepTimes.Add(new BookingsTbl() { Id = 13, Outbound_Departure_Time = "19:00" });
            ////outArrTimes
            outArrTimes.Add(new BookingsTbl() { Id = 0, Outbound_Arrival_Time = "10:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 1, Outbound_Arrival_Time = "10:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 2, Outbound_Arrival_Time = "11:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 3, Outbound_Arrival_Time = "11:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 4, Outbound_Arrival_Time = "12:35" });
            outArrTimes.Add(new BookingsTbl() { Id = 5, Outbound_Arrival_Time = "14:00" });
            outArrTimes.Add(new BookingsTbl() { Id = 6, Outbound_Arrival_Time = "14:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 7, Outbound_Arrival_Time = "14:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 8, Outbound_Arrival_Time = "15:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 9, Outbound_Arrival_Time = "16:20" });
            outArrTimes.Add(new BookingsTbl() { Id = 10, Outbound_Arrival_Time = "16:40" });
            outArrTimes.Add(new BookingsTbl() { Id = 11, Outbound_Arrival_Time = "17:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 12, Outbound_Arrival_Time = "17:25" });
            outArrTimes.Add(new BookingsTbl() { Id = 13, Outbound_Arrival_Time = "18:50" });
            outArrTimes.Add(new BookingsTbl() { Id = 14, Outbound_Arrival_Time = "21:10" });
            outArrTimes.Add(new BookingsTbl() { Id = 15, Outbound_Arrival_Time = "21:15" });
            outArrTimes.Add(new BookingsTbl() { Id = 16, Outbound_Arrival_Time = "23:10" });
            retDepTimes.Add(new BookingsTbl() { Id = 0, Return_Departure_Time = "9:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 1, Return_Departure_Time = "10:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 2, Return_Departure_Time = "11:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 3, Return_Departure_Time = "12:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 4, Return_Departure_Time = "12:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 5, Return_Departure_Time = "14:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 6, Return_Departure_Time = "15:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 7, Return_Departure_Time = "15:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 8, Return_Departure_Time = "16:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 9, Return_Departure_Time = "16:30" });
            retDepTimes.Add(new BookingsTbl() { Id = 10, Return_Departure_Time = "18:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 11, Return_Departure_Time = "19:00" });
            retDepTimes.Add(new BookingsTbl() { Id = 12, Return_Departure_Time = "19:30" });
            retArrTimes.Add(new BookingsTbl() { Id = 0, Return_Arrival_Time = "10:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 1, Return_Arrival_Time = "11:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 2, Return_Arrival_Time = "12:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 3, Return_Arrival_Time = "12:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 4, Return_Arrival_Time = "14:45" });
            retArrTimes.Add(new BookingsTbl() { Id = 5, Return_Arrival_Time = "14:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 6, Return_Arrival_Time = "15:05" });
            retArrTimes.Add(new BookingsTbl() { Id = 7, Return_Arrival_Time = "16:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 8, Return_Arrival_Time = "16:40" });
            retArrTimes.Add(new BookingsTbl() { Id = 9, Return_Arrival_Time = "17:20" });
            retArrTimes.Add(new BookingsTbl() { Id = 10, Return_Arrival_Time = "17:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 11, Return_Arrival_Time = "18:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 12, Return_Arrival_Time = "18:35" });
            retArrTimes.Add(new BookingsTbl() { Id = 13, Return_Arrival_Time = "19:10" });
            retArrTimes.Add(new BookingsTbl() { Id = 14, Return_Arrival_Time = "19:15" });
            retArrTimes.Add(new BookingsTbl() { Id = 15, Return_Arrival_Time = "21:50" });
            retArrTimes.Add(new BookingsTbl() { Id = 16, Return_Arrival_Time = "22:40" });
            //ViewBags
            ViewBag.outDepAirports = outDepAirports;
            ViewBag.retArrAirports = retArrAirports;
            ViewBag.retDepAirports = retDepAirports;
            ViewBag.outArrAirports = outArrAirports;
            ViewBag.outDepTimes = outDepTimes;
            ViewBag.outArrTimes = outArrTimes;
            ViewBag.retDepTimes = retDepTimes;
            ViewBag.retArrTimes = retArrTimes;
            if (!Regex.IsMatch(booking.Name, @"^[a-zA-Z]+$"))
                ModelState.AddModelError("Name", "Your name needs to be alphabetical!");

            if (booking.Age >= 75 || booking.Age < 18)
                ModelState.AddModelError("Age", "The Booker needs to be over 18, and younger than 75!");

            if (!Regex.IsMatch(Convert.ToString(booking.Mobile_Number), "^([0])([0-9]{10})$"))
                ModelState.AddModelError("Mobile_Number", "The Mobile number needs a leading 0 followed by 10 digits!");

            if (!Regex.IsMatch(Convert.ToString(booking.Phone_Number), "^([0-9]{4})(\\s)([0-9]{7})$"))
                ModelState.AddModelError("Phone_Number", "The Telephone number needs 4 digits, followed by a space, followed by the last 7 digits");


            if (!Regex.IsMatch(booking.Email_Address, "^(.+)([0-9]{0,3})(@gmail.com)$"))
                if (!Regex.IsMatch(booking.Email_Address, "^(.+)([0-9]{0,3})(@hotmail.co.uk)$"))
                    ModelState.AddModelError("Email_Address", "The Email needs to be any combination of Letters and Numbers, followed by an @ sign and then gmail.com or hotmail.co.uk");


            if (booking.Number_of_Passengers > 4 || booking.Number_of_Passengers <= 0)
                ModelState.AddModelError("Number_of_Passengers", "The number of passengers needs to be at least 1 but no more than 4");

            if (booking.Number_of_Passengers == 4)
            {
                if (booking.Passenger_1_Age > 75 || booking.Passenger_1_Age < 18)
                {
                    ModelState.AddModelError("Passenger_1_Age", "The 2nd Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (booking.Passenger_2_Age >= 3)
            {
                if (booking.Passenger_2_Age > 75 || booking.Passenger_2_Age < 18)
                {
                    ModelState.AddModelError("Passenger_2_Age", "The 3rd Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (booking.Passenger_3_Age >= 2)
            {
                if (booking.Passenger_3_Age > 75 || booking.Passenger_3_Age < 18)
                {
                    ModelState.AddModelError("Passenger_3_Age", "The 4th Passenger needs to be over 18 and younger than 75!");
                }
            }
            if (ModelState.IsValid)
            {
                flightsBookingsDB.Entry(booking).State = EntityState.Modified;
                flightsBookingsDB.SaveChanges();
                return RedirectToAction("Bookings");
            }
            return View(booking);
        }
        public ActionResult BookingDetails(int id = 0)
        {
            BookingsTbl booking = flightsBookingsDB.BookingsTbls.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }
    }
}
