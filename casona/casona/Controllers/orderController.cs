using System.Web.Http;
using casona.Models;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/order")]

    public class orderController : ApiController
    {
        [Route("getOrderDetailStatus")]
        [HttpGet]
        public IHttpActionResult getOrderDetailStatus()
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.getOrderDetailStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getOrderHistoryStatus")]
        [HttpGet]
        public IHttpActionResult getOrderHistoryStatus()
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.getOrderHistoryStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getOrderStatus")]
        [HttpGet]
        public IHttpActionResult getOrderStatus()
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.getOrderStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getOrder/{idUser}")]
        [HttpGet]
        public IHttpActionResult getOrder(int? idUser)
        {
            if (idUser.Equals(0))
            {
                idUser = null;
            }
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.getOrder(idUser, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("setCreateOrder")]
        [HttpPost]

        public IHttpActionResult setCreateOrder(OrderTO ordr)
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.setCreateOrder(ordr, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("setCreateOrderDetail")]
        [HttpPost]
        public IHttpActionResult setCreateOrderDetail(OrderDetailTO ordr)
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.setCreateOrderDetail(ordr, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("setCreateOrderItem")]
        [HttpPost]
        public IHttpActionResult setCreateOrderItem(OrderItemTO ordr)
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.setCreateOrderItem(ordr, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("setCreateOrderHistory")]
        [HttpPost]
        public IHttpActionResult setCreateOrderHistory(OrderHistoryTO ordr)
        {
            int codError = 1;
            string msjError = "";
            OrderServices objServicio = new OrderServices();
            var result = objServicio.setCreateOrderHistory(ordr, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

    }
}
