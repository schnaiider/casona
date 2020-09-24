using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using casona.Models;

namespace casona.Services
{
    public class PhoneServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<PhoneStatusTO> getPhoneStatus(ref int codError, ref string msjError)
        {

            List<PhoneStatusTO> status = new List<PhoneStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listPhoneStatus", sql))
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
                            return new List<PhoneStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new PhoneStatusTO
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
                return new List<PhoneStatusTO>();
            }
        }
        public List<PhoneTO> getListPhone(int idUser, ref int codError, ref string msjError)
        {

            List<PhoneTO> objList = new List<PhoneTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listPhone", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idUser", SqlDbType.VarChar).Value = idUser;
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
                            return new List<PhoneTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new PhoneTO
                        {
                            IdPhone = dataRow.Field<int>("idPhone"),
                            IdUser = dataRow.Field<int>("idUser"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            Phone = dataRow.Field<long>("phone"),
                            Area = dataRow.Field<int>("area"),
                        }).ToList();
                    }
                }
                return objList;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<PhoneTO>();
            }
        }
        public int setCreatePhone(PhoneTO objPhone, ref int codError, ref string msjError)
        {

            List<PhoneTO> objList = new List<PhoneTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createPhone", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = objPhone.IdUser;
                        cmd.Parameters.Add("@idStatus", SqlDbType.Int).Value = objPhone.IdStatus;
                        cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = objPhone.Phone;
                        cmd.Parameters.Add("@area", SqlDbType.Int).Value = objPhone.Area;

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
                        .Select(dataRow => new PhoneTO
                        {
                            IdPhone = dataRow.Field<int>("idPhone")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdPhone;
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