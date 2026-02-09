using System;
using System.Collections.Generic;

namespace AgendaAcademicaApi.Models;

public partial class Actividad
{
    public int IdActividad { get; set; }

    public string NombreActividad { get; set; } = null!;

    public DateOnly FechaEntrega { get; set; }

    public TimeOnly HoraEntrega { get; set; }

    public string TipoActividad { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public decimal? Calificacion { get; set; }

    public decimal PuntosMaximos { get; set; }

    public int IdClase { get; set; }

    public virtual Clase IdClaseNavigation { get; set; } = null!;
}
