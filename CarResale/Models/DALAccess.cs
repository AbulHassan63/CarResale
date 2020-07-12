using CarResale.Common;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace CarResale.Models
{
    public class DALAccess : IDalRep
    {
        public string Constr { get; set; }

        private readonly IOptions<SystemConfig> _config;
        public DALAccess(IOptions<SystemConfig> config)
        {
            _config = config;
            Constr = _config.Value.ConnectionString;
        }
        public bool SaveRegister(CarRegister _carRegister)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.SaveCarRegister, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Modelid", _carRegister.Model_id);
                    cmd.Parameters.AddWithValue("@Yearbuild", _carRegister.YearBuild);
                    cmd.Parameters.AddWithValue("@kilometer_coverd", _carRegister.Kilometer_Coverd);
                    cmd.Parameters.AddWithValue("@CarImages", _carRegister.DtImages);
                    con.Open();
                    var statflag = cmd.ExecuteNonQuery();
                    con.Close();
                    return statflag == 1 ? true : false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<CarMan> Gatcarmaninfo()
        {
            List<CarMan> CarManinfo = new List<CarMan>();
            try
            {
                DataTable dtman = new DataTable();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.Loaddropdown, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Type", "LoadMan");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtman);

                    //CarManinfo=from carman in dtman.
                    CarManinfo.Insert(0, new CarMan { Man_id = 0, Man_name = "Select" });
                    foreach (DataRow dr in dtman.Rows)
                    {
                        CarManinfo.Add(new CarMan { Man_id = Convert.ToInt32(dr["Man_id"]), Man_name = Convert.ToString(dr["Man_name"]) });

                    }
                    return CarManinfo;
                }
            }
            catch (Exception ex)
            {
                return CarManinfo;
            }
        }

        public List<CarBrand> GetCarbrand(int Man_id)
        {
            List<CarBrand> Carbrand = new List<CarBrand>();
            try
            {
                DataTable dtbrand = new DataTable();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.Loaddropdown, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Man_id", Man_id);
                    cmd.Parameters.AddWithValue("@Type", "LoadBrand");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtbrand);

                    //CarManinfo=from carman in dtman.
                    Carbrand.Insert(0, new CarBrand { Brand_id = 0, Brand_name = "Select" });
                    foreach (DataRow dr in dtbrand.Rows)
                    {
                        Carbrand.Add(new CarBrand { Brand_id = Convert.ToInt32(dr["Brand_id"]), Brand_name = Convert.ToString(dr["BrandName"]) });

                    }
                    return Carbrand;
                }
            }
            catch (Exception ex)
            {
                return Carbrand;
            }
        }

        public List<CarModel> GetCarmodel(int Brand_id)
        {
            List<CarModel> Carmodel = new List<CarModel>();
            try
            {
                DataTable dtmodel = new DataTable();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.Loaddropdown, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Brand_id", Brand_id);
                    cmd.Parameters.AddWithValue("@Type", "LoadModel");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtmodel);

                    //CarManinfo=from carman in dtman.
                    Carmodel.Insert(0, new CarModel { Model_id = 0, Model_name = "Select" });
                    foreach (DataRow dr in dtmodel.Rows)
                    {
                        Carmodel.Add(new CarModel { Model_id = Convert.ToInt32(dr["Model_id"]), Model_name = Convert.ToString(dr["ModelName"]) });

                    }
                    return Carmodel;
                }
            }
            catch (Exception ex)
            {
                return Carmodel;
            }
        }

        public List<DashCarRegister> GetAllrecords()
        {
            List<DashCarRegister> Carregister = new List<DashCarRegister>();
            try
            {
                DataTable dtregister = new DataTable();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.GetAllRecords, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(dtregister);

                    //CarManinfo=from carman in dtman.

                    foreach (DataRow dr in dtregister.Rows)
                    {
                        Carregister.Add(
                            new DashCarRegister
                            {
                                Reg_id = Convert.ToInt32(dr["Reg_id"]),
                                Man_name = Convert.ToString(dr["Make"]),
                                Brand_name = Convert.ToString(dr["Brand"]),
                                Model_name = Convert.ToString(dr["Model"]),
                                YearBuild = Convert.ToInt32(dr["YearBuild"]),
                                Kilometer_Coverd= Convert.ToDecimal(dr["Kilometer_Coverd"])

                            });

                    }
                    return Carregister;
                }
            }
            catch (Exception ex)
            {
                return Carregister;
            }
        }

        public List<DashCarRegister> Getrecordsbyfilter(int Man_id, int Brand_id, int Model_id)
        {
            List<DashCarRegister> Carregister = new List<DashCarRegister>();
            try
            {
                DataTable dtregister = new DataTable();
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.Getrecordsbyfilter, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    cmd.Parameters.AddWithValue("@Man_id", Man_id);
                    cmd.Parameters.AddWithValue("@Brand_id", Brand_id); 
                    cmd.Parameters.AddWithValue("@Model_id", Model_id);
                    sda.Fill(dtregister);

                    //CarManinfo=from carman in dtman.

                    foreach (DataRow dr in dtregister.Rows)
                    {
                        Carregister.Add(
                            new DashCarRegister
                            {
                                Reg_id = Convert.ToInt32(dr["Reg_id"]),
                                Man_name = Convert.ToString(dr["Make"]),
                                Brand_name = Convert.ToString(dr["Brand"]),
                                Model_name = Convert.ToString(dr["Model"]),
                                YearBuild = Convert.ToInt32(dr["YearBuild"]),
                                Kilometer_Coverd = Convert.ToDecimal(dr["Kilometer_Coverd"]),
                                CarImage = dr["CarImage"].ToString()
                            });

                    }
                    return Carregister;
                }
            }
            catch (Exception ex)
            {
                return Carregister;
            }
        }

        public bool SaveModel(CarRegister _carRegister)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(Constr))
                {
                    SqlCommand cmd = new SqlCommand(SystemConstant.SaveModel, con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BrandId", _carRegister.Brand_id);
                    cmd.Parameters.AddWithValue("@ModelName", _carRegister.Model_name);                    
                    con.Open();
                    var statflag = cmd.ExecuteNonQuery();
                    con.Close();
                    return statflag == 1 ? true : false;
                }


            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
