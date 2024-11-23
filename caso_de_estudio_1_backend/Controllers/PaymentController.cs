using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Service;
using Microsoft.AspNetCore.Mvc;

namespace caso_de_estudio_1_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ICommonService<PaymentDto, PaymentCreateDto, PaymentUpdateDto> _service;
        public PaymentController([FromKeyedServices("PaymentService")] ICommonService<PaymentDto, PaymentCreateDto, PaymentUpdateDto> service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<IEnumerable<PaymentDto>>>> Get()
        {
            try
            {
                var payments = await _service.Get();
                return Ok(new ApiResponse<IEnumerable<PaymentDto>>
                {
                    Ok = true,
                    Message = "Pagos recuperados exitosamente",
                    Data = payments
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<IEnumerable<PaymentDto>>
                {
                    Ok = false,
                    Message = "Error al recuperar pagos",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> GetById(int id)
        {
            try
            {
                var payment = await _service.GetById(id);
                if (payment == null)
                {
                    return NotFound(new ApiResponse<PaymentDto>
                    {
                        Ok = false,
                        Message = $"Pago con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<PaymentDto>
                {
                    Ok = true,
                    Message = "Pago recuperado exitosamente",
                    Data = payment
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PaymentDto>
                {
                    Ok = false,
                    Message = "Error al recuperar el pago",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> Create([FromBody] PaymentCreateDto paymentCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<PaymentDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var createdPayment = await _service.Add(paymentCreateDto);
                return CreatedAtAction(
                    nameof(GetById),
                    new { id = createdPayment.Id },
                    new ApiResponse<PaymentDto>
                    {
                        Ok = true,
                        Message = "Pago creado exitosamente",
                        Data = createdPayment
                    }
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PaymentDto>
                {
                    Ok = false,
                    Message = "Error al crear el pago",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> Update(int id, [FromBody] PaymentUpdateDto paymentUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new ApiResponse<PaymentDto>
                    {
                        Ok = false,
                        Message = "Entrada no válida",
                        Errors = ModelState.Values
                            .SelectMany(v => v.Errors)
                            .Select(e => e.ErrorMessage)
                            .ToArray()
                    });
                }

                var updatedPayment = await _service.Update(id, paymentUpdateDto);
                if (updatedPayment == null)
                {
                    return NotFound(new ApiResponse<PaymentDto>
                    {
                        Ok = false,
                        Message = $"Pago con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<PaymentDto>
                {
                    Ok = true,
                    Message = "pago actualizado exitosamente",
                    Data = updatedPayment
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PaymentDto>
                {
                    Ok = false,
                    Message = "Error al actualizar el pago",
                    Errors = new[] { ex.Message }
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<PaymentDto>>> Delete(int id)
        {
            try
            {
                var deletedPayment = await _service.Delete(id);
                if (deletedPayment == null)
                {
                    return NotFound(new ApiResponse<PaymentDto>
                    {
                        Ok = false,
                        Message = $"Pago con ID {id} no encontrado"
                    });
                }

                return Ok(new ApiResponse<PaymentDto>
                {
                    Ok = true,
                    Message = "Pago eliminado exitosamente",
                    Data = deletedPayment
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<PaymentDto>
                {
                    Ok = false,
                    Message = "Error al eliminar el pago",
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
