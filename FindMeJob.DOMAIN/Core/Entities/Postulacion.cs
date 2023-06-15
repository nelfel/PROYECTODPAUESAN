using System;
using System.Collections.Generic;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class Postulacion
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? OfertaId { get; set; }

    public DateTime? FechaPostulacion { get; set; }

    public virtual OfertaTrabajo? Oferta { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
