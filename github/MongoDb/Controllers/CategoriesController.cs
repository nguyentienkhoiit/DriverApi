using Microsoft.AspNetCore.Mvc;
using MongoDb.Models;
using MongoDb.Services;

namespace MongoDb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController
    {
        private readonly CategoryServices _categoryServices;

        public CategoriesController(CategoryServices categoryServices)
        {
            this._categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<CategoryDtoResponse>>> GetAll()
        {
            return await _categoryServices.GetAll();
        }

    }
}
