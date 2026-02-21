using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using KoiShow.Common;
using KoiShow.Service.Base;
using System.Text;
using System.Net.Http.Headers;
using KoiShow.MVCWebApp.Models;

namespace KoiShow.MVCWebApp.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Accounts/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string userName, string password)
        {
            using (var httpClient = new HttpClient())
            {
                var loginData = new
                {
                    userName = userName,
                    password = password
                };

                var content = new StringContent(
                    JsonConvert.SerializeObject(loginData),
                    Encoding.UTF8,
                    "application/json"
                );

                using (var response = await httpClient.PostAsync(Const.APIEndPoint + "Accounts/login", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resultContent = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<LoginResponse>(resultContent);

                        if (result != null && !string.IsNullOrEmpty(result.Token))
                        {
                            HttpContext.Session.SetString("JWToken", result.Token);

                            return RedirectToAction("Index", "Animals");
                        }
                    }
                }
            }

            ViewBag.Error = "Login failed. Invalid username or password!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("JWToken");
            return RedirectToAction("Login");
        }
    }
}