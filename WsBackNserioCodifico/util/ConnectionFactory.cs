using BacktecnoFactApi.infraestructura.config.properties;

namespace BacktecnoFactApi.infraestructura.util
{
    public class ConnectionFactory
    {

        public static String connectToBD()
        {

            var propiedad = Propiedad.GetCurrentInstance();
            String connServer = propiedad.GetBDServidor();
            String connDatabase = propiedad.GetBDDatabase();
            
        
            String username = propiedad.GetBDUsuario();

            String password = propiedad.GetBDClave();


            string rutaConexion = $"Data Source={connServer};Initial Catalog={connDatabase};Integrated Security=True;TrustServerCertificate=True";
           
            return rutaConexion;
	}




}
}
