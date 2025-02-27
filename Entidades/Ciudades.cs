﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SIMED.Models
{
    public partial class Ciudades
    {
        public Ciudades()
        {
            Barrios = new HashSet<Barrios>();
        }

        public int IdCiudad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Barrios> Barrios { get; set; }
    }
}
