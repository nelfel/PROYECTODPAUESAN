using System.ComponentModel.DataAnnotations;

namespace FindMeJob.API.Entities
{
    public class Login
    {
        [Required]
        public string correoElectronico { get; set; }
        [Required]
        public string Contrasena { get; set; }
    }
}
