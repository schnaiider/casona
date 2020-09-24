using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using casona.Models;

namespace casona.Services
{
    public class UserServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<UserStatusTO> getUserStatus(ref int codError, ref string msjError)
        {

            List<UserStatusTO> objList = new List<UserStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listUserStatus", sql))
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
                            return new List<UserStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new UserStatusTO
                        {
                            IdStatus = dataRow.Field<int>("idStatus"),
                            StatusName = dataRow.Field<string>("statusName"),
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
                return new List<UserStatusTO>();
            }
        }
        public int setCreateUser(UserTO usr, ref int codError, ref string msjError)
        {

            List<UserTO> objList = new List<UserTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createUser", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;                        
                        cmd.Parameters.Add("@idSocial", SqlDbType.BigInt).Value = usr.IdSocial;
                        cmd.Parameters.Add("@provider", SqlDbType.VarChar).Value = usr.Provider;
                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = usr.Name;
                        cmd.Parameters.Add("@firstName", SqlDbType.VarChar).Value = usr.FirstName;
                        cmd.Parameters.Add("@lastName", SqlDbType.VarChar).Value = usr.LastName;
                        cmd.Parameters.Add("@photoUrl", SqlDbType.VarChar).Value = usr.PhotoUrl;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = usr.Email;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = usr.Password;

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
                        .Select(dataRow => new UserTO
                        {
                            IdUser = dataRow.Field<int>("idUser")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdUser;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return 0;
            }
        }

        public List<UserTO> getListUser(string email, string password, ref int codError, ref string msjError)
        {

            List<UserTO> objList = new List<UserTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listUser", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                        cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
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
                            return new List<UserTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new UserTO
                        {
                            IdUser = dataRow.Field<int>("idUser"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            IdSocial = dataRow.Field<long>("idSocial"),
                            StatusName = dataRow.Field<string>("statusName"),
                            Provider = dataRow.Field<string>("provider"),
                            Name = dataRow.Field<string>("name"),
                            FirstName = dataRow.Field<string>("firstName"),
                            LastName = dataRow.Field<string>("lastName"),
                            PhotoUrl = dataRow.Field<string>("photoUrl"),
                            Email = dataRow.Field<string>("email"),
                            Password = dataRow.Field<string>("password"),
                            CreateDate = dataRow.Field<DateTime>("createDate"),


                        }).ToList();
                    }
                }
                return objList;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<UserTO>();
            }
        }

        public List<UserTO> getListUserInfo(int idUser, ref int codError, ref string msjError)
        {

            List<UserTO> objList = new List<UserTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listUserInfo", sql))
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
                            return new List<UserTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new UserTO
                        {
                            IdUser = dataRow.Field<int>("idUser"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            IdSocial = dataRow.Field<long>("idSocial"),
                            StatusName = dataRow.Field<string>("statusName"),
                            Provider = dataRow.Field<string>("provider"),
                            Name = dataRow.Field<string>("name"),
                            FirstName = dataRow.Field<string>("firstName"),
                            LastName = dataRow.Field<string>("lastName"),
                            PhotoUrl = dataRow.Field<string>("photoUrl"),
                            Email = dataRow.Field<string>("email"),
                            Password = dataRow.Field<string>("password"),
                            CreateDate = dataRow.Field<DateTime>("createDate"),


                        }).ToList();
                    }
                }
                return objList;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<UserTO>();
            }
        }


    }
}