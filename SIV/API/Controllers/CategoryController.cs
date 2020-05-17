using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Dto;
using Services.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService serviceCategory;

        public CategoryController(ICategoryService categoryService)
        {
            serviceCategory = categoryService;
        }

        [HttpGet("{tenantId}")]
        public IActionResult Get(int tenantId)
        {
            try
            {
                return Ok(serviceCategory.Filter(tenantId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{tenantId}/{categoryId}")]
        public IActionResult Get(int tenantId, int categoryId)
        {
            try
            {
                var category = serviceCategory.FindOne(tenantId, categoryId);
                if (category == null) return BadRequest("Id no encontrado");
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost, Route("[action]")]
        public IActionResult Post(CategoryDtoInput categoryIntput)
        {
            try
            {
                var category = serviceCategory.Create(categoryIntput);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut, Route("[action]")]
        public IActionResult Put(CategoryDtoInput categoryIntput)
        {
            try
            {
                var category = serviceCategory.Update(categoryIntput);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete, Route("[action]")]
        public IActionResult Delete(CategoryDtoInput categoryIntput)
        {
            try
            {
                var category = serviceCategory.Delete(categoryIntput); 
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}