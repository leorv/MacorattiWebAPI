using System;
using System.Collections.Generic;

namespace NetCoreWebAPI.Models
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private List<Produto> produtos = new();
        private int nextId = 1;

        public ProdutoRepositorio()
        {
            Add(new Produto { Name = "Guaraná Antártica", Categoria = "Refrigerantes", Preco = 4.59M });
            Add(new Produto { Name = "Suco de Laranja", Categoria = "Sucos", Preco = 5.75M });
            Add(new Produto { Name = "Mostarda Hammer", Categoria = "Condimentos", Preco = 3.90M });
            Add(new Produto { Name = "Molho de Tomate Cepera", Categoria = "Condimentos", Preco = 2.99M });
            Add(new Produto { Name = "Suco de Uva Aurora", Categoria = "Sucos", Preco = 6.50M });
        }

        public Produto Add(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentException("produto");
            }
            produto.Id = nextId++;
            produtos.Add(produto);

            return produto;
            
        }

        public Produto Get(int id)
        {
            return produtos.Find(x => x.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            produtos.RemoveAll(x => x.Id == id);
        }

        public bool Update(Produto produto)
        {
            if (produto == null)
            {
                throw new ArgumentException("produto");
            }

            int index = produtos.FindIndex(x => x.Id == produto.Id);
            if (index == -1)
            {
                return false;
            }

            produtos.RemoveAt(index);
            produtos.Add(produto);

            return true;
        }
    }
}
