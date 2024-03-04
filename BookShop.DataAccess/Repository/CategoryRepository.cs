using BookShop.DataAcess.Data;
using BookShop.DataAcess.Repository.IRepository;
using BookShop.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAcess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            this.db = db;
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Category category)
        {
            db.Categories.Update(category);           
        }
    }
}
