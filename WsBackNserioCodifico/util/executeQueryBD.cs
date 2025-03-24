using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BacktecnoFactApi.infraestructura.util;
using System.Data;

namespace BacktecnoFactApi.Infraestructura.Util
{
    public class ExecuteQueryBD
    {
        public SqlDataReader ExecuteSelectBd(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionFactory.connectToBD());
                connection.Open();

                var cmd = new SqlCommand(sql, connection);

               
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                return cmd.ExecuteReader(CommandBehavior.CloseConnection); 
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"SqlException: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        public bool ExecuteUpdateBd(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionFactory.connectToBD()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(sql, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"SqlException: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception: {ex.Message}");
                return false;
            }
        }


        public int ExecuteScalarBd(string sql, Dictionary<string, object> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionFactory.connectToBD()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand(sql, connection))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                            }
                        }

                        // Ejecutamos ExecuteScalar para obtener el primer valor del resultado
                        var result = cmd.ExecuteScalar();

                        // Si el resultado no es DBNull, lo convertimos y lo retornamos
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt32(result); // Convertimos el resultado a un entero
                        }
                        return 0; // Si no se obtiene un valor válido, retornamos 0 (o puedes lanzar una excepción si lo prefieres)
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine($"SqlException: {ex.Message}");
                return 0; // Retornar 0 si hay un error SQL
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Exception: {ex.Message}");
                return 0; // Retornar 0 si hay un error general
            }
        }
    }
}