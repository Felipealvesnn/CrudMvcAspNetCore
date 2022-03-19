using FluentAssertions;
using MacorattiMVC.Domain.Entitites;
using MacorattiMVC.Domain.Validation;
using System;
using Xunit;

namespace MacoattiMVC.Domain.Test
{
    public class CategoryUnitTEst1
    {
        [Fact]
        public void CrearCategoria_comParametrosValidos_ResultadoValido()
        {
            Action action = () => new Category(1, " ztegory name");
            action.Should()
                .NotThrow<MacorattiMVC.Domain.Validation.DommainValidacao>();
        }

        [Fact]
        public void CrearCategoria_comNome_Pequeno()
        {
            Action action = () => new Category(1, " c");
            action.Should()
                .Throw<MacorattiMVC.Domain.Validation.DommainValidacao>()
                .WithMessage("Nome muito curto, minuto 3 caracteres");
        }
    }
}
