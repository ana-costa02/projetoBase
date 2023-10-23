using HelperStockBeta.Domain.Entities;
using FluentAssertions;
using System.Xml.Linq;

namespace HelperStockBeta.Domain.Test
{
    public class CategoryUnitTestBase
    {

        #region Caso de testes negativos
        [Fact(DisplayName = "Id negative exception")]
        public void CreateCategory_NegativeParameterId_ResultException()
        {
            Action action = () => new Category(-1, "Categoria teste");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Identification is positive values!");
        }
        

        [Fact(DisplayName = "Name is Category null")]
        public void CreateCategory_NameParameterNull_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required!");

        }

        [Fact(DisplayName = " short name for this category")]
        public void CreateCategory_NameParameterShort_ResultException()
        {
            Action action = () => new Category(1, "ca");
            action.Should()
                .Throw<HelperStockBeta.Domain.Validation.DomainExceptionValidation>().WithMessage("Name is minimum 3 charecters");

        }
        #endregion

        #region Caso de testes positivos
        [Fact(DisplayName = "Category Name is not null")]
        public void CreateCategory_WithValidParameters_ResultValid()
        {
            Action action = () => new Category(1, "Categoria teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        [Fact(DisplayName = "Category no present id parameter")]
        public void CreateCategory_IdParametersLess_ResultValid()
        {
            Action action = () => new Category("Categoria teste");
            action.Should()
                .NotThrow<HelperStockBeta.Domain.Validation.DomainExceptionValidation>();

        }
        #endregion
    }
}