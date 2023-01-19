using Core.Specifications;

namespace API.Controllers
{
    internal class ProductsWithFiltersForCountSpecification
    {
        private ProductSpecParams productParams;

        public ProductsWithFiltersForCountSpecification(ProductSpecParams productParams)
        {
            this.productParams = productParams;
        }
    }
}