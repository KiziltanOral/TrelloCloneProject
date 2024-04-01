using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;
using TrelloClone.MVC.Models;
using System.Threading.Tasks;
using TrelloClone.Core.Results.Concrete;

namespace TrelloClone.MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(new { username = model.Username, password = model.Password }), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync("https://localhost:7195/api/Auth/login", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<SuccessDataResult<string>>(responseString);
                        if (result.IsSuccess)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        var responseString = await response.Content.ReadAsStringAsync();
                        var errorResult = JsonConvert.DeserializeObject<ErrorDataResult<string>>(responseString);
                        ModelState.AddModelError(string.Empty, errorResult.Message ?? "Invalid login attempt.");
                    }
                }
            }
            return View(model);
        }
    }
}

