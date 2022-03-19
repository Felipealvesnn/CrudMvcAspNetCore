using MacorattiMVC.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacorattiMVC.Domain.Entitites
{
   public sealed class Product: Entity
    {
        
        public string Name { get;private set; }
        public string Description { get;private set; }
        public decimal Price { get;private set; }
        public int Stock { get; private set; }
        public string Image { get;private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidarDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DommainValidacao.Quando (id < 0, "Invalid Id value.");
            Id = id;
            ValidarDomain(name, description, price, stock, image);
        }

        public void Atualizar(string name, string descricao, decimal preco, int estoque, string imagem, int categoryId)
        {
            ValidarDomain(name, descricao, preco, estoque, imagem);
            CategoryId = categoryId;
        }


        private void ValidarDomain(string name, string descricao, decimal preco, int estoque, string imagem) {
            DommainValidacao.Quando(string.IsNullOrEmpty(name), 
                "invalid name");
            DommainValidacao.Quando(name.Length<3, 
                "invalid name");
            DommainValidacao.Quando(string.IsNullOrEmpty(descricao), 
                "invalid descrição");
            DommainValidacao.Quando(descricao.Length < 5,
                "invalid DEscriçãoi");
            DommainValidacao.Quando(preco < 0,
                "invalid price");
            DommainValidacao.Quando(estoque < 0,
                "invalid estoque");
            DommainValidacao.Quando(imagem?.Length > 250,
                "invalid Image");
            Name = name;
            Description = descricao;
            Price = preco;
            Stock = estoque;
            Image = imagem;

        }

        public int CategoryId { get;  set; }
        public Category Category { get;  set; }

    }
}
