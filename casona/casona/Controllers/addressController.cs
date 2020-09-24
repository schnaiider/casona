using System.Web.Http;
using casona.Models;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/address")]
    public class addressController : ApiController
    {

        [Route("getAddressStatus")]
        [HttpGet]
        public IHttpActionResult getAddressStatus()
        {
            int codError = 1;
            string msjError = "";
            AddressServices objServicio = new AddressServices();
            var result = objServicio.getAddressStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getCommune")]
        [HttpGet]
        public IHttpActionResult getCommune()
        {
            int codError = 1;
            string msjError = "";
            AddressServices objServicio = new AddressServices();
            var result = objServicio.getCommune(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }


        [Route("getCommuneStatus")]
        [HttpGet]
        public IHttpActionResult getCommuneStatus()
        {
            int codError = 1;
            string msjError = "";
            AddressServices objServicio = new AddressServices();
            var result = objServicio.getCommuneStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("setCreateAddress")]
        [HttpPost]
        public IHttpActionResult setCreateAddress(AddressTO adrs)
        {
            int codError = 1;
            string msjError = "";
            AddressServices objServicio = new AddressServices();
            var result = objServicio.setCreateAddress(adrs, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getAddress/{idUser}")]
        [HttpGet]
        public IHttpActionResult getAddress(int idUser)
        {
            int codError = 1;
            string msjError = "";
            AddressServices objServicio = new AddressServices();
            var result = objServicio.getAddress(idUser, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }
    }
}
