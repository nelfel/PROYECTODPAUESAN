using FindMeJob.API.Entities;
using FindMeJob.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FindMeJob.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmpresaRepository _empresaRepository;

        public LoginController(IUsuarioRepository usuarioRepository, IEmpresaRepository empresaRepository)
        {
            _usuarioRepository = usuarioRepository;
            _empresaRepository = empresaRepository;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var resultUser = await _usuarioRepository.Login(login.correoElectronico, login.Contrasena);
            if (resultUser == null)
            {
                var resultEmpresa = await _empresaRepository.Login(login.correoElectronico, login.Contrasena);
                if (resultEmpresa == null)
                    return BadRequest(resultEmpresa);
                return Ok(resultEmpresa);
            }
            return Ok(resultUser);
        }
    }
}
