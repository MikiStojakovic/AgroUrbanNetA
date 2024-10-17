using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController(IGenericRepository<Product> repository) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts([FromQuery]ProductSpecParams prodParams)
        {
            var specification = new ProductSpecification(prodParams);
            
            return await CreatedPagedResult(repository, specification, prodParams.PageIndex, prodParams.PageSize);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var product = await repository.GetByIdAsync(id);

            if (product == null) return NotFound();  

            return product; 
        }
        
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            repository.Add(product);

            if (await repository.SaveAllAsync())
            {
                return CreatedAtAction("GetProduct", new { id = product.Id}, product);
            }

            return BadRequest("Problem creating product");
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateProduct(Guid id, Product product)
        {
            if (product.Id != id || !ProductExist(id))
                return BadRequest("Cannot update this product");

            repository.Update(product);

            if (await repository.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the product");
        }

        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var product = await repository.GetByIdAsync(id);

            if (product == null) return NotFound();

            repository.Delete(product);

            if (await repository.SaveAllAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the product");
        }

        private bool ProductExist(Guid id)
        {
            return repository.Exists(id);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var specification = new BrandSpecification();

            return Ok(await repository.ListAsync(specification));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            var specification = new TypeSpecification();

            return Ok(await repository.ListAsync(specification));
        }
    }
}