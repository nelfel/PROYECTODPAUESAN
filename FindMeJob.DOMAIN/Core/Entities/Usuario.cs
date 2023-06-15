using System;
using System.Collections.Generic;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string? NombreCompleto { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Contrasena { get; set; }

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public string? Dni { get; set; }

    public virtual ICollection<PerfilProfesional> PerfilProfesional { get; set; } = new List<PerfilProfesional>();

    public virtual ICollection<Postulacion> Postulacion { get; set; } = new List<Postulacion>();
}
