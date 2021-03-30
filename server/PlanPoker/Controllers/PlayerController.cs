using DataService.Models;
using DataService.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanPoker.Services;
using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

namespace PlanPoker.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService services;

        public PlayerController(PlayerService services)
        {
            this.services = services;
        }

        [HttpPost("create/{name}")]
        public Player Create(string name)
        {
            return this.services.Create(name);
        }

        [HttpPost("getall")]
        public IQueryable<Player> GetAll()
        {
            return this.services.GetAll();
        }
    }
}
