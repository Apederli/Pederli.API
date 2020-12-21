using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pederli.API.ViewModel;
using Pederli.Entity;
using Pederli.Service.Abstract;

namespace Pederli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Category> categories = await _categoryService.GetList();
            return Ok(_mapper.Map<IEnumerable<CategoryViewModel>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetById(id);

            return Ok(_mapper.Map<Category>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryViewModel categoryViewModel)
        {
           Category category= await _categoryService.Add(_mapper.Map<Category>(categoryViewModel));

            return Created(String.Empty, _mapper.Map<CategoryViewModel>(category));
        }

        [HttpPut]
        public IActionResult Update(CategoryViewModel categoryViewModel)
        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryViewModel));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Result sayesinde asenkron çağrıldı, async ve await yerine Result methoduda kullanılabilir. 
            var category = _categoryService.GetById(id).Result;
            _categoryService.Delete(category);
            return NoContent();
        }
    }
}
