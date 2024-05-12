using Core.Services;
using Core.Services.Result;
using Domain.DTOs.Marketing;
using Domain.FilterModels.Marketing;

namespace Business.Services.Marketing.Abstract;

public interface IStoreProductService : IService
{
    Task<ServiceObjectResult<StoreProductGetDto?>> GetByIdAsync(string id);

    Task<ServiceCollectionResult<StoreProductGetDto>> GetListAsync(StoreProductFilterModel? filterModel, int page,
        int pageSize);

    Task<ServiceCollectionResult<StoreProductGetDto>> GetByUserIdAsync(string userId,
        StoreProductFilterModel? filterModel,
        int page, int pageSize);

    Task<ServiceObjectResult<StoreProductGetDto?>> AddAsync(StoreProductAddDto productAddDto);

    Task<ServiceObjectResult<StoreProductGetDto?>> AddToShoppingListAsync(
        StoreProductManipulateShoppingListDto productManipulateShoppingListDto);

    Task<ServiceObjectResult<StoreProductGetDto?>> RemoveFromShoppingListAsync(
        StoreProductManipulateShoppingListDto productManipulateShoppingListDto);

    Task<ServiceCollectionResult<IList<string>>> GetAllShoppingListsAnonymously();

    Task<ServiceObjectResult<StoreProductGetDto?>> UpdateAsync(StoreProductUpdateDto productUpdateDto);

    Task<ServiceObjectResult<StoreProductGetDto?>> DeleteByIdAsync(string id);
}