using CoreBusiness;

namespace UseCases.Interfaces
{
    public interface IViewProductUseCase
    {
        IEnumerable<Product> Execute(bool loadCategory = false);
    }
}