using System.Web.Http;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/delivery")]
    public class deliveryController : ApiController
    {
        [Route("getDelivery")]
        [HttpGet]
        public IHttpActionResult getDelivery()
        {
            int codError = 1;
            string msjError = "";
            DeliveryServices objServicio = new DeliveryServices();
            var result = objServicio.getDelivery(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }
    }
}
