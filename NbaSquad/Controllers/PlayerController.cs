using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NbaSquad.Data;
using NbaSquad.Dto;
using NbaSquad.Interfaces;
using NbaSquad.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NbaSquad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(DataContext context, IMapper mapper, IPlayerRepository playerRepository)
        {
            _context = context;
            _mapper = mapper;
            _playerRepository = playerRepository;
        }

        // GET: api/<PlayerController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var playerData = await _playerRepository.GetPlayers();
            var player = _mapper.Map<List<PlayerResponse>>(playerData);

            return Ok(player);
        }

        // GET api/<PlayerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var playerData = await _playerRepository.GetPlayer(id);
            var player = _mapper.Map<PlayerResponse>(playerData);

            if (!ModelState.IsValid)
            {
                return BadRequest("Not Found");
            }

            return Ok(player);
        }

        // POST api/<PlayerController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PlayerDto player)
        {
            var playerMap = _mapper.Map<Player>(player);
            await _playerRepository.CreatePlayer(playerMap);
            return Ok(playerMap);
        }

        // PUT api/<PlayerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] PlayerDto player)
        {
            if (id != player.Id)
            {
                return BadRequest();
            }
            var playerMap = _mapper.Map<Player>(player);
            await _playerRepository.UpdatePlayer(playerMap);
            return Ok(playerMap);
        }

        // DELETE api/<PlayerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var player = await _playerRepository.GetPlayer(id);
            await _playerRepository.DeletePlayer(player);
            return Ok(player);
        }
    }
}
