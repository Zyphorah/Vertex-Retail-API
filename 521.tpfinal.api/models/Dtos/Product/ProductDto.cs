using System.ComponentModel.DataAnnotations;

namespace _521.tpfinal.api.models.Dtos.Product
{
    public class ProductDto
    {
        [Required(ErrorMessage = "L'ID du produit est requis")]
        public required Guid Id { get; set; }

        [Required(ErrorMessage = "Le nom du produit est requis")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Le nom doit contenir entre 3 et 100 caractères")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La description est requise")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La description doit contenir entre 10 et 500 caractères")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Le prix est requis")]
        [Range(0.01, 999999, ErrorMessage = "Le prix doit être supérieur à 0")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "La catégorie est requise")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "La catégorie doit contenir entre 2 et 50 caractères")]
        public required string Category { get; set; }

        [Required(ErrorMessage = "La quantité en stock est requise")]
        [Range(0, 999999, ErrorMessage = "Le stock ne peut pas être négatif")]
        public required int Stock { get; set; }
    }
}