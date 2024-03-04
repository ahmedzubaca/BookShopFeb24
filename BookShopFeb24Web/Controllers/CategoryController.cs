using BookShop.DataAcess.Data;
using BookShop.DataAcess.Repository.IRepository;
using BookShop.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace BookShopFeb24Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly ApplicationDbContext db;
        public CategoryController(ICategoryRepository categoryRepository, ApplicationDbContext db )
        {
            this.categoryRepository = categoryRepository;
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = categoryRepository.GetAll().ToList();            
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public IActionResult Get(Guid id) 
        {
            var category = categoryRepository.Get(x => x.CategoryId == id);
            return Ok(category);
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            categoryRepository.Add(category);
            categoryRepository.Save();
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] Category category)
        {
            var categoryDB = categoryRepository.Get(x => x.CategoryId == id);
            if(categoryDB == null)
            {
                return NotFound();
            }
            
            categoryDB.Name = category.Name;
            categoryDB.DisplayOrder = category.DisplayOrder;

            categoryRepository.Update(categoryDB);
            categoryRepository.Save();
            return Ok(categoryDB);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var categoryDb = categoryRepository.Get(x => x.CategoryId == id);
            if(categoryDb == null)
            {
                return NotFound();
            }

            categoryRepository.Remove(categoryDb);
            categoryRepository.Save();
            return Ok(categoryDb);
        }
   }
}
