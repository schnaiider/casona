using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using casona.Models;

namespace casona.Services
{
    public class ProductServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<ProductTO> getProduct(int? idProductType, ref int codError, ref string msjError)
        {

            List<ProductTO> product = new List<ProductTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listProduct", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idProductType", SqlDbType.Int).Value = idProductType;
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
                            return new List<ProductTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        product = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new ProductTO
                        {
                            IdProduct = dataRow.Field<int>("idProduct"),
                            IdProductType = dataRow.Field<int>("idProductType"),
                            ProductType = dataRow.Field<string>("productType"),
                            ProductName = dataRow.Field<string>("productName"),
                            Description = dataRow.Field<string>("description"),
                            Price = dataRow.Field<int>("price"),
                            UrlImage = dataRow.Field<string>("urlImage")
                        }).ToList();
                    }
                }
                return product;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<ProductTO>();
            }
        }


        public List<ProductTypeTO> getProductType(ref int codError, ref string msjError)
        {

            List<ProductTypeTO> status = new List<ProductTypeTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listProductType", sql))
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
                            return new List<ProductTypeTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new ProductTypeTO
                        {
                            IdProductType = dataRow.Field<int>("idProductType"),
                            ProductType = dataRow.Field<string>("productType"),
                            IdStatus = dataRow.Field<int>("idStatus"),
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
                return new List<ProductTypeTO>();
            }
        }

        public List<ProductTypeStatusTO> getProductTypeStatus(ref int codError, ref string msjError)
        {

            List<ProductTypeStatusTO> status = new List<ProductTypeStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listProductTypeStatus", sql))
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
                            return new List<ProductTypeStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new ProductTypeStatusTO
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
                return new List<ProductTypeStatusTO>();
            }
        }
    }
}