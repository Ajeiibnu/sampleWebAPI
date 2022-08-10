using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleWebAPI.Data.DAL;
using SampleWebAPI.Domain;
using SampleWebAPI.DTO;
using SampleWebAPI.Helpers;
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly IAttrElement _ElementDAL;
        private readonly IMapper _mapper;
        public ElementsController(IAttrElement ElementDAL, IMapper mapper)
        {
            _ElementDAL = ElementDAL;
            _mapper = mapper;
        }

        [HttpGet("GetAttributeElement")]
        public async Task<IEnumerable<AttrElementReadDTO>> Get()
        {
            var elementDal = await _ElementDAL.GetAll();
            var elementDto = _mapper.Map<IEnumerable<AttrElementReadDTO>>(elementDal);

            return elementDto;
        }

        [HttpGet("GetAttributeElementById")]
        public async Task<AttrElementReadDTO> Get(int id)
        {
            var elementDal = await _ElementDAL.GetById(id);
            if (elementDal == null)
                throw new Exception($"data {id} tidak ditemukan");
            var elementDto = _mapper.Map<AttrElementReadDTO>(elementDal);

            return elementDto;
        }

        [HttpGet("GetAttributeElementByName")]
        public async Task<IEnumerable<AttrElementReadDTO>> GetByName(string name)
        {
            var elementDal = await _ElementDAL.GetByName(name);
            var elementDto = _mapper.Map<IEnumerable<AttrElementReadDTO>>(elementDal);
            return elementDto;
        }

        [HttpPost("InsertAttributeElement")]
        public async Task<ActionResult> Post(AttrElementCreateDTO ElementCreateDTO)
        {
            try
            {
                var elementDto = _mapper.Map<AttrElement>(ElementCreateDTO);
                var newElement = await _ElementDAL.Insert(elementDto);
                var elementReadDTO = _mapper.Map<AttrElementReadDTO>(newElement);

                return CreatedAtAction("Get", elementReadDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateAttributeElement")]
        public async Task<ActionResult> Put(AttrElementReadDTO elemenReadtDto)
        {
            try
            {
                var elementDto = _mapper.Map<AttrElement>(elemenReadtDto);
                var updateElement = await _ElementDAL.Update(elementDto);
                
                return CreatedAtAction("Get", new 
                { id = updateElement.AttrElementId }, elemenReadtDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteAttributeElement")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ElementDAL.Delete(id);
                return Ok($"Delete Data Attribute Element Dengan Id {id} Berhasil");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
