using AutoMapper;
using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.ProductDtos;

namespace HizliSec.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(ProductAddDto productAddDto)
        {
            Product product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.ProductDal.AddAsync(product);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            List<Product> products = await _unitOfWork.ProductDal.GetAllAsync();
            List<ProductDto> productDtos = new();
            foreach (Product product in products)
            {
                ProductDto productDto = _mapper.Map<ProductDto>(product);
                productDtos.Add(productDto);
            }
            return productDtos;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            Product product = await _unitOfWork.ProductDal.GetAsync(x => x.Id == id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
