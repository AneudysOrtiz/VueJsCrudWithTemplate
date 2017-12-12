using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueJsCrudWithTemplate.Models
{
    public class DataModel:DbContext
    {
        public DataModel()
        {

        }

        public DataModel(DbContextOptions<DataModel> options) : base(options)
        {

        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Marca> Marcas { get; set; }


    }
}
