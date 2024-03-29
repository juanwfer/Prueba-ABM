﻿using System;
using System.ComponentModel.DataAnnotations; // Importante
using System.ComponentModel.DataAnnotations.Schema;

namespace Prueba_ABM.Models
{
  public class Venta
  {
    public int Id { get; set; } // NOTA: preguntar cómo hacer una PK a partir de las 3 FK que usa.

    [ForeignKey("Auto")]
    public int AutoId { get; set; }
    public Auto Auto { get; set; }

    [ForeignKey("Cliente")]
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }

    [ForeignKey("Vendedor")]
    public int VendedorId { get; set; }
    public Vendedor Vendedor { get; set; }

    public DateTime Fecha { get; set; }
  }
}
