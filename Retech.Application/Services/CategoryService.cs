using AutoMapper;
using Retech.Application.Services.Interfaces;
using Retech.Core.DTOS;
using Retech.Core.Models;
using Retech.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Retech.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(Guid categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Guid categoryId, CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);
            if (category != null)
            {
                _mapper.Map(categoryDTO, category);
                await _categoryRepository.UpdateAsync(category);
            }
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            await _categoryRepository.DeleteAsync(categoryId);
        }
    }
}
