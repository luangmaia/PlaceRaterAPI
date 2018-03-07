using PlaceRaterAPI.UOW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new PlaceRaterContext())
            {
                /*var user = new User() { Login = "user", HashPass = "fdfsd2313s", Email = "email@email.com", Name = "User 123", Categories = new List<Category> { ctx.Categories.FirstOrDefault() } };
                ctx.Users.Add(user);
                var user2 = new User() { Login = "user2", HashPass = "fdfsd2313s", Email = "email@email.com", Name = "User 1234", Categories = new List<Category> { ctx.Categories.FirstOrDefault() } };
                ctx.Users.Add(user2);

                var place = ctx.Places.FirstOrDefault<Place>();
                var rate = new Rate() { User = user, Login = user.Login, Place = place, City = place.City, State = place.State, Stars = 4, Price = 3, Comment = "Lugar legal =P" };
                ctx.Rates.Add(rate);
                rate = new Rate() { User = user2, Login = user2.Login, Place = place, City = place.City, State = place.State, Stars = 1, Price = 1, Comment = "Lugar Péssimo >=(" };
                ctx.Rates.Add(rate);
                place = ctx.Places.ToList()[1];
                rate = new Rate() { User = user2, Login = user2.Login, Place = place, City = place.City, State = place.State, Stars = 1, Price = 1, Comment = "Lugar Péssimo >=(" };
                ctx.Rates.Add(rate);

                ctx.SaveChanges();*/
                Console.WriteLine(ctx.Users.Where(u => u.Login.Equals("user3")).FirstOrDefault().Login);
            }

            using (var unitOfWork = new UnitOfWork(new PlaceRaterContext()))
            {
                /*var places = unitOfWork.Places.SearchByNameCityStatePagination("e", 2, 1);

                foreach (var place in places)
                {
                    Console.WriteLine(place.Name);
                }*/

                Console.WriteLine(unitOfWork.Rates.GetAll().LastOrDefault().Login);

                Console.Read();
            }
        }
    }
}
