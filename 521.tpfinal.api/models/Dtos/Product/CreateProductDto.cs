using System.ComponentModel.DataAnnotations;

public class CreateProductDto
{
    [Required(ErrorMessage = "Le nom du produit est requis")]
    [StringLength(200, ErrorMessage = "Le nom du produit ne peut pas dépasser 200 caractères")]
    required public string Name { get; set; }
    [Required(ErrorMessage = "La description du produit est requise")]
    [StringLength(1000, ErrorMessage = "La description du produit ne peut pas dépasser 1000 caractères")]
    required public string Description { get; set; }
    [Required(ErrorMessage = "Le prix du produit est requis")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Le prix du produit doit être supérieur à 0")]
    required public decimal Price { get; set; }
    [Required(ErrorMessage = "La catégorie du produit est requise")]
    required public string Category { get; set; }
    [Required(ErrorMessage = "Le stock du produit est requis")]
    [Range(0, int.MaxValue, ErrorMessage = "Le stock du produit ne peut pas être négatif")]
    required public int Stock { get; set; }
}