using AutoMapper;
using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Models;
using caso_de_estudio_1_backend.Repository;

namespace caso_de_estudio_1_backend.Service
{
    public class PaymentService:ICommonService<PaymentDto, PaymentCreateDto, PaymentUpdateDto>
    {
        private readonly ICommonRepository<Payment> _repository;
        private readonly IMapper _mapper;
        public PaymentService(ICommonRepository<Payment> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PaymentDto>> Get()
        {
            var payments = await _repository.Get();
            return _mapper.Map<IEnumerable<PaymentDto>>(payments);
        }

        public async Task<PaymentDto> GetById(int id)
        {
            var payment = await _repository.GetById(id);
            return payment == null ? null : _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> Add(PaymentCreateDto paymentCreateDto)
        {
            var payment = _mapper.Map<Payment>(paymentCreateDto);
            payment.PaymentDate = DateTime.UtcNow;
            payment.Status = "Paid";

            await _repository.Add(payment);
            await _repository.Save();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> Update(int id, PaymentUpdateDto paymentUpdateDto)
        {
            var payment = await _repository.GetById(id);
            if (payment == null)
                return null;

            _mapper.Map(paymentUpdateDto, payment);
            _repository.Update(payment);
            await _repository.Save();

            return _mapper.Map<PaymentDto>(payment);
        }

        public async Task<PaymentDto> Delete(int id)
        {
            var payment = await _repository.GetById(id);
            if (payment == null)
                return null;

            var paymentDto = _mapper.Map<PaymentDto>(payment);
            _repository.Delete(payment);
            await _repository.Save();

            return paymentDto;
        }
    }
}
