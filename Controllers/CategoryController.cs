using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Models;
using ProductCatalog.Data;
using System.Collections.Generic;

namespace ProductCatalog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDataContext _context;

        public CategoryController(StoreDataContext context)
        {
            _context = context;
        }
        
        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> Get(){
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id){
            return _context.Categories.AsNoTracking().Where( x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProducts(int id){
            return _context.Products.AsNoTracking().Where(x => x.CatergoryId == id).ToList();
        }

        [Route("v1/categories")]
        [HttpPost]
        public Category Post([FromBody]Category category){
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }
        [Route("v1/categories")]
        [HttpPut]
        public Category Put([FromBody]Category category){
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }
        [Route("v1/categoreis")]
        [HttpDelete]
        public Category Delete([FromBody] Category category){
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return category;
        }
    }
}