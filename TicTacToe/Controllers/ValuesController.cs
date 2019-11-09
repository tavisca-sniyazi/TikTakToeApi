using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Game BoardGame;
        public ValuesController(Game game)
        {
            BoardGame = game
;        }
        // GET api/values
        [HttpGet]
        public Board Get()
        {
            return BoardGame.MyBoard;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public Board Post([FromBody]Value value)
        {
            if (BoardGame.IsValidMove(value))
            {
                BoardGame.Add(value);
                if (BoardGame.CheckIfWon())
                {
                    return BoardGame.ShowWinner();
                }
                if (BoardGame.CheckIfTie())
                {
                    return BoardGame.ShowTie();
                }
                BoardGame.ChangePlayer();
            }
            return BoardGame.MyBoard;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
