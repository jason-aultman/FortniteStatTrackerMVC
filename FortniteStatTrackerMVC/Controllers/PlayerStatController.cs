using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FortniteStatTrackerMVC.Controllers
{
    public class PlayerStatController : Controller
    {
        public readonly HttpClient _httpClient;
        public readonly JsonSerializerOptions _options;
        public PlayerStatController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.fortnitetracker.com/v1/");
            _options = new JsonSerializerOptions() { WriteIndented = true, PropertyNameCaseInsensitive = true };
        }
        // GET: PlayerStatController
        public async Task<ActionResult> Index(string Id)
        {
            var player = new PlayerStat();
            List<LifeTimeStat> stats = player.LifeTimeStats;
            _httpClient.DefaultRequestHeaders.Add("TRN-Api-Key", "62cd4ae1-486d-4f51-8046-15084a4fe764");

            var response = await _httpClient.GetAsync($"profile/gamepad/{Id}");
            if(response.IsSuccessStatusCode)
            {
                var parseRawToJson = await response.Content.ReadAsStringAsync();
                var parsedToPlayerStat = JsonSerializer.Deserialize<PlayerStat>(parseRawToJson, _options);
                player = parsedToPlayerStat;
                if(player.EpicUserHandle!=null)
                {
                    return View(player);
                }
            }
            
            return NotFound();

            
        }
        public IActionResult ErrorPlayerNotFound()
        {
            return View();
        }

        // GET: PlayerStatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlayerStatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlayerStatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerStatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlayerStatController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlayerStatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlayerStatController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
