using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface ICategoriesInter
    {
        List<Categories> devolverTodos();
        public List<Categories> buscarRegistroPorId(int id);
        public bool agregarRegistro(Categories datos);
        public bool actualizarRegistros(Categories datos);

        public bool eliminarRegistro(int id);

        public Categories buscarRegistroNombre(String datos);
    }
}
