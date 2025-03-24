using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface ISuppliersInter
    {
        List<Suppliers> devolverTodos();
        public List<Suppliers> buscarRegistroPorId(int id);
        public bool agregarRegistro(Suppliers datos);
        public bool actualizarRegistros(Suppliers datos);

        public bool eliminarRegistro(int id);

        public Suppliers buscarRegistroNombre(string datos);
    }
}
