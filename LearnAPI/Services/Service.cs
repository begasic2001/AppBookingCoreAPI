using AutoMapper;
using NuGet.Protocol.Core.Types;
using TourBooking.Dto;
using TourBooking.Repositories;
using System.Linq.Expressions;
using System;
using TourBooking.Interfaces;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
        public async Task AddAsync(TDto tDto)
        {
            var id = Guid.NewGuid().ToString();
            tDto.Id = id;
            var entity =  _mapper.Map<TEntity>(tDto);  
            await _repository.AddAsync(entity);
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

        public IEnumerable<TEntity> GetAllJoin(string[] includes = null)

        {
            return _repository.GetAllJoin(includes);
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

        public IEnumerable<TEntity> GetMultiJoin(Expression<Func<TEntity, bool>> expression, string[] includes = null)
        {
            return _repository.GetMultiJoin(expression, includes);
        }

        public IEnumerable<TEntity> GetMultiPagingJoin(Expression<Func<TEntity, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            return _repository.GetMultiPagingJoin(filter, out total, index, size, includes);    
        }

        public async Task UpdateAsync(string id,TDto entityTDto)
        {
            if(id == entityTDto.Id)
            {
                var entity = _mapper.Map<TEntity>(entityTDto);
                await _repository.UpdateAsync(entity);
            }
            
        }
    }
}
