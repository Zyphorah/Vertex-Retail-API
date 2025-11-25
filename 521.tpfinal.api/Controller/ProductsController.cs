using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _521.tpfinal.api.Models.Constance;

namespace _521.tpfinal.api.Controller
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController(Services.Product.Interfaces.IProductService productService) : ControllerBase
    {
        private readonly Services.Product.Interfaces.IProductService _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await this._productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var product = await this._productService.GetById(id);
                if (product == null)
                {
                    return NotFound(new { message = "Produit non trouvé" });
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Add(models.Dtos.Product.ProductDto productDto)
        {
            try
            {
                await this._productService.Add(productDto);
                return Ok(new { message = "Produit ajouté avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(models.Dtos.Product.ProductDto productDto)
        {
            try
            {
                await this._productService.Update(productDto);
                return Ok(new { message = "Produit mis à jour avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(models.Dtos.Product.ProductDto productDto)
        {
            try
            {
                var success = await this._productService.Delete(productDto);
                if (!success)
                {
                    return NotFound(new { message = "Produit non trouvé" });
                }
                return Ok(new { message = "Produit supprimé avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }   
}