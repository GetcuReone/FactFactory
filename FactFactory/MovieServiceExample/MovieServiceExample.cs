using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieServiceExample.Entities;
using System.Collections.Generic;

namespace MovieServiceExample
{
    [TestClass]
    public class MovieServiceExample
    {
        List<User> UserDB = new List<User>
        {
            new User { Id = 1, Email = "john_cornero@example.com", Name = "John Cornero"},
            new User { Id = 2, Email = "liza_famez@example.com", Name = "Liza Famez"},
            new User { Id = 3, Email = "judy_gonzalez@example.com", Name = "Judy Gonzalez"},
        };

        List<Movie> MovieDB = new List<Movie>
        {
            new Movie { Id = 1, Name = "My Hero Academia: Heroes Rising", Cost = 11, },
            new Movie { Id = 2, Name = "Bad Boys for Life", Cost = 12, },
            new Movie { Id = 3, Name = "Bloodshot", Cost = 13, },
        };

        List<Discount> DiscountDB = new List<Discount>
        {
            new Discount { Id = 1, MovieDiscount = 5, MovieId = 1, UserId = 3 },
            new Discount { Id = 2, MovieDiscount = 4, MovieId = 2, UserId = 2 },
            new Discount { Id = 3, MovieDiscount = 3, MovieId = 3, UserId = 1 },
        };

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
