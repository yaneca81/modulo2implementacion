using AutoMapper;
using caso_de_estudio_1_backend.DTOs;
using caso_de_estudio_1_backend.Helpers;
using caso_de_estudio_1_backend.Models;
using caso_de_estudio_1_backend.Repository;

namespace caso_de_estudio_1_backend.Service
{
    public class CurriculumVitaeService : ICommonService<CurriculumVitaeDto, CurriculumVitaeCreateDto, CurriculumVitaeUpdateDto>
    {
        private readonly ICommonRepository<CurriculumVitae> _repository;
        private readonly IMapper _mapper;
        private readonly LocalFileStorage _localFileStorage;
        private readonly string _container = "cv";
        public CurriculumVitaeService(ICommonRepository<CurriculumVitae> repository, IMapper mapper, LocalFileStorage localFileStorage)
        {
            _repository = repository;
            _mapper = mapper;
            _localFileStorage = localFileStorage;
        }

        public async Task<IEnumerable<CurriculumVitaeDto>> Get()
        {
            var curriculumVitaes = await _repository.Get();
            return _mapper.Map<IEnumerable<CurriculumVitaeDto>>(curriculumVitaes);
        }

        public async Task<CurriculumVitaeDto> GetById(int id)
        {
            var curriculumVitae = await _repository.GetById(id);
            return curriculumVitae == null ? null : _mapper.Map<CurriculumVitaeDto>(curriculumVitae);
        }

        public async Task<CurriculumVitaeDto> Add(CurriculumVitaeCreateDto curriculumVitaeCreateDto)
        {
            var curriculumVitae = _mapper.Map<CurriculumVitae>(curriculumVitaeCreateDto);
            if (curriculumVitaeCreateDto.File != null)
            {
                using (var memeryStream = new MemoryStream())
                {
                    await curriculumVitaeCreateDto.File.CopyToAsync(memeryStream);
                    var content = memeryStream.ToArray();
                    var extenstion = Path.GetExtension(curriculumVitaeCreateDto.File.FileName);
                    curriculumVitae.File = await _localFileStorage.SaveFile(content, extenstion, _container, curriculumVitaeCreateDto.File.ContentType);
                }
            }
            curriculumVitae.UploadDate = DateTime.UtcNow;
            curriculumVitae.LastUpdated = DateTime.UtcNow;

            await _repository.Add(curriculumVitae);
            await _repository.Save();

            return _mapper.Map<CurriculumVitaeDto>(curriculumVitae);
        }

        public async Task<CurriculumVitaeDto> Update(int id, CurriculumVitaeUpdateDto curriculumVitaeUpdateDto)
        {
            var curriculumVitae = await _repository.GetById(id);
            if (curriculumVitae == null)
                return null;

            curriculumVitae = _mapper.Map(curriculumVitaeUpdateDto, curriculumVitae);

            if (curriculumVitaeUpdateDto.File != null)
            {
                using (var memeryStream = new MemoryStream())
                {
                    await curriculumVitaeUpdateDto.File.CopyToAsync(memeryStream);
                    var content = memeryStream.ToArray();
                    var extenstion = Path.GetExtension(curriculumVitaeUpdateDto.File.FileName);
                    curriculumVitae.File = await _localFileStorage.SaveFile(content, extenstion, _container, curriculumVitaeUpdateDto.File.ContentType);
                }
            }


            _repository.Update(curriculumVitae);
            await _repository.Save();

            return _mapper.Map<CurriculumVitaeDto>(curriculumVitae);
        }

        public async Task<CurriculumVitaeDto> Delete(int id)
        {
            var curriculumVitae = await _repository.GetById(id);
            if (curriculumVitae == null)
                return null;

            var associateDto = _mapper.Map<CurriculumVitaeDto>(curriculumVitae);
            _repository.Delete(curriculumVitae);
            await _repository.Save();

            return associateDto;
        }
    }
}
