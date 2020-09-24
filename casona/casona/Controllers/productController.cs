using System.Web.Http;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/product")]
    public class productController : ApiController
    {
        [Route("getProduct/{idProductType}")]
        [HttpGet]
        public IHttpActionResult getProduct(int? idProductType)
        {
            if (idProductType.Equals(0))
            {
                idProductType = null;
            }
            int codError = 1;
            string msjError = "";
            ProductServices objServicio = new ProductServices();
            var result = objServicio.getProduct(idProductType, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("getProductType")]
        [HttpGet]
        public IHttpActionResult getProductType()
        {
            int codError = 1;
            string msjError = "";
            ProductServices objServicio = new ProductServices();
            var result = objServicio.getProductType(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("getProductTypeStatus")]
        [HttpGet]
        public IHttpActionResult getProductTypeStatus()
        {
            int codError = 1;
            string msjError = "";
            ProductServices objServicio = new ProductServices();
            var result = objServicio.getProductTypeStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);
        }
    }
}
