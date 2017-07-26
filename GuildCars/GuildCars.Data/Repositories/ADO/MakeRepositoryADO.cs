using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;

namespace GuildCars.Data.Repositories.ADO
{
    public class MakeRepositoryADO : IMakeRepository
    {
        public IEnumerable<Make> GetAll()
        {
            List<Make> makes = new List<Make>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllMakes", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Make Make = new Make();

                            Make.MakeId = (int)dr["MakeId"];
                            Make.MakeName = dr["MakeName"].ToString();
                            Make.DateAdded = (DateTime)dr["DateAdded"];

                            makes.Add(Make);
                        }
                    }
                    return makes;
                }
                catch (Exception ex)
                {
                    string errorMessage = String.Format(CultureInfo.CurrentCulture,
                              "Exception Type: {0}, Message: {1}{2}",
                              ex.GetType(),
                              ex.Message,
                              ex.InnerException == null ? String.Empty :
                              String.Format(CultureInfo.CurrentCulture,
                                           " InnerException Type: {0}, Message: {1}",
                                           ex.InnerException.GetType(),
                                           ex.InnerException.Message));

                    System.Diagnostics.Debug.WriteLine(errorMessage);

                    dbConnection.Close();
                }
                return makes;
            }
        }

        public Make GetMakeById(int MakeId)
        {
            Make make = null;

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    dbConnection.Open();

                    SqlCommand cmd = new SqlCommand("SelectMakeById", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@MakeId", MakeId);



                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            make = new Make();
                            make.MakeId = (int)dr["MakeId"];
                            make.MakeName = dr["MakeName"].ToString();
                            make.DateAdded = (DateTime)dr["DateAdded"];
                        }
                    }

                    return make;
                }
                catch (Exception ex)
                {
                    string errorMessage = String.Format(CultureInfo.CurrentCulture,
                              "Exception Type: {0}, Message: {1}{2}",
                              ex.GetType(),
                              ex.Message,
                              ex.InnerException == null ? String.Empty :
                              String.Format(CultureInfo.CurrentCulture,
                                           " InnerException Type: {0}, Message: {1}",
                                           ex.InnerException.GetType(),
                                           ex.InnerException.Message));

                    System.Diagnostics.Debug.WriteLine(errorMessage);

                    dbConnection.Close();
                }

                return make;
            }
        }

            public void Insert(Make Make)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("MakeInsert", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@MakeId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(param);
                    
                    cmd.Parameters.AddWithValue("@MakeName", Make.MakeName);
                    cmd.Parameters.AddWithValue("@DateAdded", Make.DateAdded = DateTime.Now.Date);
                    

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();

                    Make.MakeId = (int)param.Value;
                }
                catch (Exception ex)
                {
                    string errorMessage = String.Format(CultureInfo.CurrentCulture,
                              "Exception Type: {0}, Message: {1}{2}",
                              ex.GetType(),
                              ex.Message,
                              ex.InnerException == null ? String.Empty :
                              String.Format(CultureInfo.CurrentCulture,
                                           " InnerException Type: {0}, Message: {1}",
                                           ex.InnerException.GetType(),
                                           ex.InnerException.Message));

                    System.Diagnostics.Debug.WriteLine(errorMessage);

                    dbConnection.Close();
                }
            }
        }
    }
}
