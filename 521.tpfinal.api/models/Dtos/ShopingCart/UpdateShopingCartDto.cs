using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.api.models.Dtos.ShopingCart
{
    public class UpdateShopingCartDto
    {
        [Required(ErrorMessage = "L'identifiant du produit est requis")]
        required public Guid ProductId { get; set; }
        [Required(ErrorMessage = "La quantité est requise")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être au moins 1")]
        required public int Quantity { get; set; }
    }
}