using Microsoft.AspNetCore.Mvc;
namespace APISqlServerMTWDM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        [HttpGet("AlmacenarSQLServer")]
        public string Almacenar(string Nombre, string Domicilio,
            string Correo, int Edad, double Saldo)
        {
            var Almacena = new StorageSQL();
            bool resultado = Almacena.Almacenar(Nombre, Domicilio,
                Correo, Edad, Saldo);
            if (resultado)
                return "Almacenado en SQL Server desde API con .NET Core";
            else
                return "No Almacenado";
        }
        [HttpGet("ConsultarSQLServer")]
        public JsonResult Consultar(int ID)
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.ConsultarRegistro(ID);
            return new JsonResult(Lista);
        }

        [HttpGet("ConsultarTodo")]
        public JsonResult ConsultarTodo()
        {
            var Consulta = new StorageSQL();
            var Lista = Consulta.ConsultarTodo();
            return new JsonResult(Lista);
        }
    }
}