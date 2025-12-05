using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentApi.Models;

namespace StudentRazor.Pages
{
    public class CreateModel(IHttpClientFactory factory) : PageModel
    {
        private readonly HttpClient _httpClient=factory.CreateClient();
        [BindProperty]
        public StudentField StuF {  get; set; }
        public void OnGet()
        {
            StuF=new StudentField();
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            string Apiurl = "https://localhost:7065/api/StudentFields";
            var res=await _httpClient.PostAsJsonAsync(Apiurl,StuF);
            if(res.IsSuccessStatusCode)
            {
                TempData["sucessmessage"] = "student data sucessful";
                TempData["Fullname"] = StuF.FullName;
                TempData["Course"] = StuF.Course;
                TempData["dateofbirth"] = StuF.DateOfBirth;
                TempData["email"] = StuF.Email;
                TempData["address"] = StuF.Address;
                return RedirectToPage("/success");
            }
            TempData["errormessage"] = "student data got an error";
            return Page();
        }
      
    }
}
