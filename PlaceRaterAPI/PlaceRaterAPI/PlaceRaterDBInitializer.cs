using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceRaterAPI
{
    public class PlaceRaterDBInitializer : DropCreateDatabaseAlways<PlaceRaterContext>
    {
        protected override void Seed(PlaceRaterContext context)
        {
            /* ---------------- Seed Categories ---------------- */
            IList<Category> defaultCategories = new List<Category>();

            defaultCategories.Add(new Category() { Name = "Monumento" });
            defaultCategories.Add(new Category() { Name = "Praia" });
            defaultCategories.Add(new Category() { Name = "Hotéis" });
            defaultCategories.Add(new Category() { Name = "Ilha Tropical" });
            defaultCategories.Add(new Category() { Name = "Parque Nacional" });
            defaultCategories.Add(new Category() { Name = "Montanha" });
            defaultCategories.Add(new Category() { Name = "Bosque" });
            defaultCategories.Add(new Category() { Name = "Floresta" });
            defaultCategories.Add(new Category() { Name = "Sítio Histórico" });
            defaultCategories.Add(new Category() { Name = "Zoológico" });
            defaultCategories.Add(new Category() { Name = "Museu" });
            defaultCategories.Add(new Category() { Name = "Galeria de Arte" });
            defaultCategories.Add(new Category() { Name = "Jardim Botânico" });
            defaultCategories.Add(new Category() { Name = "Edifício/Estrutura" });
            defaultCategories.Add(new Category() { Name = "Parque Temático" });
            defaultCategories.Add(new Category() { Name = "Trem Histórico" });
            defaultCategories.Add(new Category() { Name = "Miradouro" });

            /* ---------------- Seed Places ---------------- */
            IList<Image> defaultImages = new List<Image>();

            defaultImages.Add(new Image() { Url = "https://buziosturismo.com/wp-content/uploads/cache/images/Cristo-Redentor-11/Cristo-Redentor-11-2432722836.jpg" });
            defaultImages.Add(new Image() { Url = "https://novayork.com/sites/default/files/estatua_da_liberdade_nyc.jpg" });
            defaultImages.Add(new Image() { Url = "https://www.vamostrilhar.com.br/wp-content/uploads/2014/02/sobre-o-pc3a3o-de-ac3a7ucar-caminhadas-ecologicas-rj.jpg" });

            IList<Place> defaultPlaces = new List<Place>();

            defaultPlaces.Add(new Place() { Name = "Cristo Redentor", City = "Rio de Janeiro", State = "RJ", Categories = new List<Category> { defaultCategories[0], defaultCategories[8] }, Images = new List<Image> { defaultImages[0] } });
            defaultPlaces.Add(new Place() { Name = "Estátua da Liberdade", City = "Nova York", State = "NY", Categories = new List<Category> { defaultCategories[0], defaultCategories[8] }, Images = new List<Image> { defaultImages[1] } });
            defaultPlaces.Add(new Place() { Name = "Pão de Açucar", City = "Rio de Janeiro", State = "RJ", Categories = new List<Category> { defaultCategories[5] }, Images = new List<Image> { defaultImages[2] } });

            foreach (Place placeI in defaultPlaces)
            {
                context.Places.Add(placeI);
            }

            context.SaveChanges();



            var user = new User() { Login = "user", HashPass = "fdfsd2313s", Email = "email@email.com", Name = "User 123", Categories = new List<Category> { context.Categories.FirstOrDefault() } };
            context.Users.Add(user);
            var user2 = new User() { Login = "user2", HashPass = "fdfsd2313s", Email = "email@email.com", Name = "User 1234", Categories = new List<Category> { context.Categories.FirstOrDefault() } };
            context.Users.Add(user2);
            var user3 = new User() { Login = "user3", HashPass = "fdfsd2313s", Email = "email@email.com", Name = "User 12345", Categories = new List<Category> { context.Categories.FirstOrDefault() } };
            context.Users.Add(user3);

            var place = context.Places.FirstOrDefault<Place>();
            var rate = new Rate() { User = user, Login = user.Login, Place = place, City = place.City, State = place.State, Stars = 4, Price = 3, Comment = "Lugar legal =P" };
            context.Rates.Add(rate);
            rate = new Rate() { User = user2, Login = user2.Login, Place = place, City = place.City, State = place.State, Stars = 1, Price = 1, Comment = "Lugar Péssimo >=(" };
            context.Rates.Add(rate);
            place = context.Places.ToList()[1];
            rate = new Rate() { User = user2, Login = user2.Login, Place = place, City = place.City, State = place.State, Stars = 1, Price = 1, Comment = "Lugar Péssimo >=(" };
            context.Rates.Add(rate);
            place = context.Places.ToList()[2];
            rate = new Rate() { User = user2, Login = user2.Login, Place = place, City = place.City, State = place.State, Stars = 2, Price = 4, Comment = "Lugar Péssimo >=(" };
            context.Rates.Add(rate);


            context.SaveChanges();

            base.Seed(context);
        }
    }
}
