using SiteMercado.Product.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace SiteMercado.Product.Data.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
    }
}
