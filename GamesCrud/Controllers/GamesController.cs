using GamesCrud.Context;
using GamesCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : Controller
    {
        private readonly AppDbContext context;
        public GamesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(context.Games.ToList());
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpGet("{id}",Name = "GetGame")]
        public IActionResult Get(int id)
        {
            try
            {
                var game = context.Games.FirstOrDefault(x => x.id == id);
                return Ok(game);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] GamesDb games)
        {
            try
            {
                context.Games.Add(games);
                context.SaveChanges();
                return CreatedAtRoute("Game", new { id = games.id }, games);
            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] GamesDb games)
        {
            try
            {
                if(games.id == id)
                {
                    context.Entry(games).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("Game", new { id = games.id }, games);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var game = context.Games.FirstOrDefault(x => x.id == id);
                if(game != null)
                {
                    context.Games.Remove(game);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception err)
            {
                return BadRequest(err);
            }
        }

    }
}
