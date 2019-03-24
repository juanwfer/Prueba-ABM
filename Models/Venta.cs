using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_ABM.Models
{
  public class Venta
  {
    public Auto Auto { get; set; }
    public Cliente Cliente { get; set; }
    public Vendedor Vendedor { get; set; }

    public DateTime Fecha { get; set; }
  }
}
