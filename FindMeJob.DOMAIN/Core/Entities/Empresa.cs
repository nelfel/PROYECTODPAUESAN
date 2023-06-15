using System;
using System.Collections.Generic;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class Empresa
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasena { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Ruc { get; set; }

    public byte[]? Logo { get; set; }

    public virtual ICollection<OfertaTrabajo> OfertaTrabajo { get; set; } = new List<OfertaTrabajo>();
}
