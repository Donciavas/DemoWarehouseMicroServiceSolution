﻿using DataAccess.DTOs;

namespace BusinessLogic.Services
{
    public interface IService<TEntity, T1> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> Get(T1 id);
        Task<ResponseDto> Add(TEntity entity);
        Task<ResponseDto> Update(TEntity entity);
        Task<ResponseDto> Remove(T1 id);
    }
}
