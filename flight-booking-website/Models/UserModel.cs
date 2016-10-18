using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace flight_booking_website.Models
{
    public class UserModel
    {

        [Required]
        //[EmailAddress]
        [StringLength(50)]
        [Display(Name = "Email Address")]
        public string Email { set; get; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(32, MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { set; get; }


        public bool IsValid(string email, string password)
        {
            var crypto = new SimpleCrypto.PBKDF2();
            bool IsValid = false;

            using (var db = new FlightsBookingsDBEntities())
            {
                // retrieve the user according to the email entered
                var user = db.UsersTbls.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    //  and the password is the same as what enterd
                    if (user.Password == crypto.Compute(password, user.Password_Salt))
                    {
                        IsValid = true;
                    }

                }

            }
            return IsValid;
        }
    }
}