using WsBackNserioCodifico.Modelos;

namespace WsBackNserioCodifico.interfaces
{
    public interface IEmployeesInter
    {

        List<Employees> devolverTodos();
        public List<Employees> buscarRegistroPorId(int id);
        public bool agregarRegistro(Employees datos);
        public bool actualizarRegistros(Employees datos);

        public bool eliminarRegistro(int id);

        public Employees buscarRegistroNombre(string datos);
    }
}
