

using AutoMapper;
using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.CategoryDtos;

namespace HizliSec.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Add(CategoryAddDto categoryAddDto)
        {
            Category category = _mapper.Map<Category>(categoryAddDto);
            _unitOfWork.CategoryDal.AddAsync(category);
            return _unitOfWork.SaveAsync();
        }

        public async Task<CategoryWithProductDto> CategoryWithProduct(int categoryId)
        {
            Category category = await _unitOfWork.CategoryDal.GetCategoryAsync(categoryId);
            CategoryWithProductDto categoryWithProductDto = new CategoryWithProductDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.ToList()
            };
            return categoryWithProductDto;
        }

        public List<CategoryWithProductDto> CategoryWithProducts()
        {
            IQueryable<Category> categories = _unitOfWork.CategoryDal.CategoryWithProducts();
            List<CategoryWithProductDto> categoryWithProductDtos = new List<CategoryWithProductDto>();

            foreach (var category in categories)
            {
                var categoryDto = new CategoryWithProductDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    Products = category.Products.ToList()
                };

                categoryWithProductDtos.Add(categoryDto);
            }
            return categoryWithProductDtos;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            List<Category> categories = await _unitOfWork.CategoryDal.GetAllAsync();
            List<CategoryDto> categoryDtos = new List<CategoryDto>();
            foreach (var item in categories)
            {
                CategoryDto categoryDto = _mapper.Map<CategoryDto>(item);
                categoryDtos.Add(categoryDto);
            }
            return categoryDtos;
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            Category category = await _unitOfWork.CategoryDal.GetAsync(x => x.Id == id);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<int> Remove(int id)
        {
            Category category = await _unitOfWork.CategoryDal.GetAsync(x => x.Id == id);
            await _unitOfWork.CategoryDal.DeleteAsync(category);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> Uptade(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryDal.UpdateAsync(category);
            return await _unitOfWork.SaveAsync();
        }
    }
}
