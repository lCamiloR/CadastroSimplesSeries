using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Domain
{
    class SerieRepositorio : IRepository<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
        public void Atualiza(int id, Serie entidade)
        {
            var s = listaSerie.ElementAtOrDefault(id);
            if (s == null)
            {
                Console.WriteLine("Nehum registro com esse ID.");
                return;
            }
            listaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            var s = listaSerie.ElementAtOrDefault(id);

            if (s != null)
            {
                s.Desativar();
                return;
            }
            Console.WriteLine("Nehum registro com esse ID.");
        }

        public void Insert(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie.ElementAtOrDefault(id);
        }
    }
}
