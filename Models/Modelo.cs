using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_ABM.Models
{
  public class Modelo
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public virtual Marca Marca { get; set; }
  }
}
