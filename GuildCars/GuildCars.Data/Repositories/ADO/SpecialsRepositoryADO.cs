using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Models.Tables;
using System.Globalization;
using System.Data.SqlClient;
using System.Data;

namespace GuildCars.Data.Repositories.ADO
{
    public class SpecialsRepositoryADO : ISpecialsRepository
    {
        public void Delete(int SpecialId)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpecialDelete", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@SpecialId", SpecialId);

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();
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

        public IEnumerable<Special> GetAll()
        {
            List<Special> specials = new List<Special>();

            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SelectAllSpecials", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    dbConnection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Special special = new Special();

                            special.SpecialId = (int)dr["SpecialsId"];
                            special.SpecialDetails = dr["SpecialDetails"].ToString();

                            specials.Add(special);
                        }
                    }
                    return specials;
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
                return specials;
            }
        }

        public void Insert(Special special)
        {
            using (var dbConnection = new SqlConnection(Settings.GetConnectionString()))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SpecialInsert", dbConnection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter param = new SqlParameter("@SpecialId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(param);

                    cmd.Parameters.AddWithValue("@SpecialDetails", special.SpecialDetails);

                    dbConnection.Open();

                    cmd.ExecuteNonQuery();

                    special.SpecialId = (int)param.Value;
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


