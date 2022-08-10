using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;

namespace SampleWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SwordsController : ControllerBase
    {
        private readonly ISword _swordDAL;
        private readonly IMapper _mapper;
        public SwordsController(ISword swordDAL, IMapper mapper)
        {
            _swordDAL = swordDAL;
            _mapper = mapper;
        }

        [HttpGet("GetSword")]
        public async Task<IEnumerable<SwordReadDTO>> Get()
        {
            var swordDal = await _swordDAL.GetAll();
            var swordDto = _mapper.Map<IEnumerable<SwordReadDTO>>(swordDal);

            return swordDto;
        }

        [HttpGet("GetSwordByName")]
        public async Task<IEnumerable<SwordReadDTO>> GetByName(string name)
        {
            var swordDal = await _swordDAL.GetByName(name);
            var swordReadDto = _mapper.Map<IEnumerable<SwordReadDTO>>(swordDal);
            return swordReadDto;
        }

        [HttpGet("GetWithType")]
        public async Task<IEnumerable<SwordWithTypeReadDTO>> GetSwordType()
        {
            var swordDal = await _swordDAL.GetSwordType();
            var swordDto = _mapper.Map<IEnumerable<SwordWithTypeReadDTO>>(swordDal);
            return swordDto;
        }

        [HttpGet("GetWithTypePagging")]
        public async Task<IEnumerable<SwordWithTypeReadDTO>> GetSwordTypePagging(int pagenumber)
        {
            var swordDal = await _swordDAL.GetSwordType();
            var swordDto = _mapper.Map<IEnumerable<SwordWithTypeReadDTO>>(swordDal);
            var pagging = swordDto.Skip((pagenumber-1)*10).Take(10).ToList();
            return pagging;
        }

        [HttpGet("GetWithType-Element")]
        public async Task<IEnumerable<SwordTypeElementDTO>> GetAllField()
        {
            var swordDal = await _swordDAL.GetAllField();
            var swordDto = _mapper.Map<IEnumerable<SwordTypeElementDTO>>(swordDal);
            return swordDto;
        }

        [HttpPost("InsertNewSword")]
        public async Task<ActionResult> Post(SwordCreateDTO swordCreateDto)
        {
            try
            {
                var swordDto = _mapper.Map<Sword>(swordCreateDto);
                var newSword = await _swordDAL.Insert(swordDto);
                var swordReadDto = _mapper.Map<SwordReadDTO>(newSword);

                return CreatedAtAction("Get", 
                    new { id = newSword.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("InsertNewSwordWithType")]
        public async Task<ActionResult> Post(SwordWithTypeCreateDTO swordWithTypeCreate)
        {
            try
            {
                var swordDto = _mapper.Map<Sword>(swordWithTypeCreate);
                var newSword = await _swordDAL.Insert(swordDto);
                var swordReadDto = _mapper.Map<SwordTypeElementDTO>(newSword);

                return CreatedAtAction("Get", new { id = newSword.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateSword")]
        public async Task<ActionResult> Put(SwordReadDTO swordReadDto)
        {
            try
            {
                var swordDto = _mapper.Map<Sword>(swordReadDto);
                var updateSword = await _swordDAL.Update(swordDto);

                return CreatedAtAction("Get", new { id = updateSword.Id }, swordReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        [HttpDelete("DeleteSword")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _swordDAL.Delete(id);
                return Ok($"Delete Data Sword Dengan Id {id} Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
