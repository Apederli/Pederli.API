using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Pederli.API.Filters;
using Pederli.API.ViewModel;
using Pederli.Entity;
using Pederli.Service.Abstract;

namespace Pederli.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products =await _productService.GetList();

            return Ok(products);
        }
        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);

            return Ok(_mapper.Map<Product>(product));
        }

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Save(ProductViewModel productView)
        {
            var addProduct =await _productService.Add(_mapper.Map<Product>(productView));

            return Created(String.Empty, _mapper.Map<ProductViewModel>(addProduct));

        }

        [HttpPut]
        public IActionResult Update(ProductViewModel productView )
        {
            var updatedProduct = _productService.Update(_mapper.Map<Product>(productView));

            return NoContent();
        }

        [ServiceFilter(typeof(NotFoundFilter))]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id).Result;

            _productService.Delete(product);

            return NoContent();
        }

    }
}
