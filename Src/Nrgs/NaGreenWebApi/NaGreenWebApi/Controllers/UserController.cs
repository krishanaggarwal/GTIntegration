using NaGreen.WebApi.Server.Base.Services;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace NaGreenWebApi.Controllers
{
    /// <summary>
    /// User CRUD operations
    /// </summary>
    public class UserController : ApiController
    {
        private IUsersService _userService;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="userService"></param>
        public UserController(IUsersService userService)
        {
            _userService = userService;
        }

        // GET api/user
        /// <summary>
        /// Get the list of users
        /// </summary>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");                        
            using (NaGreenEntities userData = new NaGreenEntities())
            {
                response.Content = new StringContent(new JavaScriptSerializer().Serialize(userData.Users.ToList()));
                return response;
            }
        }

        // GET api/user/5
        /// <summary>
        /// Get the user from user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            using (NaGreenEntities userData = new NaGreenEntities())
            {
                response.Content = new StringContent(new JavaScriptSerializer().Serialize(userData.Users.FirstOrDefault(x => x.UserId == id)));
                return response;
            }
        }

        // POST api/user
        /// <summary>
        /// Add new user from http body
        /// </summary>
        /// <param name="request">HttpRequestMessage object</param>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage Post(HttpRequestMessage request)
        {
            try
            {                
                using (NaGreenEntities userData = new NaGreenEntities())
                {
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    User newUser = js.Deserialize(request.Content.ReadAsStringAsync().Result, typeof(NaGreenWebApi.User)) as User;
                    if (!string.IsNullOrEmpty(newUser.Name) && !string.IsNullOrEmpty(newUser.Currency))
                    {
                        if (newUser.Balance == 0)
                            newUser.Balance = Constants.User.DefaultBalance;
                        newUser.LastLogin = Constants.Date.Today;
                        newUser.CDate = Constants.Date.Today;
                        userData.Users.Add(newUser);
                        userData.SaveChanges();
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict) { ReasonPhrase = ex.Message };
            }
        }

        // PUT api/user/5
        /// <summary>
        /// Update the user info from user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <param name="request">HttpRequestMessage object</param>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage Put(int id, HttpRequestMessage request)
        {
            try
            {                
                using (NaGreenEntities userData = new NaGreenEntities())
                {
                    User user = userData.Users.SingleOrDefault(x => x.UserId == id);
                    JavaScriptSerializer js = new JavaScriptSerializer();
                    User newUserInfo = js.Deserialize(request.Content.ReadAsStringAsync().Result, typeof(NaGreenWebApi.User)) as User;
                    user.Balance = newUserInfo.Balance;
                    user.Name = newUserInfo.Name;
                    userData.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict) { ReasonPhrase = ex.Message };
            }
        }

        // DELETE api/user/5
        /// <summary>
        /// Delete the user info from user id
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (NaGreenEntities userData = new NaGreenEntities())
                {
                    var user = userData.Users.SingleOrDefault(x => x.UserId == id);
                    if (user != null)
                    {
                        userData.Users.Remove(user);
                        userData.SaveChanges();
                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                    else
                    {
                        return new HttpResponseMessage(HttpStatusCode.BadRequest);
                    }
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict) { ReasonPhrase = ex.Message };
            }
        }
    }
}
