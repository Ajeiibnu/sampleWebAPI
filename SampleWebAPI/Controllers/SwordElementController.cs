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
    public class SwordElementController : ControllerBase
    {
        private readonly ISwordElement _swordElementsDAL;
        private readonly IMapper _mapper;
        public SwordElementController(ISwordElement swordElementsDAL, IMapper mapper)
        {
            _swordElementsDAL = swordElementsDAL;
            _mapper = mapper;
        }

        [HttpGet("GetSwordElement")]
        public async Task<IEnumerable<SwordAddElementDTO>> Get()
        {
            var swordElementDal = await _swordElementsDAL.GetAll();
            var swordElementDto = _mapper.Map<IEnumerable<SwordAddElementDTO>>(swordElementDal);

            return swordElementDto;
        }

        [HttpPost("InsertSwordElement")]
        public async Task<ActionResult> Post(SwordAddElementDTO SwordAddElementDTO)
        {
            try
            {
                var swordElementDto = _mapper.Map<SwordElement>(SwordAddElementDTO);
                var newSwordElement = await _swordElementsDAL.Insert(swordElementDto);
                var swordElementReadDto = _mapper.Map<SwordAddElementDTO>(newSwordElement);

                return CreatedAtAction("Get", 
                    new { id = newSwordElement.SwordId }, swordElementReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteSwordElement")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _swordElementsDAL.Delete(id);
                return Ok($"Delete Data Element Dengan Id {id} pada Data Sword Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
