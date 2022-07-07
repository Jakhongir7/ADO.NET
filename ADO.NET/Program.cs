using Libraries;
using Libraries.Entities;
using System;

namespace ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            const string connectionString = "Data Source = localhost\\SQLEXPRESS; Initial Catalog = Shop; Integrated Security = True";

            var unitOfWork = new UnitOfWork(connectionString);
            DateTime d = DateTime.Now;
            unitOfWork.Products.Create(new Product()
            {
                Name = "ProductName1",
                Description = "ProductDescription",
                Height = 100,
                Length = 200,
                Weight = 101,
                Width = 200
            });

            unitOfWork.Orders.Create(new Order()
            {
                Status = OrderStatus.InProgress,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                ProductId = 1
            });
        }
    }
}
