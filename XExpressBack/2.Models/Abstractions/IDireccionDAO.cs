using XExpressBack._2.Models.Entities;

namespace XExpressBack._2.Models.Abstractions
{
    public interface IDireccionDAO
    {
        ResponseRequest ListaDirecciones();
        ResponseRequest BuscarDireccionesByIdCliente(int id);

        ResponseRequest BuscarDireccionesByDNICliente(string dni);
        ResponseRequest RegistroDireccion(DireccionModel direccionModel);
        ResponseRequest EditarDireccion(DireccionModel direccionModel);
        ResponseRequest EliminarDireccion(int id);

    }
}
