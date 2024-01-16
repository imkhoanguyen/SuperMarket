using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IViewSelectedCategoryUseCase
    {
        Category? Execute(int categoryId);
    }
}