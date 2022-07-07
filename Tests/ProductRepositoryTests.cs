using Libraries.Entities;
using Libraries.Repositories;
using NUnit.Framework;
using System;
using System.Linq;
using System.Text.Json;
using System.Web;

namespace Tests
{
    public class ProductRepositoryTests
    {
        private const string ConnectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Shop; Integrated Security = True";
        private IRepository<Product> _productRepository;
        private Product _product;

        [OneTimeSetUp]
        public void Setup()
        {
            _productRepository = new ProductRepository(ConnectionString);
            _product = new Product
            {
                Name = "ProductName1",
                Description = "ProductDescription",
                Height = 100,
                Length = 200,
                Weight = 101,
                Width = 200
            };
        }

        [Test]
        [Order(1)]
        public void Create_Product_InsertsProductIntoDB()
        {
            var expected = _product;

            _productRepository.Create(_product);
            var actual = _productRepository.GetAll().Last();
            expected.Id = actual.Id;

            Assert.AreEqual(JsonSerializer.Serialize(expected), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(2)]
        public void Read_ValidId_ReturnsProduct()
        {
            var expectedProduct = _product;
            expectedProduct.Id = _productRepository.GetAll().Last().Id;

            var actual = _productRepository.Read(expectedProduct.Id);

            Assert.AreEqual(JsonSerializer.Serialize(expectedProduct), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(3)]
        public void Read_NotValidId_ReturnsNull()
        {
            var actual = _productRepository.Read(10);

            Assert.IsNull(actual);
        }

        [Test]
        [Order(4)]
        public void Update_Product_UpdateProductInDB()
        {
            var expectedProduct = _product;
            expectedProduct.Id = _productRepository.GetAll().Last().Id;
            expectedProduct.Description = "new product description";

            _productRepository.Update(expectedProduct, expectedProduct.Id);

            var actual = _productRepository.Read(expectedProduct.Id);

            Assert.AreEqual(JsonSerializer.Serialize(expectedProduct), JsonSerializer.Serialize(actual));
        }

        [Test]
        [Order(5)]
        public void Delete_ValidId_DeleteProductInDB()
        {
            var id = _productRepository.GetAll().Last().Id;
            _productRepository.Delete(id);

            var actual = _productRepository.Read(id);

            Assert.IsNull(actual);
        }
    }
}
