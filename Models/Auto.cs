using System;
using System.ComponentModel.DataAnnotations; // Importante
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_ABM.Models
{
  public class Auto
  {

    public Auto()
    {

    }

    public Auto(decimal precio, int modelo, DateTime fechaAdquisicion)
    {
      Precio = precio;
      ModeloId = modelo;
      FechaAdquisicion = fechaAdquisicion;
    }
    public int Id { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    [DataType(DataType.Date)]
    public DateTime FechaAdquisicion { get; set; }

    [ForeignKey("Modelo")]
    public int ModeloId { get; set; }
    public virtual Modelo Modelo { get; set; }
  }
}
