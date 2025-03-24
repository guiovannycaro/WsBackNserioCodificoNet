using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IProductsInter
    {

        List<Products> devolverTodos();
        public List<Products> buscarRegistroPorId(int id);
        public bool agregarRegistro(Products datos);
        public bool actualizarRegistros(Products datos);

        public bool eliminarRegistro(int id);

        public Products buscarRegistroNombre(string datos);
    }
}
