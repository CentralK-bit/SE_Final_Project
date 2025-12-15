using System.Collections.Generic;
using MyProject.DAL;
using MyProject.DTO;

namespace MyProject.BLL
{
    public class ProductService
    {
        private readonly ProductRepository _repo = new();

        public List<ProductDTO> GetProducts()
            => _repo.GetAll();

        public void AddProduct(ProductDTO p)
        {
            if (string.IsNullOrWhiteSpace(p.ProductName))
                return;

            _repo.Add(p);
        }

        public void UpdateProduct(ProductDTO p)
            => _repo.Update(p);

        public void DeleteProduct(int id)
            => _repo.Delete(id);
    }
}