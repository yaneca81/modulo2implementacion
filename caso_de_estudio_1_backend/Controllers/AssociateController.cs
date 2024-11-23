using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace caso_de_estudio_1_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        private readonly ICommonService<AssociateDto, AssociateCreateDto, AssociateUpdateDto> _service;
        public AssociateController([FromKeyedServices("AssociateService")] ICommonService<AssociateDto, AssociateCreateDto, AssociateUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<IEnumerable<AssociateDto>>>> Get()
        {
            try
            {
                var associates = await _service.Get();
                return Ok(new ApiResponse<IEnumerable<AssociateDto>>
                {
                    Ok = true,
                    Message = "Asociados recuperados con éxito",
                    Data = associates
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<IEnumerable<AssociateDto>>
                {
                    Ok = false,
                    Message = "Error al recuperar asociados",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<AssociateDto>>> GetById(int id)
        {
            try
            {
                var associate = await _service.GetById(id);
                if (associate == null)
                {
                    return NotFound(new ApiResponse<AssociateDto>
                    {
                        Ok = false,
                        Message = $"Asociado con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<AssociateDto>
                {
                    Ok = true,
                    Message = "Asociado recuperado con éxito",
                    Data = associate
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<AssociateDto>
                {
                    Ok = false,
                    Message = "Error al recuperar asociado",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<AssociateDto>>> Create([FromBody] AssociateCreateDto associateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<AssociateDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var createdAssociate = await _service.Add(associateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdAssociate.Id },
                    new ApiResponse<AssociateDto>
                    {
                        Ok = true,
                        Message = "Asociado creado con éxito",
                        Data = createdAssociate
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<AssociateDto>
                {
                    Ok = false,
                    Message = "Error al crear asociado",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<AssociateDto>>> Update(int id, [FromBody] AssociateUpdateDto associateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<AssociateDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var updatedAssociate = await _service.Update(id, associateDto);
                if (updatedAssociate == null)
                {
                    return NotFound(new ApiResponse<AssociateDto>
                    {
                        Ok = false,
                        Message = $"Asociado con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<AssociateDto>
                {
                    Ok = true,
                    Message = "Asociado actualizado con éxito",
                    Data = updatedAssociate
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<AssociateDto>
                {
                    Ok = false,
                    Message = "Error al actualizar asociado",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<AssociateDto>>> Delete(int id)
        {
            try
            {
                var deletedAssociate = await _service.Delete(id);
                if (deletedAssociate == null)
                {
                    return NotFound(new ApiResponse<AssociateDto>
                    {
                        Ok = false,
                        Message = $"Asociado con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<AssociateDto>
                {
                    Ok = true,
                    Message = "Asociado eliminado exitosamente",
                    Data = deletedAssociate
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<AssociateDto>
                {
                    Ok = false,
                    Message = "Error al eliminar asociado",
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
