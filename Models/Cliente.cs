using System;
using System.ComponentModel.DataAnnotations; // Importante
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_ABM.Models
{
  public class Cliente
  {
    public int Id { get; set; }
    public string Nombre { get; set; }
  }
}
