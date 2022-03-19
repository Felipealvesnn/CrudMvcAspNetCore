using MacorattiMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.Domain.Entitites
{
    public sealed class Category: Entity
    {
       
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidarODomain(name);
        }
        public Category(int id, string name)
        {
            DommainValidacao.Quando(id < 0, "Id invalido");
            Id = id;
            ValidarODomain(name);
        }
        public void Atualizar(string nome) {

            ValidarODomain(nome);
        }

        public ICollection<Product> Produt { get; set; }

        private void ValidarODomain(string name) {
            DommainValidacao.Quando(string.IsNullOrEmpty(name), "invalid name");
            DommainValidacao.Quando(name.Length<3, "invalid name, muito pequeno, no minimo 3 letras");

            Name = name;
        }

    }
}
