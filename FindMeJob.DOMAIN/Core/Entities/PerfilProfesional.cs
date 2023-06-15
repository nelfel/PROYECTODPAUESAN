using System;
using System.Collections.Generic;

namespace FindMeJob.DOMAIN.Core.Entities;

public partial class PerfilProfesional
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public string? Descripcion { get; set; }

    public bool? Estado { get; set; }

    public virtual Usuario? Usuario { get; set; }
}
