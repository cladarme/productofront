﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WSProducto.Models
{
    public partial class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public decimal? Costo { get; set; }
    }
}
