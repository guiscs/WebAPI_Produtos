using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Product.Business.Models
{
    public class ProdutoViewModel
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IFormFile ImagemUpload { get; set; }
    }
}
