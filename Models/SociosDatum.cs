using System;
using System.Collections.Generic;

namespace CRUD_MVC_socios_club.Models
{
    /// <summary>
    /// En esta tabla almancenamos los datos de los socios 
    /// </summary>
    public partial class SociosDatum
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? Inscription { get; set; }
        public string? Type { get; set; }
    }
}
