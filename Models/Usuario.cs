using System;
using System.Collections.Generic;

namespace AgendaAcademicaApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public virtual ICollection<Clase> Clases { get; set; } = new List<Clase>();
}
