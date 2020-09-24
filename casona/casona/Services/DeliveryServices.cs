using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using casona.Models;

namespace casona.Services
{
    public class DeliveryServices
    {
        readonly string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Casona"].ConnectionString;

        public List<DeliveryTO> getDelivery(ref int codError, ref string msjError)
        {

            List<DeliveryTO> status = new List<DeliveryTO>();
            try
            {
                using (SqlConnection sql = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("listDelivery", sql))
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
                            return new List<DeliveryTO>();
                        }

                        List<ResultTO> results = ds.Tables[1].AsEnumerable()
                        .Select(dataRow => new ResultTO
                        {
                            Result = dataRow.Field<int>("result"),
                            Msg = dataRow.Field<string>("msg")
                        }).ToList();

                        status = ds.Tables[0].AsEnumerable()
                        .Select(dataRow => new DeliveryTO
                        {
                            IdDelivery = dataRow.Field<int>("idDelivery"),
                            Delivery = dataRow.Field<string>("delivery"),
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
                return new List<DeliveryTO>();
            }
        }
    }
}