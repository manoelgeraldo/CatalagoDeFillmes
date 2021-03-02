using System.Collections.Generic;

namespace CatalagoDeFilmes.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void Inserir(T entidade);
         void Excluir(int id);
        void Atualizar(int id, T entidade);
        int ProximoId();
    }
}