using CRUDusingDrapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUDusingDrapper.Repository
{
    public class CustomerRepository
    {
        // public SqlConnection con;
        public IDbConnection con;
        //To Handle connection related activities      
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
            con = new SqlConnection(constr);

        }
        //To Add Employee details      
        public void AddCustomer(Customer objCus)
        {

            //Additing the employess      
            try
            {
                connection();
                con.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Query", "1");
                parameters.AddDynamicParams(objCus);
                con.Execute("Usp_InsertUpdateDelete_Customer", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //To view employee details with generic list       
        public List<Customer> GetAllCustomers()
        {
            try
            {
                connection();
                con.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Query", "4");
                IList<Customer> customers = con.Query<Customer>(
                    "Usp_InsertUpdateDelete_Customer",
                     parameters,
                    commandType: CommandType.StoredProcedure
                ).ToList();

                con.Close();
                return customers.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        //To Update Employee details      
        public void UpdateCustomer(Customer objUpdate)
        {
            try
            {
                connection();
                con.Open();
                var parameters = new DynamicParameters();
                parameters.Add("@Query", "2");
                parameters.AddDynamicParams(objUpdate);
                con.Execute("Usp_InsertUpdateDelete_Customer", parameters, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        //To delete Employee details      
        public bool DeleteCustomer(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@Query", "3");
                param.Add("@CustomerID", Id);
                connection();
                con.Open();
                con.Execute("Usp_InsertUpdateDelete_Customer", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                //Log error as per your need       
                throw ex;
            }
        }
    }
}
