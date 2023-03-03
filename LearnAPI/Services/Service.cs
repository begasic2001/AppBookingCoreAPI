using AutoMapper;
using NuGet.Protocol.Core.Types;
using TourBooking.Dto;
using TourBooking.Repositories;
using System.Linq.Expressions;
using System;

namespace TourBooking.Services
{
    public class Service<TEntity, TDto> : IService<TEntity, TDto> 
        where TDto : Entity where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public Service(IRepository<TEntity> repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<string> AddAsync(TDto tDto)
        {
            var entity =  _mapper.Map<TEntity>(tDto);  
            await _repository.AddAsync(entity);
            return tDto.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var hasEntity = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(hasEntity);
        }

        public async Task<IEnumerable<TDto>> GetAll(Expression<Func<TDto, bool>> expression = null)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            return _repository.GetAll(predicate).Select(_mapper.Map<TDto>).ToList();
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> GetFirstAsync(Expression<Func<TDto, bool>> expression)
        {
            var predicate = _mapper.Map<Expression<Func<TEntity, bool>>>(expression);
            var entity = await _repository.GetFirstAsync(predicate);
            return _mapper.Map<TDto>(entity);
        }

        public Task UpdateAsync(TDto entityTDto)
        {
            var entity = _mapper.Map<TEntity>(entityTDto);
            return _repository.UpdateAsync(entity);
        }
    }
}
