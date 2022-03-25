using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Json;
using ExcelImportApp.Model;
using static System.Net.WebRequestMethods;
using Microsoft.EntityFrameworkCore;
using ExcelImportApp.Services;
using ExcelImportApp.Data;

namespace ExcelImportApp.Pages.Client
{
    public class GetClientModel : PageModel
    {
        private readonly IRepositoryWrapper _repository;
        public IEnumerable<ClientModel> ClientModels { get; set; }
        private readonly ILogger<GetClientModel> _logger;
        //private readonly ExcelImportService _importService;

        public GetClientModel(ILogger<GetClientModel> logger, IRepositoryWrapper repository )
        {
            _logger = logger;
            _repository = repository;
        }
        public void OnGet()
        {
            ClientModels = _repository.clientModel.FindAll();
        }

        //protected async Task OnGetAsync()
        //{
        //    HttpClient client = new HttpClient();
        //    ClientModels = await client.GetFromJsonAsync<IEnumerable<ClientModel>>("Client");


        //}



        // POST: api/Client
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<IActionResult> OnPostAsync()//Parses data from spreadsheet and saves to Db
        //{
        //    var file = Request.Form.Files[0];
        //    var models = _importService.ParseClientData(file);
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _appContext.ClientModel.AddRange(models);//Adds multiple rows to Db
        //    await _appContext.SaveChangesAsync();//Saves to Db

        //    return RedirectToPage("/.Index");
        //}
    }
}
