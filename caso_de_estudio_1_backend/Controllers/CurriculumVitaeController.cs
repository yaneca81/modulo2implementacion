using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace caso_de_estudio_1_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumVitaeController : ControllerBase
    {
        private readonly ICommonService<CurriculumVitaeDto, CurriculumVitaeCreateDto, CurriculumVitaeUpdateDto> _service;

        public CurriculumVitaeController([FromKeyedServices("CurriculumVitaeService")] ICommonService<CurriculumVitaeDto, CurriculumVitaeCreateDto, CurriculumVitaeUpdateDto> service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<IEnumerable<CurriculumVitaeDto>>>> Get()
        {
            try
            {
                var curriculumVitaes = await _service.Get();
                return Ok(new ApiResponse<IEnumerable<CurriculumVitaeDto>>
                {
                    Ok = true,
                    Message = "CVs recuperados con éxito",
                    Data = curriculumVitaes
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<IEnumerable<CurriculumVitaeDto>>
                {
                    Ok = false,
                    Message = "Error al recuperar CVs",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<CurriculumVitaeDto>>> GetById(int id)
        {
            try
            {
                var curriculumVitae = await _service.GetById(id);
                if (curriculumVitae == null)
                {
                    return NotFound(new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = false,
                        Message = $"CV con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = true,
                    Message = "CV recuperado con éxito",
                    Data = curriculumVitae
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = false,
                    Message = "Error al recuperar CV",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<CurriculumVitaeDto>>> Create([FromForm] CurriculumVitaeCreateDto curriculumVitaeCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var createdCurriculumVitae = await _service.Add(curriculumVitaeCreateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdCurriculumVitae.Id },
                    new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = true,
                        Message = "CV creado exitosamente",
                        Data = createdCurriculumVitae
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = false,
                    Message = "Error al crear CV",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<CurriculumVitaeDto>>> Update(int id, [FromForm] CurriculumVitaeUpdateDto curriculumVitaeUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var updatedCurriculumVitae = await _service.Update(id, curriculumVitaeUpdateDto);
                if (updatedCurriculumVitae == null)
                {
                    return NotFound(new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = false,
                        Message = $"CV con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = true,
                    Message = "CV actualizado con éxito",
                    Data = updatedCurriculumVitae
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = false,
                    Message = "Error al actualizar CV",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<CurriculumVitaeDto>>> Delete(int id)
        {
            try
            {
                var deletedCurriculumVitae = await _service.Delete(id);
                if (deletedCurriculumVitae == null)
                {
                    return NotFound(new ApiResponse<CurriculumVitaeDto>
                    {
                        Ok = false,
                        Message = $"CV con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = true,
                    Message = "CV eliminado con éxito",
                    Data = deletedCurriculumVitae
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<CurriculumVitaeDto>
                {
                    Ok = false,
                    Message = "Error al eliminar CV",
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
