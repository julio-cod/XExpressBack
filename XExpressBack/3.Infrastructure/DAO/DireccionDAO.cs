using Microsoft.EntityFrameworkCore;
using XExpressBack._2.Models.Abstractions;
using XExpressBack._2.Models.Entities;
using XExpressBack._3.Infrastructure.Context;

namespace XExpressBack._3.Infrastructure.DAO
{
    public class DireccionDAO : IDireccionDAO
    {
        private AppDbContext _context;

        public DireccionDAO(AppDbContext context)
        {
            _context = context;
        }

        public ResponseRequest ListaDirecciones()
        {
            ResponseRequest resutl = new ResponseRequest();
            try
            {
                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Lista de Direcciones";
                resutl.Data = _context.Direcciones.ToList();
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al buscar lista de Direcciones " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }

        }

        public ResponseRequest BuscarDireccionesByIdCliente(int id)
        {
            
            ResponseRequest resutl = new ResponseRequest();
            try
            {
                var Direcciones = from e in _context.Direcciones
                               where EF.Functions.Like(e.IdCliente.ToString(),  id.ToString())
                               select e;

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Lista de Direcciones";
                resutl.Data = Direcciones;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al buscar lista de Direcciones " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest BuscarDireccionesByDNICliente(string dni)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                var cliente = _context.Clientes.FirstOrDefault(p => p.DNI == dni);

                var Direcciones = from e in _context.Direcciones
                                  where EF.Functions.Like(e.IdCliente.ToString(), cliente.Id.ToString())
                                  select e;

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Lista de Direcciones";
                resutl.Data = Direcciones;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al buscar lista de Direcciones " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }


        public ResponseRequest RegistroDireccion(DireccionModel direccionModel)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                _context.Direcciones.Add(direccionModel);
                _context.SaveChanges();

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Direccion Guardada";
                resutl.Data = direccionModel;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de registrar direccion " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest EditarDireccion(DireccionModel direccionModel)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                _context.Entry(direccionModel).State = EntityState.Modified;
                _context.SaveChanges();

                resutl.Operacion = "Exitosa";
                resutl.Mensaje = "Direccion editada con exito";
                resutl.Data = direccionModel;
                return resutl;
            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de editar Direccion " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }
        }

        public ResponseRequest EliminarDireccion(int id)
        {

            ResponseRequest resutl = new ResponseRequest();
            try
            {
                var direccion = _context.Direcciones.FirstOrDefault(p => p.Id == id);
                if (direccion != null)
                {
                    _context.Direcciones.Remove(direccion);
                    _context.SaveChanges();
                    resutl.Operacion = "Exitosa";
                    resutl.Mensaje = "Direccion eliminada con exito";
                    resutl.Data = id;

                }
                else
                {
                    resutl.Operacion = "Fallida";
                    resutl.Mensaje = "No se pudo eliminar la direccion";
                    resutl.Data = id;
                }
                return resutl;


            }
            catch (Exception ex)
            {
                resutl.Operacion = "Fallida";
                resutl.Mensaje = "Error al tratar de eliminar direccion " + ex.Message;
                resutl.Data = Array.Empty<string>();
                return resutl;
            }

        }


    }
}
