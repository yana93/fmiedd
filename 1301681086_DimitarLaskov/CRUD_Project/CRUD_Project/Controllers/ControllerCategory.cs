using CRUD_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Project.Controllers
{
    class ControllerCategory
    {
        private Category category;

        public ControllerCategory()
        { }

        public ControllerCategory(Category category)
        {
            this.category = category;
        }

        public int InsertNewCategory()
        {          
            using(DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var match = from c in db.Categories
                            select new {
                                Id = c.Id,
                                CategoryName = c.CategoryName
                            };

                foreach (var item in match.ToList())
                {
                    if (item.CategoryName == category.CategoryName)
                    {
                        return 0;
                    }
                }

                db.Categories.InsertOnSubmit(category);
                db.SubmitChanges();
                return match.ToList().Last().Id - 1;
            }
        }

        public static object[] LoadAllCategories()
        {
            using (DataClasses1DataContext db = new DataClasses1DataContext())
            {
                var cats = from c in db.Categories
                           select c.CategoryName;

                return cats.ToArray();
            }
        }
    }
}
