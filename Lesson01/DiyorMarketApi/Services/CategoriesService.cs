using DiyorMarketApi.Models;

namespace DiyorMarketApi.Services
{
    public class CategoriesService
    {
            static List<Category> Categories = new List<Category>
        {
            new Category
            {
                Id = 1,
                Name = "Drinks",
            },
            new Category
            {
                Id= 2,
                Name = "Chocolate",
            },
            new Category
            {
                Id = 3,
                Name = "Food",
            },
        };
       
    

        public static List<Category> GetCategories()
            => Categories;

        public static Category? GetCategory(int id)
            => Categories.FirstOrDefault(x => x.Id == id);
      

        public static void Create(Category category)
            => Categories.Add(category);

        public static void Update(Category category)
        {
            var categoryToUpdate = Categories.FirstOrDefault(x => x.Id == category.Id);

            if (categoryToUpdate is null)
            {
                return;
            }

            categoryToUpdate.Name = category.Name;
        }

        public static void Delete(int id)
        {
            var category = Categories.FirstOrDefault(x => x.Id == id);

            if (category is not null)
            {
                Categories.Remove(category);
            }
        }
    }
}
