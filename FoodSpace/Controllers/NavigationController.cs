using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodSpace.Controllers
{
    public class NavigationController : Controller
    {
        private readonly ITokenAcquisition _tokenAcquisition;

        public NavigationController(ITokenAcquisition tokenAcquisition)
        {
            _tokenAcquisition = tokenAcquisition;
        }

        public async Task<IActionResult> Index()
        {
            // Acquire access token for Microsoft Graph
            string[] scopes = new[] { "User.Read" };
            string accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(scopes);

            // Create an instance of HttpClient with authentication
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

            // Create GraphServiceClient using the HttpClient
            GraphServiceClient graphClient = new GraphServiceClient(httpClient);

            // Use the graphClient to interact with Microsoft Graph

            return View();
        }
    }
}
