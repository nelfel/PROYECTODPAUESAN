using System;
using System.Collections.Generic;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class OfertaTrabajo
{
    public int Id { get; set; }

    public string? Titulo { get; set; }

    public string? Descripcion { get; set; }

    public int? EmpresaId { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime? FechaCaducidad { get; set; }

    public virtual Empresa? Empresa { get; set; }

    public virtual ICollection<Postulacion> Postulacion { get; set; } = new List<Postulacion>();
}
