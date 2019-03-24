using System;
using System.ComponentModel.DataAnnotations; // Importante
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_ABM.Models
{
  public class Vendedor
  {
    public int Id { get; set; }
    public string Nombre { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Sueldo { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    public decimal PorcentajeComision { get; set; }
  }
}
