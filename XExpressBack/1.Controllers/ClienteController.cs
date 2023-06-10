using Microsoft.AspNetCore.Mvc;
using XExpressBack._2.Models.Abstractions;
using XExpressBack._2.Models.Entities;
using XExpressBack._3.Infrastructure.DAO;

namespace XExpressBack._1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ClienteController : Controller
    {
        private IClienteDAO _clienteDAO;
        public ClienteController(IClienteDAO clienteDAO)
        {
            _clienteDAO = clienteDAO;
        }


        [Route("ListaClientes")]
        [HttpGet]
        public IActionResult ListaClientes()
        {
            try
            {
                var response = _clienteDAO.ListaClientes();
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de cargar lista de clientes -> " + ex.Message;
                return BadRequest(ex.Message);
            }
        }

        [Route("BuscarClienteByNombre/{nombre}")]
        [HttpGet]
        public IActionResult BuscarClienteByNombre(string nombre)
        {
            try
            {
                var response = _clienteDAO.BuscarClienteByNombre(nombre);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de buscar clientes por Nombre -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("RegistroCliente")]
        [HttpPost]
        public IActionResult RegistroCliente(ClienteModel clienteModel)
        {
            try
            {
                var response = _clienteDAO.RegistroCliente(clienteModel);
                return Ok(response);

            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de registrar cliente -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("EditarCliente")]
        [HttpPost]
        public IActionResult EditarCliente(ClienteModel clienteModel)
        {
            try
            {
                var response = _clienteDAO.EditarCliente(clienteModel);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de editar cliente -> " + ex.Message;
                return BadRequest(resp);
            }
        }

        [Route("EliminarCliente/{id}")]
        [HttpPost]
        public IActionResult EliminarCliente(int id)
        {
            try
            {
                var response = _clienteDAO.EliminarCliente(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                string resp = "Error al tratar de eliminar cliente -> " + ex.Message;
                return BadRequest(resp);
            }
        }

    }
}
