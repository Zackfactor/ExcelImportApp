using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using ExcelImportApp.Model;
using static System.Net.WebRequestMethods;

namespace ExcelImportApp.Pages.Client
{
    public class GetClientModel : PageModel
    {
        public IEnumerable<ClientModel> ClientModels { get; set; }
        private readonly ILogger<GetClientModel> _logger;

        public GetClientModel(ILogger<GetClientModel> logger, IEnumerable<ClientModel> clientModels)
        {
            _logger = logger;
            ClientModels = clientModels;
        }
        public void OnGet()
        {
            
        }

        protected async Task OnGetAsync()
        {
            HttpClient client = new HttpClient();
            ClientModels = await client.GetFromJsonAsync<IEnumerable<ClientModel>>("Client");
        }
    }
}
