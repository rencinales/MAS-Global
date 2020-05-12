using Dapper;
using MAS.Component.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace MAS.Infraestructure.DataBase
{
    public class SqlLiteDataAccess
    {
        public static List<EmployeeAux> GetEmployees()
        {
            using (var cnn = new SQLiteConnection("" + new SQLiteConnectionStringBuilder
            {
                DataSource = "MAS_DB.db"
            }))
            {
                var employees = new List<EmployeeAux>();
                try
                {
                    employees = cnn.Query<EmployeeAux>("select * from Employee").ToList();
                }
                catch (Exception ex)
                {
                    var mierr = ex.InnerException;
                    throw;
                }

                return employees.ToList();
            }
            //{
            //using (IDbConnection cnn = new SQLiteConnection(LoadConnection()))
            //{
            //    var employees = new List<EmployeeAux>();
            //    try
            //    {
            //        employees = cnn.Query<EmployeeAux>("select * from Employee").ToList();
            //    }
            //    catch (Exception ex)
            //    {
            //        var mierr = ex.InnerException;
            //        throw ;
            //    }
                
            //    return employees.ToList();
            //}
            
        }
        private static string LoadConnection()
        {
            string cadena = "C:\\Users\\ASUS\\source\\repos\\MAS-Global\\MAS.Infraestructure.DataBase\\MAS_DB.db";
            cadena = "//MAS_DB.db";
            return cadena;
        }
    }
}
