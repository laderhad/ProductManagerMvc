namespace WebApplication4.Web.Models
{
	public class ProductRepository
	{
		private static List<Product> _products=new List<Product>()
		{
				new() { Id = 1, Name = "Kalem1", Price=500,Stock=300},
				new () { Id = 2, Name = "Kalem2", Price=600,Stock=300},
                new () { Id = 3, Name = "Kalem3", Price=400,Stock=300},

		};


		public List<Product> GetAll() => _products;
		
		public void Add(Product newProduct)=>_products.Add(newProduct);

		public void Remove(int id)
		{
			var hasProduct = _products.FirstOrDefault(x=>x.Id==id);

            if (hasProduct==null)
            {
				throw new Exception($"Bu id({id}) sahip ürün bulunmamaktadır. ");
            }

			_products.Remove(hasProduct);
        }
		public void Update(Product updateProduct)
		{
			var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id );
			if (hasProduct==null)
			{
				throw new Exception($"Bu id({updateProduct.Id}) sahip ürün bulunmamaktadır. ");
			}
			hasProduct.Name = updateProduct.Name;
			hasProduct.Price = updateProduct.Price;
			hasProduct.Stock = updateProduct.Stock;

			var index=_products.FindIndex(x=>x.Id==updateProduct.Id);
			_products[index] = hasProduct;
		}

	}
}
