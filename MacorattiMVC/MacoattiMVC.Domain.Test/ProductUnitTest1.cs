using FluentAssertions;
using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Validation;
using System;
using Xunit;

namespace MacoattiMVC.Domain.Test
{
    public  class ProductUnitTest1
    {
        [Fact]
        public void CrearCategoria_comParametrosValidos_ResultadoValido()
        {
            Action action = () => new Product(1, " ztegory name", "wersdfs", 2,4,"dvcxvbcvbcvbcbcbcvbcvbcvbcvbcvbcbcvbcbcbcvbcvbcbcbvcvbcbvcbcbvc");
            action.Should()
                .NotThrow<MacorattiMVC.Domain.Validation.DommainValidacao>();
        }

    }
}
