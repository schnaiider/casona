using System.Web.Http;
using casona.Models;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/phone")]
    public class phoneController : ApiController
    {
        [Route("getPhoneStatus")]
        [HttpGet]
        public IHttpActionResult getPhoneStatus()
        {
            int codError = 1;
            string msjError = "";
            PhoneServices objServicio = new PhoneServices();
            var result = objServicio.getPhoneStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("setCreatePhone")]
        [HttpPost]
        public IHttpActionResult setCreatePhone(PhoneTO objPhone)
        {
            int codError = 1;
            string msjError = "";
            PhoneServices objServicio = new PhoneServices();
            var result = objServicio.setCreatePhone(objPhone, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("getListPhone/{idUser}")]
        [HttpGet]
        public IHttpActionResult getListPhone(int idUser)
        {
            int codError = 1;
            string msjError = "";
            PhoneServices objServicio = new PhoneServices();
            var result = objServicio.getListPhone(idUser, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }
    }
}
