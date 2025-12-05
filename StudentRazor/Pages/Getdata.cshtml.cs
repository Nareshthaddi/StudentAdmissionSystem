using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Models;

namespace StudentRazor.Pages
{
    public class GetdataModel(IHttpClientFactory factory) : PageModel
    {
        private readonly HttpClient httpClient=factory.CreateClient();
        public List<StudentField> students = new();
       // public string message {  get; set; }    
      
        public async Task OnGetAsync()
        {
            //message = "student data displayed";
            students=await httpClient.GetFromJsonAsync<List<StudentField>>("https://localhost:7065/api/StudentFields")?? new List<StudentField>();
        }
    }
}
