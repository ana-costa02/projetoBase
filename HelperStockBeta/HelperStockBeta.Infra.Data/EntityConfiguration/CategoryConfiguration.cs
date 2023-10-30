using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperStockBeta.Domain.Entities;

namespace HelperStockBeta.Infra.Data.EntityConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder) 
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category(1, "Material de Escritório"),
                new Category(2, "Tecnologia Eletrônica"),
                new Category(3, "Acessórios e Equipamentos"));
        }
    }
}
