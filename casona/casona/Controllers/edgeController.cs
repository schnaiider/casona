using System.Web.Http;
using casona.Services;

namespace casona.Controllers
{
    [RoutePrefix("api/edge")]
    public class edgeController : ApiController
    {
        [Route("getEdge")]
        [HttpGet]
        public IHttpActionResult getEdge()
        {
            int codError = 1;
            string msjError = "";
            EdgeServices objEdge = new EdgeServices();
            var result = objEdge.getEdge(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }
    }
}
