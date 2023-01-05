using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecifcation<Product>
    {
        private int id;

        public ProductsWithTypesAndBrandsSpecification(int id)
        {
            this.id = id;
        }

        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
        : base(x => 
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
        ))

        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex -1), productParams.PageSize);

            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                     AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }


    }
}