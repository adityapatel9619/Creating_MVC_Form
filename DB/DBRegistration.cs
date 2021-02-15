using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_Form_Intern_Aditya.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace MVC_Form_Intern_Aditya.DB
{
    public class DBRegistration
    {
        public IEnumerable<ModelRegistration> GetRegisteredlist(string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelRegistration> test = new List<ModelRegistration>();
                SqlCommand cmd = new SqlCommand("Proc_MVCINTERNADITYA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = "S";
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ModelRegistration lg = new ModelRegistration();
                    lg.Id = dr["ID"].ToString();
                    lg.Firstname = dr["Firstname"].ToString();
                    lg.Lastname = dr["Lastname"].ToString();
                    lg.Age = dr["Age"].ToString();
                    lg.Addressdetails = dr["Address"].ToString();
                    lg.Mobilenumber = dr["MobileNo"].ToString();
                    lg.Emailid = dr["EmailId"].ToString();
                    lg.Qualification = dr["Qualification"].ToString();
                    //lg.Userid = dr["Userid"].ToString();
                    test.Add(lg);
                }
                con.Close();

                return test.ToArray();
            }
        }

        // Connection Strings

        public IEnumerable<ModelRegistration> EditRegistered(int id, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                List<ModelRegistration> test = new List<ModelRegistration>();
                SqlCommand cmd = new SqlCommand("Proc_MVCINTERNADITYA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Type", "E");
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ModelRegistration lg = new ModelRegistration();
                    lg.Id = dr["ID"].ToString();
                    lg.Firstname = dr["Firstname"].ToString();
                    lg.Lastname = dr["Lastname"].ToString();
                    lg.Age = dr["Age"].ToString();
                    lg.Addressdetails = dr["Address"].ToString();
                    lg.Mobilenumber = dr["MobileNo"].ToString();
                    lg.Emailid = dr["EmailId"].ToString();
                    lg.Qualification = dr["Qualification"].ToString();
                    // lg.Userid = dr["Userid"].ToString();
                    test.Add(lg);
                }
                con.Close();

                return test.ToArray();
            }
        }

        // POST For Saving
        public string Post(ModelRegistration stud, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();


                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("Proc_MVCINTERNADITYA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@Firstname", stud.Firstname.ToString());
                cmd.Parameters.AddWithValue("@Lastname", stud.Lastname.ToString());
                cmd.Parameters.AddWithValue("@AddressDetails", stud.Addressdetails.ToString());
                cmd.Parameters.AddWithValue("@Age", stud.Age.ToString());
                cmd.Parameters.AddWithValue("@Mobilenumber", stud.Mobilenumber.ToString());
                cmd.Parameters.AddWithValue("@Emailid", stud.Emailid.ToString());
                cmd.Parameters.AddWithValue("@Qualification", stud.Qualification.ToString());
                cmd.Parameters.AddWithValue("@Userid", stud.Userid.ToString());
                cmd.Parameters.AddWithValue("@Type", "A");
                cmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@ReturnMessage"].Value.ToString();
                con.Close();
                return result;
            }
        }

        public string Put(ModelRegistration stud, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("Proc_MVCINTERNADITYA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Firstname", stud.Firstname.ToString());
                cmd.Parameters.AddWithValue("@Lastname", stud.Lastname.ToString());
                cmd.Parameters.AddWithValue("@AddressDetails", stud.Addressdetails.ToString());
                cmd.Parameters.AddWithValue("@Age", stud.Age.ToString());
                cmd.Parameters.AddWithValue("@Mobilenumber", stud.Mobilenumber.ToString());
                cmd.Parameters.AddWithValue("@Emailid", stud.Emailid.ToString());
                cmd.Parameters.AddWithValue("@Qualification", stud.Qualification.ToString());
                cmd.Parameters.AddWithValue("@Userid", stud.Userid.ToString());
                cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "U";
                cmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@ReturnMessage"].Value.ToString();
                con.Close();

                return result;
            }
        }

        public string Delete(int id, string deletedBy, string ConnectionString)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                List<ModelRegistration> test = new List<ModelRegistration>();
                if (con.State == ConnectionState.Closed) { con.Open(); }
                SqlCommand cmd = new SqlCommand("Proc_MVCINTERNADITYA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Userid", deletedBy);
                cmd.Parameters.AddWithValue("@Type", "D");
                cmd.Parameters.Add("@ReturnMessage", SqlDbType.NVarChar, 400).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                string result = cmd.Parameters["@ReturnMessage"].Value.ToString();
                con.Close();
                return result;
            }
        }
    }
}
