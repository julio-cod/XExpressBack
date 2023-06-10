using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XExpressBack._2.Models.Abstractions;
using XExpressBack._2.Models.Entities;
using XExpressBack._3.Infrastructure.Context;

namespace XExpressBack._3.Infrastructure.DAO
{
    public class ClienteDAO : IClienteDAO
    {
        private AppDbContext _context;

        public ClienteDAO(AppDbContext context)
        {
            _context = context;
        }

        public ResponseRequest ListaClientes()
        {
            ResponseRequest resutl = new ResponseRequest();
            try
            {
                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Lista de clientes";
                resutl.Data = _context.Clientes.ToList();
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al buscar lista de clientes " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }

        }

        public ResponseRequest BuscarClienteByNombre(string nombre)
        {
            ResponseRequest resutl = new ResponseRequest();
            try
            {
                var Clientes = from e in _context.Clientes
                               where EF.Functions.Like(e.Nombre, "%" + nombre + "%")
                               select e;

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Lista de clientes";
                resutl.Data = Clientes;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al buscar lista de clientes " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest RegistroCliente(ClienteModel clienteModel)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                _context.Clientes.Add(clienteModel);
                _context.SaveChanges();

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Cliente Guardado";
                resutl.Data = clienteModel;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de registrar cliente " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest EditarCliente(ClienteModel clienteModel)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                _context.Entry(clienteModel).State = EntityState.Modified;
                _context.SaveChanges();

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Cliente editado con exito";
                resutl.Data = clienteModel;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de editar cliente " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest EliminarCliente(int id)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(p => p.Id == id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                    resutl.Operacion = "Exitosa";
                    resutl.Mensaje = "Cliente eliminado con exito";
                    resutl.Data = id;

                }
                else
                {
                    resutl.Operacion = "Fallida";
                    resutl.Mensaje = "No se pudo eliminar cliente";
                    resutl.Data = id;
                }
                return resutl;


            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de eliminar cliente " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }

        }
    }
}
