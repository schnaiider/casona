
using System.Web.Http;
using casona.Models;
using casona.Services;

namespace Casona.Controllers
{
    [RoutePrefix("api/user")]
    public class userController : ApiController
    {
        [Route("getUserStatus")]
        [HttpGet]
        public IHttpActionResult getUserStatus()
        {
            int codError = 1;
            string msjError = "";
            UserServices objServicio = new UserServices();
            var result = objServicio.getUserStatus(ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getListUser/{email}/{password}")]
        [HttpGet]
        public IHttpActionResult getListUser(string email, string password)
        {
            int codError = 1;
            string msjError = "";
            UserServices objServicio = new UserServices();
            var result = objServicio.getListUser(email, password, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("getListUserInfo/{idUser}")]
        [HttpGet]
        public IHttpActionResult getListUserInfo(int idUser)
        {
            int codError = 1;
            string msjError = "";
            UserServices objServicio = new UserServices();
            var result = objServicio.getListUserInfo(idUser, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }

        [Route("setCreateUser")]
        [HttpPost]
        public IHttpActionResult setCreateUser(UserTO usr)
        {
            int codError = 1;
            string msjError = "";
            UserServices objServicio = new UserServices();
            var result = objServicio.setCreateUser(usr, ref codError, ref msjError);

            if (codError == 1)
                return Ok(result);
            return BadRequest(msjError);

        }
    }
}
