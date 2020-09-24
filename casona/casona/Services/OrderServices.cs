using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using casona.Models;

namespace casona.Services
{
    public class OrderServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<OrderDetailStatusTO> getOrderDetailStatus(ref int codError, ref string msjError)
        {

            List<OrderDetailStatusTO> status = new List<OrderDetailStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listOrderDetailStatus", sql))
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
                            return new List<OrderDetailStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new OrderDetailStatusTO
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
                return new List<OrderDetailStatusTO>();
            }
        }

        public List<OrderHistoryStatusTO> getOrderHistoryStatus(ref int codError, ref string msjError)
        {

            List<OrderHistoryStatusTO> status = new List<OrderHistoryStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listOrderHistoryStatus", sql))
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
                            return new List<OrderHistoryStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new OrderHistoryStatusTO
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
                return new List<OrderHistoryStatusTO>();
            }
        }

        public List<OrderStatusTO> getOrderStatus(ref int codError, ref string msjError)
        {

            List<OrderStatusTO> status = new List<OrderStatusTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listOrderStatus", sql))
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
                            return new List<OrderStatusTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new OrderStatusTO
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
                return new List<OrderStatusTO>();
            }
        }

        public List<OrderListTO> getOrder(int? idUser, ref int codError, ref string msjError)
        {

            List<OrderListTO> objList = new List<OrderListTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listOrder", sql))
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
                            return new List<OrderListTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        objList = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new OrderListTO
                        {
                            IdOrder = dataRow.Field<int>("idOrder"),
                            IdUser = dataRow.Field<int>("idUser"),
                            IdDelivery = dataRow.Field<int>("idDelivery"),
                            IdStatus = dataRow.Field<int>("idStatus"),
                            Delivery = dataRow.Field<string>("delivery"),
                            IdOrderDetail = dataRow.Field<int>("idOrderDetail"),
                            IdEdge = dataRow.Field<int>("idEdge"),
                            Edge = dataRow.Field<string>("edge"),
                            IdComposition = dataRow.Field<int>("idComposition"),
                            Composition = dataRow.Field<string>("composition"),
                            IdCheese = dataRow.Field<int>("idCheese"),
                            Cheese = dataRow.Field<string>("cheese"),
                            Quantity = dataRow.Field<int>("quantity"),
                            Price = dataRow.Field<float>("price"),
                            Commentary = dataRow.Field<string>("commentary")

                        }).ToList();
                    }
                }
                return objList;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return new List<OrderListTO>();
            }
        }


        public long setCreateOrder(OrderTO objOrder, ref int codError, ref string msjError)
        {

            List<OrderTO> objList = new List<OrderTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createOrder", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idUser", SqlDbType.Int).Value = objOrder.IdUser;
                        cmd.Parameters.Add("@idDelivery", SqlDbType.Int).Value = objOrder.IdDelivery;
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
                        .Select(dataRow => new OrderTO
                        {
                            IdOrder = dataRow.Field<long>("idOrder")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdOrder;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return 0;
            }
        }
        public int setCreateOrderDetail(OrderDetailTO objOrderDetail, ref int codError, ref string msjError)
        {

            List<OrderDetailTO> objList = new List<OrderDetailTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createOrderDetail", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add("@idOrder", SqlDbType.Int).Value = objOrderDetail.IdOrder;
                        cmd.Parameters.Add("@idStatus", SqlDbType.Int).Value = objOrderDetail.IdStatus;
                        cmd.Parameters.Add("@idEdge", SqlDbType.Int).Value = objOrderDetail.IdEdge;
                        cmd.Parameters.Add("@idComposition", SqlDbType.Int).Value = objOrderDetail.IdComposition;
                        cmd.Parameters.Add("@idCheese", SqlDbType.Int).Value = objOrderDetail.IdCheese;
                        cmd.Parameters.Add("@quantity", SqlDbType.Int).Value = objOrderDetail.Quantity;
                        cmd.Parameters.Add("@price", SqlDbType.Int).Value = objOrderDetail.Price;
                        cmd.Parameters.Add("@commentary", SqlDbType.VarChar).Value = objOrderDetail.Commentary;

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
                        .Select(dataRow => new OrderDetailTO
                        {
                            IdOrderDetail = dataRow.Field<int>("idOrderDetail")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdOrderDetail;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return 0;
            }
        }
        public int setCreateOrderItem(OrderItemTO objOrderDetail, ref int codError, ref string msjError)
        {

            List<OrderItemTO> objList = new List<OrderItemTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createOrderItem", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idOrderDetail", SqlDbType.Int).Value = objOrderDetail.IdOrderDetail;
                        cmd.Parameters.Add("@idProduct", SqlDbType.Int).Value = objOrderDetail.IdProduct;


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
                        .Select(dataRow => new OrderItemTO
                        {
                            IdOrderItem = dataRow.Field<int>("idOrderItem")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdOrderItem;
            }
            catch (Exception e)
            {
                codError = 0;
                msjError = e.Message;
                return 0;
            }
        }
        public int setCreateOrderHistory(OrderHistoryTO objOrderHistory, ref int codError, ref string msjError)
        {

            List<OrderHistoryTO> objList = new List<OrderHistoryTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("createOrderHistory", sql))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add("@idOrder", SqlDbType.Int).Value = objOrderHistory.IdOrder;
                        cmd.Parameters.Add("@idStatus", SqlDbType.Int).Value = objOrderHistory.IdStatus;


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
                        .Select(dataRow => new OrderHistoryTO
                        {
                            IdHistory = dataRow.Field<int>("idHistory")
                        }).ToList();
                    }
                }
                return objList.FirstOrDefault().IdHistory;
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