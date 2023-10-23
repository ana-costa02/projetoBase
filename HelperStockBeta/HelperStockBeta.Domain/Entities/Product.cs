using HelperStockBeta.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperStockBeta.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Relacionamento com categoria

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidationDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            //construtor utilizado para fazer update
            DomainExceptionValidation.When(id < 0, "invalid negative values for id");
            ValidationDomain(name, description, price, stock, image);
        }

        private void ValidationDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "invalid name, name is required");
            DomainExceptionValidation.When(name.Length < 3, "invalid short name, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "invalid description, description is required");
            DomainExceptionValidation.When(description.Length < 5, "invalid short description, minimum 5 characters");
            DomainExceptionValidation.When(price < 0, "invalid negative values for price");
            DomainExceptionValidation.When(stock < 0, "invalid negative values for stock");
            DomainExceptionValidation.When(image.Length > 250, "invalid long URL, maximum 250 characters");
            
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
        public void Update(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidationDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }

}
