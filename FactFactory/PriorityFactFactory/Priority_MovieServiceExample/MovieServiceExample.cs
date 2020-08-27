using GetcuReone.FactFactory.Entities;
using GetcuReone.FactFactory.Interfaces;
using GetcuReone.FactFactory.Priority;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Priority_MovieServiceExample.Entities;
using Priority_MovieServiceExample.Facts;
using System.Collections.Generic;
using System.Linq;

namespace Priority_MovieServiceExample
{
    [TestClass]
    public class MovieServiceExample
    {
        List<User> UserDB;

        List<Movie> MovieDB;

        List<Discount> DiscountDB;

        FactRuleCollection Rules;

        PriorityFactFactory Factory;

        [TestInitialize]
        public void Initialize()
        {
            UserDB = new List<User>
            {
                new User { Id = 1, Email = "john_cornero@example.com", Name = "John Cornero"},
                new User { Id = 2, Email = "liza_famez@example.com", Name = "Liza Famez"},
                new User { Id = 3, Email = "judy_gonzalez@example.com", Name = "Judy Gonzalez"},
            };

            MovieDB = new List<Movie>
            {
                new Movie { Id = 1, Name = "My Hero Academia: Heroes Rising", Cost = 11, },
                new Movie { Id = 2, Name = "Bad Boys for Life", Cost = 12, },
                new Movie { Id = 3, Name = "Bloodshot", Cost = 13, },
            };

            DiscountDB = new List<Discount>
            {
                new Discount { Id = 1, MovieDiscount = 5, MovieId = 1, UserId = 3 },
                new Discount { Id = 2, MovieDiscount = 4, MovieId = 2, UserId = 2 },
                new Discount { Id = 3, MovieDiscount = 3, MovieId = 3, UserId = 1 },
            };

            Rules = new FactRuleCollection
            {
                // If we have a user, then we can find out his email.
                (UserFact fact) => new UserEmailFact(fact.Value.Email),

                // If we have an email, then we can recognize the user.
                (UserEmailFact fact) => new UserFact(UserDB.Single(user => user.Email == fact.Value)),

                // If we have a movie ID, you can find a movie.
                (MovieIdFact fact) => new MovieFact(MovieDB.Single(movie => movie.Id == fact.Value)),

                // If we have a movie, you can find a movie ID.
                (MovieFact fact) => new MovieIdFact(fact.Value.Id),

                // If we have a user and a movie, then we can add a user discount amount.
                (UserFact userFact, MovieFact movieFact) =>
                {
                    int result = 0;

                    var dicounts = DiscountDB.Where(dicount => dicount.UserId == userFact.Value.Id && dicount.MovieId == movieFact.Value.Id).ToList();

                    if (dicounts != null)
                    {
                        foreach(var dicount in dicounts)
                        {
                            result += dicount.MovieDiscount;
                        }

                        if (result > movieFact.Value.Cost)
                            result = movieFact.Value.Cost;
                    }

                    return new MovieDiscountFact(result);
                },

                // Let's create a higher priority rule. And add the condition that if we have John, then everything should be free for him
                (Priority1 p, UserFact userFact, MovieFact movieFact, UserEmailFact email) =>
                {
                    if (email == "john_cornero@example.com")
                        return new MovieDiscountFact(movieFact.Value.Cost);

                    int result = 0;

                    var dicounts = DiscountDB.Where(dicount => dicount.UserId == userFact.Value.Id && dicount.MovieId == movieFact.Value.Id).ToList();

                    if (dicounts != null)
                    {
                        foreach(var dicount in dicounts)
                        {
                            result += dicount.MovieDiscount;
                        }

                        if (result > movieFact.Value.Cost)
                            result = movieFact.Value.Cost;
                    }

                    return new MovieDiscountFact(result);
                },

                // If we have a movie and a discount size, then we can calculate the cost of the movie.
                (MovieFact movieFact, MovieDiscountFact movieDiscountFact) => new MoviePurchasePriceFact(movieFact.Value.Cost - movieDiscountFact.Value),
            };

            Factory = new PriorityFactFactory(GetPriorityFacts);
            Factory.Rules.AddRange(Rules);
        }

        private IEnumerable<IFact> GetPriorityFacts()
        {
            return new List<IFact>
            {
                new Priority1(),
                new Priority2(),
            };
        }

        [TestMethod]
        [Description("Calculate the cost of a 'My Hero Academia: Heroes Rising' movie for a 'John Cornero' user.")]
        public void CalculatingCostBuyingMovie_2()
        {
            // We have information about the user's mail and the identifier of the film, what he wants to buy.
            string email = "john_cornero@example.com";
            int movieId = 1;

            // Let's tell the factory what we know
            Factory.Container.Add(new UserEmailFact(email));
            Factory.Container.Add(new MovieIdFact(movieId));

            // We ask the factory to calculate the cost of buying a movie for our user.
            int price = Factory.DeriveFact<MoviePurchasePriceFact>().Value;

            // For this user, the discount for this movie is not configured. Therefore we expect full value.
            Assert.AreEqual(0, price, "Everything should be free for John.");
        }
    }
}
