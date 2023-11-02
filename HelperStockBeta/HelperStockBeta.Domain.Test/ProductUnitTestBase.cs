using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using HelperStockBeta.Domain.Entities;
using Newtonsoft.Json.Linq;

namespace HelperStockBeta.Domain.Test
{
	public class ProductUnitTestBase
	{
		#region "Casos de Testes Positivos"
		[Fact(DisplayName = "Product parameters not null")]

		public void CreateProduct_WithValidParemeters_ResultValid()
		{
			Action action = () => new Product( 1,"Product Test", "description", 1 , 1, "https://via.placeholder.com/150");
			action.Should().NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();
		}

		#endregion

		#region "Casos de Testes Negativos"

		[Fact(DisplayName = "Id negative exception.")]
		public void CreateProduct_NegativeParameterId_ResultException()
		{
			Action action = () => new Product(-1, "Product Teste", "description", 1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid negative values for id.");
		}

		[Fact(DisplayName = "Product name is null")]
		public void CreateProduct_NameParameterNull_ResultException()
		{
			Action action = () => new Product(1, null, "description", 1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid name, name is required.");
		}

		[Fact(DisplayName = "Name is short for Product.")]
		public void CreateProduct_NameParameterShort_ResultException()
		{
			Action action = () => new Product(1, "Pr", "description", 1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid short names, minimum 3 characteres.");
		}

		[Fact(DisplayName = "Product description is null")]
		public void CreateProduct_DescriptionParameterNull_ResultException()
		{
			Action action = () => new Product(1, "product test", null, 1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid description, description is required.");
		}


		[Fact(DisplayName = "Description short for Product.")]
		public void CreateProduct_DescriptionParameterShort_ResultException()
		{
			Action action = () => new Product(1, "Product test", "desc", 1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid short descriptions, minimum 5 characters.");
		}

		[Fact(DisplayName = "Product price is negative")]
		public void CreateProduct_PriceParameterNegative_ResultException()
		{
			Action action = () => new Product(1, "Product test", "description", -1, 1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid negative values for price.");
		}

		[Fact(DisplayName = "Product stock is negative")]
		public void CreateProduct_StockParameterNegative_ResultException()
		{
			Action action = () => new Product(1, "Product test", "description", 1, -1, "https://via.placeholder.com/150");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid negative values for stock.");
		}

		[Fact(DisplayName = "Product image is long")]
		public void CreateProduct_ImageParameterLong_ResultException()
		{
			Action action = () => new Product(1, "Product test", "description", 1, 1, "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
			action.Should()
				.Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>()
				.WithMessage("Invalid long URL, maximum 250 characteres.");
		}
		#endregion

	}
}
