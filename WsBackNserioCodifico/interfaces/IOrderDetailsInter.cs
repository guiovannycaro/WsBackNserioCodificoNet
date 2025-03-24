using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IOrderDetailsInter
    {
        List<OrderDetails> devolverTodos();
        public List<OrderDetails> buscarRegistroPorId(int id);
        public bool agregarRegistro(OrderDetails datos);
        public bool actualizarRegistros(OrderDetails datos);

        public bool eliminarRegistro(int id);

        public OrderDetails buscarRegistroNombre(int datos);
        public List<DetailsOrders> BuscarDetailsOrderById(int id);
    }
}
