using PasswordPolicy.Classes;
using PasswordPolicy.Data;
using PasswordPolicy.Helpers;
using PasswordPolicy.Models.MMPAY;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace PasswordPolicy.Controllers
{
    public class ValidationController : ApiController
    {

        ApplicationRepository _repository = new ApplicationRepository();

        // GET api/validation/IsPasswordValid?password[Password]=1234
        [HttpGet]

        public IHttpActionResult IsPasswordValid([FromUri]PasswordPolicy passwordPolicy)
        {
      
            try
            {

                if (ModelState.IsValid)
                {
                    return Ok(true); // http ok

                }
                else if (!ModelState.IsValid)
                {

                    return BadRequest(ModelState); // http bad request
                }
                else
                {
                    return BadRequest();
                }


            }
            catch (Exception e)
            {
                // HTTP code 500 (Internal Server Error)
                _repository.LogApiEvents(Tools.ReturnExMsg(e, Tools.GetControllerActionRoute(this)), "[]", HttpStatusCode.InternalServerError,
                                         "0", Tools.ConvertRequestToJson(passwordPolicy));
                return InternalServerError(); // http internal server error
            }

        }


        // POST api/validation/ValidateExpiredPassword
        [HttpPost]
        public IHttpActionResult ValidateExpiredPassword([FromBody]PasswordPolicy passwordPolicy)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var result = _repository.RetrievePasswordHistory(passwordPolicy.UserId);

                    bool isExpired = _repository.VerifyPasswordExpiration(result);

                    if (!isExpired)
                    {
                       
                        return Ok(false);
                    }
                    else
                    {
                        return Ok(true);
                    }
                }
                else
                {
                    return BadRequest(ModelState);
                }
               


            }
            catch (Exception e)
            {
                _repository.LogApiEvents(Tools.ReturnExMsg(e, Tools.GetControllerActionRoute(this)), "[]", HttpStatusCode.InternalServerError,
                                      "0", Tools.ConvertRequestToJson(passwordPolicy));
                return InternalServerError(); // http internal server error

            }

        }

        // POST api/validation/BlockUser
        [HttpPost]
        public IHttpActionResult BlockUser([FromBody]PasswordPolicy passwordPolicy)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    bool result = _repository.BlockUser(passwordPolicy);

                  
                    return Ok(result);

                }
                else
                {
                    return BadRequest(ModelState);
                }



            }
            catch (Exception e)
            {
                _repository.LogApiEvents(Tools.ReturnExMsg(e, Tools.GetControllerActionRoute(this)), "[]", HttpStatusCode.InternalServerError,
                                         "0", Tools.ConvertRequestToJson(passwordPolicy));
                return InternalServerError(); // http internal server error

            }

        }

 
    }
}
