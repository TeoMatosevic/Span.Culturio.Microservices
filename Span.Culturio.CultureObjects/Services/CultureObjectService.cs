using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Span.Culturio.Core.Models.CultureObject;
using Span.Culturio.CultureObjects.Data;

namespace Span.Culturio.CultureObjects.Services {
    public class CultureObjectService : ICultureObjectService {

        public CultureObjectService(DataContext dataContext, IMapper mapper) {
            _context = dataContext;
            _mapper = mapper;
        }

        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public async Task<CultureObjectDto> CreateCultureObjectAsync(CreateCultureObjectDto createCultureObjectDto) {
            var cultureObject = _mapper.Map<Data.Entities.CultureObject>(createCultureObjectDto);
            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);

            _context.Add(cultureObject);
            await _context.SaveChangesAsync();

            return cultureObjectDto;
        }

        public async Task<CultureObjectDto> GetCultureObjectAsync(int id) {
            var cultureObject = await _context.CultureObjects.FindAsync(id);
            if (cultureObject is null) {
                return null;
            }
            var cultureObjectDto = _mapper.Map<CultureObjectDto>(cultureObject);

            return cultureObjectDto;
        }

        public async Task<IEnumerable<CultureObjectDto>> GetCultureObjectsAsync() {
            var cultureObjects = await _context.CultureObjects.ToListAsync();
            var cultureObjectsDto = _mapper.Map<List<CultureObjectDto>>(cultureObjects);

            return cultureObjectsDto;
        }
    }
}
