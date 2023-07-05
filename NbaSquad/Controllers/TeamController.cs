using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NbaSquad.Dto;
using NbaSquad.Interfaces;
using NbaSquad.Models;
using NbaSquad.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NbaSquad.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;

        public TeamController(IMapper mapper, ITeamRepository teamRepository)
        {
            _mapper = mapper;
            _teamRepository = teamRepository;
        }
        // GET: api/<_>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var team = await _teamRepository.GetTeams();
            var teamMap = _mapper.Map<List<TeamResponse>>(team);

            return Ok(teamMap);
        }

        // GET api/<_>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var team = await _teamRepository.GetTeam(id);
            var teamMap = _mapper.Map<TeamResponse>(team);

            return Ok(teamMap);
        }

        // POST api/<_>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TeamDto teamDto)
        {
            var teamMap = _mapper.Map<Team>(teamDto);
            await _teamRepository.CreateTeam(teamMap);

            return Ok(teamMap);
        }

        // PUT api/<_>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TeamDto teamDto)
        {
            if (id != teamDto.Id)
            {
                return BadRequest();
            }
            var teamMap = _mapper.Map<Team>(teamDto);
            await _teamRepository.UpdateTeam(teamMap);

            return Ok(teamMap);
        }

        // DELETE api/<_>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var team = await _teamRepository.GetTeam(id);
            var teamMap = _mapper.Map<Team>(team);

            await _teamRepository.DeleteTeam(teamMap);
            return Ok(teamMap);
        }
    }
}