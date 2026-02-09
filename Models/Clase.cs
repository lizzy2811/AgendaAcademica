using System;
using System.Collections.Generic;

namespace AgendaAcademicaApi.Models;

public partial class Clase
{
    public int IdClase { get; set; }

    public string NombreClase { get; set; } = null!;

    public string Seccion { get; set; } = null!;

    public int IdUsuario { get; set; }

    public virtual ICollection<Actividad> Actividads { get; set; } = new List<Actividad>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
