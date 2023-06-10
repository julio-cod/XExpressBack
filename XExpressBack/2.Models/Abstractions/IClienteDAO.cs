using XExpressBack._2.Models.Entities;

namespace XExpressBack._2.Models.Abstractions
{
    public interface IClienteDAO
    {
        ResponseRequest ListaClientes();
        ResponseRequest BuscarClienteByNombre(string nombre);
        ResponseRequest RegistroCliente(ClienteModel clienteModel);
        ResponseRequest EditarCliente(ClienteModel clienteModel);
        ResponseRequest EliminarCliente(int id);

    }
}
