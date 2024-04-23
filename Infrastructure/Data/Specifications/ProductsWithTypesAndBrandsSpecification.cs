using Core.Entities;
using Core.Specifications;

namespace Infrastructure.Data.Specifications;

public class ProductWithCategoryAndRatingSpecification : BaseSpecification<Product>
{
    public ProductWithCategoryAndRatingSpecification()
    {
        AddInclude();
    }

    public ProductWithCategoryAndRatingSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude();
    }

    private void AddInclude()
    {
        AddInclude(x => x.ProductCategory);
        AddInclude(x => x.ProductRating);
    }

}
