using System.Collections.Generic;
using AutoMapper;
using Ecommerce.Data;
using Ecommerce.Dtos;
using Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace Ecommerce.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/products
        ///<summary>
        ///Displays all products
        ///</summary>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var productItems = _repository.GetAllProducts();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(productItems));
        }

        //GET api/products/{id}
        ///<summary>
        ///Gets a specific product
        ///</summary>
        ///<param name="id"></param>
        [HttpGet("{id}", Name = "GetProductById")]
        public ActionResult<ProductReadDto> GetProductById(int id)
        {
            var productItem = _repository.GetProductById(id);
            if (productItem != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(productItem));
            }
            return NotFound();
        }

        //POST api/products
        ///<summary>
        ///Adds a new product
        ///</summary>
        [HttpPost]
        public ActionResult<ProductReadDto> AddProduct(ProductAddDto productAddDto)
        {
            var productModel = _mapper.Map<Product>(productAddDto);
            _repository.AddProduct(productModel);
            _repository.SaveChanges();
            var productReadDto = _mapper.Map<ProductReadDto>(productModel);
            // return Ok(productModel);
            return CreatedAtRoute(nameof(GetProductById), new { Id = productReadDto.Id }, productReadDto);
        }

        //PUT api/products/{id}
        ///<summary>
        ///Updates all fields on a specific product
        ///</summary>
        ///<param name="id"></param>
        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, ProductUpdateDto productUpdateDto)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(productUpdateDto, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/products/{id}
        ///<summary>
        ///Updates certain field(s) of a specific product
        ///</summary>
        ///<param name="id"></param>
        [HttpPatch("{id}")]
        public ActionResult PartialProductUpdate(int id, JsonPatchDocument<ProductUpdateDto> patchDoc)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper.Map<ProductUpdateDto>(productModelFromRepo);
            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!TryValidateModel(productToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(productToPatch, productModelFromRepo);

            _repository.UpdateProduct(productModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/products/{id}
        ///<summary>
        ///Deletes a specific product
        ///</summary>
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var productModelFromRepo = _repository.GetProductById(id);
            if (productModelFromRepo == null)
            {
                return NotFound();
            }
            _repository.DeleteProduct(productModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}