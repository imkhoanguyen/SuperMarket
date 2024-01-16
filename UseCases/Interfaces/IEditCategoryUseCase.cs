using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IEditCategoryUseCase
    {
        void Execute(int categoryId, Category category);
    }
}