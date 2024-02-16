using HizliSec.Business.Abstract;
using HizliSec.Entities.Concrete;
using HizliSec.Entities.Concrete.Dtos.SellerProductDtos;

namespace HizliSec.Business.Concrete
{
    public class SellerProductManager : ISellerProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthService _authService;

        public SellerProductManager(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        // Saticiya urun eklenirken resimleri ile birlikte eklenecek
        public async Task<int> AddAsyn(SellerProductAddDto productSellerAddDto)
        {
            using (var transaction = await _unitOfWork.BeginTransactionAsync())
            {
                try
                {
                    Product product = await _unitOfWork.ProductDal.GetAsync(p => p.Name == productSellerAddDto.ProductName);
                    AppUser user = await _authService.GetUserAsync(productSellerAddDto.SellerUserName);

                    if (product == null)
                    {
                        product = new Product()
                        {
                            Name = productSellerAddDto.ProductName,
                            CategoryId = productSellerAddDto.CategoryId
                        };
                        await _unitOfWork.ProductDal.AddAsync(product);
                        await _unitOfWork.SaveAsync();
                    }

                    product.UnitInStock += productSellerAddDto.Quantity;
                    await _unitOfWork.ProductDal.UpdateAsync(product);
                    await _unitOfWork.SaveAsync();

                    SellerProduct sellerProduct = new SellerProduct()
                    {
                        Quantity = productSellerAddDto.Quantity,
                        Description = productSellerAddDto.Description,
                        ProductId = product.Id,
                        Price = productSellerAddDto.Price,
                        SellerId = user.Id
                    };

                    foreach (var item in productSellerAddDto.Pictures)
                    {
                        if (item.Length > 0)
                        {
                            var fileExtension = Path.GetExtension(item.FileName).ToLowerInvariant();
                            if (fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png" || fileExtension == ".gif")
                            {
                                using (var ms = new MemoryStream())
                                {
                                    item.CopyTo(ms);
                                    var fileBytes = ms.ToArray();
                                    string base64String = Convert.ToBase64String(fileBytes);
                                    var picture = new Picture
                                    {
                                        Image = base64String,
                                        ProductId = product.Id,
                                        SellerId = user.Id
                                    };
                                    sellerProduct.Pictures.Add(picture);
                                }
                            }
                        }
                    }
                    await _unitOfWork.SellerProductDal.AddAsync(sellerProduct);
                    await _unitOfWork.SaveAsync();
                    await transaction.CommitAsync();
                    return 1;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    return 0;
                }

            }
        }

        // Anasayfadaki Urunler
        public List<SellerProductDto> GetAllSellerAndProducts()
        {
            List<SellerProductDto> sellerProductDtos = new();
            var sellerProducts = _unitOfWork.SellerProductDal.SellerProductWithCategoryAndPictures().ToList();
            foreach (var sellerProduct in sellerProducts)
            {
                var sellerProductDto = new SellerProductDto
                {
                    ProductName = sellerProduct.Product.Name,
                    Description = sellerProduct.Description,
                    Price = sellerProduct.Price,
                    Quantity = sellerProduct.Quantity,
                    ProductId = sellerProduct.ProductId,
                    SellerId = sellerProduct.SellerId,
                    SellerCompanyName = sellerProduct.Seller.CompanyName,
                    SellerName = sellerProduct.Seller.AppUser.UserName
                };
                foreach (var item in sellerProduct.Pictures)
                {
                    string image = item.Image;
                    sellerProductDto.Pictures.Add(image);
                }
                sellerProductDtos.Add(sellerProductDto);
            }

            return sellerProductDtos;

        }
        // Satici Magazasindaki Urunler
        public List<SellerProductDto> GetProductsBySellerId(int sellerId)
        {

            List<SellerProductDto> sellerProductDtos = new();
            var sellerProducts = _unitOfWork.SellerProductDal.SellerProductWithCategoryAndPictures(x => x.SellerId == sellerId).ToList();
            foreach (var sellerProduct in sellerProducts)
            {
                var sellerProductDto = new SellerProductDto
                {
                    ProductName = sellerProduct.Product.Name,
                    Description = sellerProduct.Description,
                    Price = sellerProduct.Price,
                    Quantity = sellerProduct.Quantity,
                    ProductId = sellerProduct.ProductId,
                    SellerId = sellerProduct.SellerId,
                    SellerCompanyName = sellerProduct.Seller.CompanyName,
                    SellerName = sellerProduct.Seller.AppUser.UserName
                };
                foreach (var item in sellerProduct.Pictures)
                {
                    string image = item.Image;
                    sellerProductDto.Pictures.Add(image);
                }
                sellerProductDtos.Add(sellerProductDto);
            }

            return sellerProductDtos;
        }
    }
}
