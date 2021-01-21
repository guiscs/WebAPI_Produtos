using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteMercado.Product.Data.Models
{
    public class Produto : Entity
    {
        [Required]
        public string NM_PRODUTO { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal VL_PRODUTO { get; set; }
        [Required]
        public byte[] VB_IMAGEM_ARQUIVO { get; set; }
        [Required]
        public string NM_IMAGEM { get; set; }
        [Required]
        public string DS_TIPO_ARQUIVO { get; set; }
    }
}
