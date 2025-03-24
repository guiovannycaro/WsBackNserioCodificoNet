
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace BacktecnoFactApi.infraestructura.config.properties
{
    public class Propiedad
    {
        private static readonly Lazy<Propiedad> _instancia = new Lazy<Propiedad>(() => new Propiedad());

        private readonly Dictionary<string, string> propVersion = new Dictionary<string, string>();
        private readonly Dictionary<string, string> propGlobal = new Dictionary<string, string>();

        private Propiedad()
        {
            try
            {
                string basePath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", ".."));
               
                string versionFilePath = Path.Combine(basePath,  "config", "properties", "version.properties");
                string globalFilePath = Path.Combine(basePath,  "config", "properties", "param.properties");
        
                string globalContent = File.ReadAllText(globalFilePath);
              

                if (File.Exists(versionFilePath))
                {
                    LoadProperties(versionFilePath, propVersion);
                }

                if (File.Exists(globalFilePath))
                {
                    LoadProperties(globalFilePath, propGlobal);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error cargando archivos de configuración: " + ex.Message);
            }
        }

        private void LoadProperties(string filePath, Dictionary<string, string> properties)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!string.IsNullOrWhiteSpace(line) && !line.StartsWith("#"))
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        properties[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
        }
        public static Propiedad GetCurrentInstance() => _instancia.Value;

        public string GetVersion() => propVersion.TryGetValue("VERSION", out var version) ? version : "N/A";
        public string GetBDServidor() => propGlobal.TryGetValue("BD.SERVIDOR", out var servidor) ? servidor : "N/A";

        public string GetBDDatabase() => propGlobal.TryGetValue("BD.DATABASE", out var database) ? database : "N/A";
        public string GetBDHost() => propGlobal.TryGetValue("BD.HOST",out var host) ? host : "N/A";
        public string GetBDPort() => propGlobal.TryGetValue("BD.PORT", out var port) ? port : "N/A";
        public string GetBDUsuario() => propGlobal.TryGetValue("BD.USUARIO", out var usuario) ? usuario : "N/A";
        public string GetBDClave() => propGlobal.TryGetValue("BD.CLAVE", out var clave) ? clave : "N/A";
        public string GetPathTmp() => propGlobal.TryGetValue("PATH_TMP", out var pathTmp) ? pathTmp : "N/A";

        public static void Main()
        {
            var propiedad = Propiedad.GetCurrentInstance();
            Console.WriteLine($"PARAM= {propiedad.GetVersion()} {propiedad.GetBDServidor()} {propiedad.GetBDDatabase()} {propiedad.GetBDUsuario()} {propiedad.GetBDClave()}");
         }
      }
    }
