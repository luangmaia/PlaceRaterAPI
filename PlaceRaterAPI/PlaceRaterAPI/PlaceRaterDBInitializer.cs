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

            foreach (Category category in defaultCategories)
            {
                context.Categories.Add(category);
            }

            base.Seed(context);
        }
    }
}
