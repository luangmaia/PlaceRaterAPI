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
            IList<Place> defaultPlaces = new List<Place>();

            defaultPlaces.Add(new Place() { Name = "Cristo Redentor", City = "Rio de Janeiro", State = "RJ", Categories = new List<Category> { defaultCategories[0], defaultCategories[8] } });
            defaultPlaces.Add(new Place() { Name = "Estátua da Liberdade", City = "Nova York", State = "NY", Categories = new List<Category> { defaultCategories[0], defaultCategories[8] } });

            /* ---------------- Seed Images ---------------- */
            IList<Image> defaultImages = new List<Image>();

            defaultImages.Add(new Image() { Name = defaultPlaces[0].Name, City = defaultPlaces[0].City, State = defaultPlaces[0].State, Url = "https://buziosturismo.com/wp-content/uploads/cache/images/Cristo-Redentor-11/Cristo-Redentor-11-2432722836.jpg", Place = defaultPlaces[0] });
            defaultImages.Add(new Image() { Name = defaultPlaces[1].Name, City = defaultPlaces[1].City, State = defaultPlaces[1].State, Url = "https://novayork.com/sites/default/files/estatua_da_liberdade_nyc.jpg", Place = defaultPlaces[1] });

            foreach (Image image in defaultImages)
            {
                context.Images.Add(image);
            }

            base.Seed(context);
        }
    }
}
