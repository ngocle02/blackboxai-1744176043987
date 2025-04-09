using SchoolSuppliesStore.Models;
using System;
using System.Linq;

namespace SchoolSuppliesStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return; // DB has been seeded
            }

            var products = new Product[]
            {
                new Product {
                    Name = "Vở học sinh 200 trang",
                    Description = "Vở kẻ ngang 200 trang chất lượng cao",
                    Price = 15000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Notebook",
                    Category = "Vở"
                },
                new Product {
                    Name = "Bút bi Thiên Long TL-027",
                    Description = "Bút bi mực đen, nét 0.5mm",
                    Price = 5000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Pen",
                    Category = "Bút"
                },
                new Product {
                    Name = "Cặp sách học sinh",
                    Description = "Cặp sách chống gù, ngăn rộng",
                    Price = 250000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Bag",
                    Category = "Cặp sách"
                },
                new Product {
                    Name = "Thước kẻ 30cm",
                    Description = "Thước nhựa dẻo 30cm",
                    Price = 10000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Ruler",
                    Category = "Dụng cụ"
                },
                new Product {
                    Name = "Bút chì 2B",
                    Description = "Bút chì gỗ 2B, tẩy kèm theo",
                    Price = 8000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Pencil",
                    Category = "Bút"
                },
                new Product {
                    Name = "Tập giấy kiểm tra",
                    Description = "Tập giấy kiểm tra 50 tờ",
                    Price = 20000,
                    ImageUrl = "https://via.placeholder.com/300x300?text=Test+Paper",
                    Category = "Vở"
                }
            };

            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();
        }
    }
}
