using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet3back.dbcontext;
using aspnet3back.models;
using Microsoft.AspNetCore.Mvc;

namespace aspnet3back.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly Datacontext _context;

        public GamesController(Datacontext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Games>> Get()
        {
            return _context.Games.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Games> GetbyId(int id)
        {
            if (_context.Games.Find(id) == null)
            {
                return NotFound();
            }
            return _context.Games.Find(id);
        }

        [HttpPost]
        public IActionResult Create(Games game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Create), new {id = game.Id }, game);
        }
        [HttpPut("{id}")]
        public IActionResult Edit(int id, Games game)
        {
            var game1 = _context.Games.Find(id);
            game1.Name = game.Name;
            game1.Platform = game.Platform;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game1 = _context.Games.Find(id);
            
           _context.Games.Remove(game1);
            _context.SaveChanges();
            return Ok();
        }


    }
}