using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IOrdersInter
    {

        List<Orders> devolverTodos();
        public List<Orders> buscarRegistroPorId(int id);
        public bool agregarRegistro(Orders datos);
        public bool actualizarRegistros(Orders datos);

        public bool eliminarRegistro(int id);

        public Orders buscarRegistroNombre(string datos);
    }
}
