using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestSharp;

namespace NaGreenWebApi.Controllers
{
    public class GamesController : ApiController
    {
        //GET api/Games?languagecode=EN&userid=1
        /// <summary>
        /// Get the list of games from endpoint
        /// </summary>
        /// <param name="languageCode">Language code is required</param>
        /// <param name="userId">User id is optional</param>
        /// <returns>HttpResponseMessage object</returns>
        public HttpResponseMessage GetGames(string languageCode, int userId = 0)
        {
            string endPoint = string.Empty;
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Headers.Add("Access-Control-Allow-Origin", "*");
            string nrgsBaseUrl = System.Configuration.ConfigurationManager.AppSettings[Constants.ConfigurationKeys.NrgsBaseUrl];
            string nrgsAuthorizationHeaderValue = System.Configuration.ConfigurationManager.AppSettings[Constants.ConfigurationKeys.NrgsP1Authorization];
            if (userId == 0)
                endPoint = nrgsBaseUrl + string.Format(Constants.Game.GamesUrlWithOutUserId, languageCode);
            else
                endPoint = nrgsBaseUrl + string.Format(Constants.Game.GamesUrlWithUserId, languageCode, userId);
            RestClient client = new RestClient(endPoint);
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", nrgsAuthorizationHeaderValue);
            request.AddHeader("DateUtc", Constants.Date.Utc);
            request.AddHeader("Content-Type", "application/json");            
            response.Content = new StringContent(client.Execute(request).Content.ToString());
            return response;
        }
    }
}
