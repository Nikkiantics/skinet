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

        public ProductsWithTypesAndBrandsSpecification(string sort, int? brandId, int? typeId)
        : base(x => 
            (!brandId.HasValue || x.ProductBrandId == brandId &&
            (!typeId.HasValue || x.ProductTypeId == typeId)
        ))

        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
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