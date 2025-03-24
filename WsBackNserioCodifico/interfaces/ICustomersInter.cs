using WsBackNserioCodifico.Modelos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WsBackNserioCodifico.interfaces
{
    public interface ICustomersInter
    {
        List<Customers> devolverTodos();
    
        public bool agregarRegistro(Customers datos);
        public bool actualizarRegistros(Customers datos);

        public bool eliminarRegistro(int id);

        public List<Customers> buscarRegistroPorId(int id);
        public Customers buscarRegistroNombre(string datos);

        public List<Customers> devolverFecOrdenPosOrden(int cust, Date fechaOrden, Date fechaPosOrden);
    }
}
