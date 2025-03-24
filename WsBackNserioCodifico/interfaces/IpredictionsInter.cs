using static System.Runtime.InteropServices.JavaScript.JSType;
using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IpredictionsInter
    {

        List<Predictions> devolverTodos();

        public bool agregarRegistro(Predictions datos);
        public bool actualizarRegistros(Predictions datos);

        public bool eliminarRegistro(int id);

        public List<Predictions> buscarRegistroPorId(int id);
        public Predictions buscarRegistroNombre(string datos);

        public List<Predictions> devolverFecOrdenPosOrden(int cust, Date fechaOrden, Date fechaPosOrden);

    }
}
