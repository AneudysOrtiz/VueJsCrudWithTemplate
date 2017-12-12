using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJsCrudWithTemplate.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        public string Chasis { get; set; }

        public string MarcaNombre { get; set; }

        public int MarcaId { get; set; }

        public string Color { get; set; }

        public string ModeloNombre { get; set; }

        public int ModeloId { get; set; }

        public string Ano { get; set; }

    }
}
