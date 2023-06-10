using Microsoft.AspNetCore.Mvc;
using XExpressBack._2.Models.Abstractions;
using XExpressBack._2.Models.Entities;

namespace XExpressBack._1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class DireccionController : Controller
    {
        private IDireccionDAO _direccionDAO;
        public DireccionController(IDireccionDAO direccionDAO)
        {
            _direccionDAO = direccionDAO;
        }


        [Route("ListaDirecciones")]
        [HttpGet]
        public IActionResult ListaDirecciones()
        {
            try
            {
                var response = _direccionDAO.ListaDirecciones();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de cargar lista de Direcciones -> " + ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Route("BuscarDireccionesByIdCliente/{id}")]
        [HttpGet]
        public IActionResult BuscarDireccionesByIdCliente(int id)
        {
            try
            {
                var response = _direccionDAO.BuscarDireccionesByIdCliente(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de buscar direccion por Id -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("BuscarDireccionesByDNICliente/{dni}")]
        [HttpGet]
        public IActionResult BuscarDireccionesByDNICliente(string dni)
        {
            try
            {
                var response = _direccionDAO.BuscarDireccionesByDNICliente(dni);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de buscar direccion por DNI del Cliente -> " + ex.Message;
                return BadRequest(resp);
            }
        }


        [Route("RegistroDireccion")]
        [HttpPost]
        public IActionResult RegistroDireccion(DireccionModel direccionModel)
        {
            try
            {
                var response = _direccionDAO.RegistroDireccion(direccionModel);
                return Ok(response);

            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de registrar direccion -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("EditarDireccion")]
        [HttpPost]
        public IActionResult EditarDireccion(DireccionModel direccionModel)
        {
            try
            {
                var response = _direccionDAO.EditarDireccion(direccionModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de editar direccion -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("EliminarDireccion/{id}")]
        [HttpPost]
        public IActionResult EliminarDireccion(int id)
        {
            try
            {
                var response = _direccionDAO.EliminarDireccion(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de eliminar direccion -> " + ex.Message;
                return BadRequest(resp);
            }
        }
    }
}
