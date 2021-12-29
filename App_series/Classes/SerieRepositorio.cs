using System;
using System.Collections.Generic;
using App_series.Interfaces;


namespace App_series
{
    public class SerieRepositorio : IRepositorio<Series>
    {

        private List<Series> ListaSeries = new List<Series>();
        public void Atualizada(int id, Series objeto)
        {
            ListaSeries[id] = objeto;
        }

        public void Exclue(int id)
        {
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
           ListaSeries[id].Exclui();
        }

        public void Insere(Series objeto)
        {
            ListaSeries.Add(objeto);
        }

        public List<Series> lista()
        {
           return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }

       
    }
}