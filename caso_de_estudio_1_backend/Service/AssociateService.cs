using AutoMapper;
using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Models;
using caso_de_estudio_1_backend.Repository;

namespace caso_de_estudio_1_backend.Service
{
    public class AssociateService : ICommonService<AssociateDto, AssociateCreateDto, AssociateUpdateDto>
    {
        private readonly ICommonRepository<Associate> _repository;
        private readonly IMapper _mapper;
        public AssociateService(ICommonRepository<Associate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<AssociateDto>> Get()
        {
            var associates = await _repository.Get();
            return _mapper.Map<IEnumerable<AssociateDto>>(associates);
        }

        public async Task<AssociateDto> GetById(int id)
        {
            var associate = await _repository.GetById(id);
            return associate == null ? null : _mapper.Map<AssociateDto>(associate);
        }

        public async Task<AssociateDto> Add(AssociateCreateDto associateCreateDto)
        {
            var associate = _mapper.Map<Associate>(associateCreateDto);
            associate.RegistrationDate = DateTime.UtcNow;
            associate.Status = "Active";

            await _repository.Add(associate);
            await _repository.Save();

            return _mapper.Map<AssociateDto>(associate);
        }

        public async Task<AssociateDto> Update(int id, AssociateUpdateDto associateUpdateDto)
        {
            var associate = await _repository.GetById(id);
            if (associate == null)
                return null;

            _mapper.Map(associateUpdateDto, associate);
            _repository.Update(associate);
            await _repository.Save();

            return _mapper.Map<AssociateDto>(associate);
        }

        public async Task<AssociateDto> Delete(int id)
        {
            var associate = await _repository.GetById(id);
            if (associate == null)
                return null;

            var associateDto = _mapper.Map<AssociateDto>(associate);
            _repository.Delete(associate);
            await _repository.Save();

            return associateDto;
        }
    }
}
