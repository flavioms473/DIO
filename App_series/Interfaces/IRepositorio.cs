using System.Collections.Generic;

namespace App_series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> lista();
         T RetornaPorId(int id);
         void Insere(T entidade);
         void Exclue(int id);
         void Atualizada(int id, T entidade);
         int ProximoId();

    }
}