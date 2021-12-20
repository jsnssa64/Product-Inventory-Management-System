using Data.Migrations;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public static class DbInitializer
    {
        public async static void Initializer(AppDbContext context)
        {
            if(context.Products.Any())
            {
                return; //  Db Has been Seeded
            }

            var brands = new Brand[]
            {
                new Brand{Name="Waitrose"}
            };

            await context.Brands.AddRangeAsync(brands);
            context.SaveChanges();

            var productType = new ProductType[]
            {
                new ProductType{Title="Semi Skimmed Milk",Type="Milk"},
                new ProductType{Title="Essential Carrots",Type="Carrot"},
                new ProductType{Title="Tenderstem Broccoli Spears",Type="Broccoli"}
            };

            await context.ProductType.AddRangeAsync(productType);
            context.SaveChanges();

            var products = new Product[]
            {
                new Product
                {
                    Name="Essential Semi Skimmed Milk",
                    ProductDescription = new ProductDescription
                    {
                        Description="fresh pasteurised homogenised semi-skimmed milk. We guarantee that all the cows that provide our fresh milk and cream spend at least 120 days a year grazing."
                    },
                    ProductTypesBrand=new ProductType_Brand
                    {
                        BrandId = brands.First(x=> x.Name =="Waitrose").BrandId,
                        ProductTypeId=productType.First(x=> x.Type == "Milk").Id,
                    }
                },
                new Product
                {
                    Name="Essential Carrots",
                    ProductDescription = new ProductDescription
                    {
                        Description="Our fundamental belief is that few things in life are more important than the food you buy. And just because you're shopping for everday items, you don't have to compromise on quality. Good quality is essential."
                    },
                    ProductTypesBrand=new ProductType_Brand
                    {
                        BrandId = brands.First(x=> x.Name =="Waitrose").BrandId,
                        ProductTypeId=productType.First(x=> x.Type == "Carrot").Id,
                    }
                },
                new Product
                {
                    Name="Essential Tenderstem Broccoli",
                    ProductDescription = new ProductDescription
                    {
                        Description="Our fundamental belief is that few things in life are more important than the food you buy. And just because you're shopping for everday items, you don't have to compromise on quality. Good quality is essential."
                    },
                    ProductTypesBrand=new ProductType_Brand
                    {
                        BrandId = brands.First(x=> x.Name =="Waitrose").BrandId,
                        ProductTypeId=productType.First(x=> x.Type == "Broccoli").Id
                    }
                }
            };

            await context.Products.AddRangeAsync(products);
            context.SaveChanges();

            var productItems = new ProductItem[] {
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Semi Skimmed Milk").Id,
                            WeightPerUnit=250,
                            ItemsPerUnit=1,
                            UnitName="ml"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Semi Skimmed Milk").Id,
                            WeightPerUnit=500,
                            ItemsPerUnit=1,
                            UnitName="ml"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Semi Skimmed Milk").Id,
                            WeightPerUnit=1,
                            ItemsPerUnit=1,
                            UnitName="l"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Carrots").Id,
                            WeightPerUnit=250,
                            UnitName="g"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Carrots").Id,
                            WeightPerUnit=500,
                            UnitName="g"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Carrots").Id,
                            WeightPerUnit=1,
                            UnitName="kg"
                        },
                        new ProductItem
                        {
                            ProductId=products.First(x=> x.Name == "Essential Tenderstem Broccoli").Id,
                            WeightPerUnit=200,
                            UnitName="g"
                        }
                    };

            await context.ProductItem.AddRangeAsync(productItems);
            context.SaveChanges();
        }
    }
}
