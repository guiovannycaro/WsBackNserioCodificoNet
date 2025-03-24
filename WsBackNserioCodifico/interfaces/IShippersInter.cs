using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IShippersInter
    {
        List<Shippers> devolverTodos();
        public List<Shippers> buscarRegistroPorId(int id);
        public bool agregarRegistro(Shippers datos);
        public bool actualizarRegistros(Shippers datos);

        public bool eliminarRegistro(int id);

        public Shippers buscarRegistroNombre(string datos);
    }
}
