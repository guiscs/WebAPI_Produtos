using System;
using System.ComponentModel.DataAnnotations;

namespace SiteMercado.Product.Data.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            
        }

        public long Id { get; set; }
    }
}
