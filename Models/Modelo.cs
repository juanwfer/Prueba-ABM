using System;
using System.ComponentModel.DataAnnotations; // Importante
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_ABM.Models
{
  public class Modelo
  {

    public Modelo()
    {

    }

    public Modelo(string nombre, int marca, string descripcion="")
    {
      Nombre = nombre;
      Descripcion = descripcion;
      MarcaId = marca;
    }

    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    [ForeignKey("Marca")]
    public int MarcaId { get; set; }

    public virtual Marca Marca { get; set; }
  }
}
