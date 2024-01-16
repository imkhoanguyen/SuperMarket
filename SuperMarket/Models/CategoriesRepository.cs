using CoreBusiness;

namespace SuperMarket.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category {CategoryId = 1, Name = "Rau", Description = "Xanh"},
            new Category {CategoryId = 2, Name = "Trai Cay", Description = "Ve sinh"},
            new Category {CategoryId = 3, Name = "Thit/Ca", Description = "Tuoi"}
        };
        public static List<Category> GetCategories() => _categories;
        public static void AddCategory(Category category)
        {
            int maxId = _categories.Max(c => c.CategoryId);
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }
        public static void DeleteCategory(int id)
        {
            var categoryToDelete = _categories.FirstOrDefault(x=> x.CategoryId == id);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }
        }
        
        public static Category? GetById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x=> x.CategoryId == categoryId);
            if(category != null)
            {
                return category;
            }
            return null;
        }
        
        public static void UpdateCategory(int categoryId, Category category)
        {
            if (category.CategoryId != categoryId) return;
            var categoryToUpdate = _categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }
    }
}
