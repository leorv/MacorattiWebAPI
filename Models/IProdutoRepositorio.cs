using System.Collections.Generic;

namespace NetCoreWebAPI.Models
{
    public interface IProdutoRepositorio
    {
        IEnumerable<Produto> GetAll();
        Produto Get(int id);
        Produto Add(Produto produto);
        bool Update(Produto produto);
        void Remove(int id);
    }
}
