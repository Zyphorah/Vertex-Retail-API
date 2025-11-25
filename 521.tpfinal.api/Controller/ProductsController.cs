using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using _521.tpfinal.api.Models.Constance;

namespace _521.tpfinal.api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(Services.Product.Interfaces.IProductService productService) : ControllerBase
    {
        private readonly Services.Product.Interfaces.IProductService _productService = productService;

        [HttpGet]
        [AllowAnonymous]
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
        [AllowAnonymous]
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
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await this._productService.Add(productDto);
                return StatusCode(201, new { message = "Produit ajouté avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, models.Dtos.Product.ProductDto productDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (productDto.Price <= 0)
                {
                    return BadRequest(new { error = "Le prix doit être supérieur à 0" });
                }

                if (productDto.Stock < 0)
                {
                    return BadRequest(new { error = "Le stock ne peut pas être négatif" });
                }

                productDto.Id = id;
                await this._productService.Update(productDto);
                return Ok(new { message = "Produit mis à jour avec succès" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var product = await this._productService.GetById(id);
                if (product == null)
                {
                    return NotFound(new { message = "Produit non trouvé" });
                }
                
                var success = await this._productService.Delete(product);
                if (!success)
                {
                    return BadRequest(new { message = "Erreur lors de la suppression du produit" });
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