using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.Example;
using BaseSolution.Application.DataTransferObjects.Example.Request;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Respone;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using Microsoft.EntityFrameworkCore;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
    public class ExampleReadOnlyRepository : IExampleReadOnlyRepository
    {
        private readonly DbSet<ExampleEntity> _exampleEntities;
        private readonly IMapper _mapper;
        private readonly ILocalizationService _localizationService;

        public ExampleReadOnlyRepository(IMapper mapper, ILocalizationService localizationService, ExampleReadOnlyDbContext dbContext)
        {
            _exampleEntities = dbContext.Set<ExampleEntity>();
            _mapper = mapper;
            _localizationService = localizationService;
        }

        public async Task<RequestResult<ExampleDto?>> GetExampleByIdAsync(Guid idExample, CancellationToken cancellationToken)
        {
            try
            {
                var example = await _exampleEntities.AsNoTracking().Where(c => c.Id == idExample && !c.Deleted).ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

                return RequestResult<ExampleDto?>.Succeed(example);
            }
            catch (Exception e)
            {
                return RequestResult<ExampleDto?>.Fail(_localizationService["Example is not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "example"
                    }
                });
            }
        }

        public async Task<RequestResult<PaginationResponse<ExampleDto>>> GetExampleWithPaginationByAdminAsync(ViewExampleWithPaginationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<ExampleEntity> queryable = _exampleEntities.AsNoTracking().AsQueryable();

                //Force to sort by id asc 
                IQueryable<ExampleEntity> finalQuery = queryable.OrderBy(x => x.Id);
                //IQueryable<ExampleEntity> hasPreviousQuery = queryable.OrderBy(x => x.Id);

                // Hit to the db to get data back to client side
                var result = await finalQuery
                    .ProjectTo<ExampleDto>(_mapper.ConfigurationProvider)
                .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize + 1)
                    .ToListAsync(cancellationToken);

                bool hasNext = result.Count == request.PageSize + 1;

                return RequestResult<PaginationResponse<ExampleDto>>.Succeed(new PaginationResponse<ExampleDto>()
                {
                    PageNumber = request.PageNumber,
                    PageSize = request.PageSize,
                    HasNext = hasNext,
                    Data = result.Take(request.PageSize).ToList()
                });
            }
            catch (Exception e)
            {
                return RequestResult<PaginationResponse<ExampleDto>>.Fail(_localizationService["List of example are not found"], new[]
                {
                    new ErrorItem
                    {
                        Error = e.Message,
                        FieldName = LocalizationString.Common.FailedToGet + "list of example"
                    }
                });
            }
        }
    }
}
