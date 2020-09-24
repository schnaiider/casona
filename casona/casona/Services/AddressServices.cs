using casona.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace casona.Services
{
    public class AddressServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<AddressStatusTO> getAddressStatus(ref int codError, ref string msjError)
        {

            List<AddressStatusTO> status = new List<AddressStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listAddressStatus", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var ds = new DataSet();
                        var da = new SqlDataAdapter(cmd);

                        da.Fill(ds);

                        if (ds.Tables.Count == 1)
                        {
                            List<ResultTO> error = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new ResultTO
                            {
                                Result = dataRow.Field<int>("result"),
                                Msg = dataRow.Field<string>("msg")
                            }).ToList();

                            codError = 1;
                            msjError = error.FirstOrDefault().Msg;
                            return new List<AddressStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new AddressStatusTO
                        {
                            IdStatus = dataRow.Field<int>("idStatus"),
                            StatusName = dataRow.Field<string>("statusName"),
                            CreateDate = dataRow.Field<DateTime>("createDate")
                        }).ToList();
                    }
                }
                return status;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<AddressStatusTO>();
            }
        }
        public List<CommuneTO> getCommune(ref int codError, ref string msjError)
        {

            List<CommuneTO> commune = new List<CommuneTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listCommune", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var ds = new DataSet();
                        var da = new SqlDataAdapter(cmd);

                        da.Fill(ds);

                        if (ds.Tables.Count == 1)
                        {
                            List<ResultTO> error = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new ResultTO
                            {
                                Result = dataRow.Field<int>("result"),
                                Msg = dataRow.Field<string>("msg")
                            }).ToList();

                            codError = 1;
                            msjError = error.FirstOrDefault().Msg;
                            return new List<CommuneTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        commune = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new CommuneTO
                        {
                            IdCommune = dataRow.Field<int>("idCommune"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            Commune = dataRow.Field<string>("commune"),
                            Price = dataRow.Field<int>("price"),
                            CreateDate = dataRow.Field<DateTime>("createDate")
                        }).ToList();
                    }
                }
                return commune;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<CommuneTO>();
            }
        }
        public List<CommuneStatusTO> getCommuneStatus(ref int codError, ref string msjError)
        {

            List<CommuneStatusTO> status = new List<CommuneStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listCommuneStatus", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        sql.Open();
                        var ds = new DataSet();
                        var da = new SqlDataAdapter(cmd);

                        da.Fill(ds);

                        if (ds.Tables.Count == 1)
                        {
                            List<ResultTO> error = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new ResultTO
                            {
                                Result = dataRow.Field<int>("result"),
                                Msg = dataRow.Field<string>("msg")
                            }).ToList();

                            codError = 1;
                            msjError = error.FirstOrDefault().Msg;
                            return new List<CommuneStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new CommuneStatusTO
                        {
                            IdStatus = dataRow.Field<int>("idStatus"),
                            StatusName = dataRow.Field<string>("statusName"),
                            CreateDate = dataRow.Field<DateTime>("createDate")
                        }).ToList();
                    }
                }
                return status;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<CommuneStatusTO>();
            }
        }
        public List<AddressTO> getAddress(int idUser, ref int codError, ref string msjError)
        {

            List<AddressTO> objList = new List<AddressTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listAddress", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = idUser;

                        sql.Open();
                        var ds = new DataSet();
                        var da = new SqlDataAdapter(cmd);

                        da.Fill(ds);

                        if (ds.Tables.Count == 1)
                        {
                            List<ResultTO> error = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new ResultTO
                            {
                                Result = dataRow.Field<int>("result"),
                                Msg = dataRow.Field<string>("msg")
                            }).ToList();

                            codError = 1;
                            msjError = error.FirstOrDefault().Msg;
                            return new List<AddressTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new AddressTO
                        {
                            IdAddress = dataRow.Field<int>("idAddress"),
                            IdUser = dataRow.Field<int>("idUser"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            IdCommune = dataRow.Field<int>("idCommune"),
                            Commune = dataRow.Field<string>("commune"),
                            CEP = dataRow.Field<long>("CEP"),
                            Address = dataRow.Field<string>("address"),
                            CreateDate = dataRow.Field<DateTime>("createDate")


                        }).ToList();
                    }
                }
                return objList;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<AddressTO>();
            }
        }
        public int setCreateAddress(AddressTO adrs, ref int codError, ref string msjError)
        {

            List<AddressTO> objList = new List<AddressTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createAddress", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = adrs.IdUser;
                        cmd.Parameters.Add("@idStatus", SqlDbType.Int).Value = adrs.IdStatus;
                        cmd.Parameters.Add("@idCommune", SqlDbType.Int).Value = adrs.IdCommune;
                        cmd.Parameters.Add("@CEP", SqlDbType.BigInt).Value = adrs.CEP;
                        cmd.Parameters.Add("@address", SqlDbType.VarChar).Value = adrs.Address;


                        sql.Open();
                        var ds = new DataSet();
                        var da = new SqlDataAdapter(cmd);

                        da.Fill(ds);

                        if (ds.Tables.Count == 1)
                        {
                            List<ResultTO> error = ds.Tables[0].AsEnumerable()
                            .Select(dataRow => new ResultTO
                            {
                                Result = dataRow.Field<int>("result"),
                                Msg = dataRow.Field<string>("msg")
                            }).ToList();

                            codError = 1;
                            msjError = error.FirstOrDefault().Msg;
                            return 0;
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new AddressTO
                        {
                            IdAddress = dataRow.Field<int>("idAddress")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdAddress;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return 0;
            }
        }
    }
}