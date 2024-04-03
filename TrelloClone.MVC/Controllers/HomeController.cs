using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using TrelloClone.Business.Interfaces;
using TrelloClone.DataAccess.Interfaces.Repositories;
using TrelloClone.Dtos.ListDtos;
using TrelloClone.MVC.Models;
using TrelloClone.MVC.Models.ListVMs;

namespace TrelloClone.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IListService _listService;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public HomeController(ILogger<HomeController> logger, IListService listService, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _listService = listService;
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7195/api/List");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var lists = JsonConvert.DeserializeObject<IEnumerable<ListDetailsVM>>(content);
                return View(lists);
            }

            return View("Error");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
