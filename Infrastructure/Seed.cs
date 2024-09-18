using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Data;

namespace Infrastructure
{
    public class Seed
    {
        public static async Task SeedDataAsync(StoreContext context)
        {
            context.Products.ToList().ForEach(p => context.Products.Remove(p));
            context.ProductBrands.ToList().ForEach(pb => context.ProductBrands.Remove(pb));
            context.ProductTypes.ToList().ForEach(pt => context.ProductTypes.Remove(pt));
            context.SaveChanges();
            

            if (!context.ProductBrands.Any())
            {
                var productBrands = new List<ProductBrand>
                {
                    new ProductBrand { Id = Guid.Parse("a0b5ea7d-36f8-4258-b598-bd73fd4e8da4"), Name = "Mlekoje"},
                    new ProductBrand { Id = Guid.Parse("62e811e5-955c-4839-bfb7-0cda054c20ba"), Name = "Srbijanka"},
                    new ProductBrand { Id = Guid.Parse("e1ba3f48-594b-4308-8ab8-d69faa322e2a"), Name = "Motikokul"},
                    new ProductBrand { Id = Guid.Parse("653cc842-e8ba-4b1b-af05-72d7613b11f9"), Name = "Mesare kod Mice"},
                    new ProductBrand { Id = Guid.Parse("b60a16c2-5756-44d0-81a6-b26f30ccfe8c"), Name = "Mesi mesi nece da skodi"},
                    new ProductBrand { Id = Guid.Parse("88c46ef3-82f7-48e8-a055-a12bd3c32848"), Name = "Spajz rules"}
                };

                await context.ProductBrands.AddRangeAsync(productBrands);
                await context.SaveChangesAsync();
            }

            if (!context.ProductTypes.Any())
            {
                var productTypes = new List<ProductType>
                {
                    new ProductType { Id = Guid.Parse("e141e281-4c7d-4545-82be-662f3e0426d0"), Name = "Mlecni proizvodi"},
                    new ProductType { Id = Guid.Parse("d7f12307-7930-4b48-bdb5-c2a66ddac524"), Name = "Voce"},
                    new ProductType { Id = Guid.Parse("348d6a7a-98d1-45ac-9e7f-4cc3299e18c9"), Name = "Povrce"},
                    new ProductType { Id = Guid.Parse("fa186b9a-9b5d-4b07-8df5-3dccef273f9a"), Name = "Meso i mesne preradjevine"},
                    new ProductType { Id = Guid.Parse("294ec6d5-aed0-45c9-8604-36d0bfa1d5de"), Name = "Brasno i pekarski proizvodi"},
                    new ProductType { Id = Guid.Parse("6c9901dc-ca5f-41e2-92d8-cb4ddc3a4578"), Name = "Med i pcelinji proizvodi"}
                };

                await context.ProductTypes.AddRangeAsync(productTypes);
                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var products = new List<Product>
                {
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Zreli sir",
                        Description = "Zreli kravlji sir iz Sjenice",
                        Price = 750,
                        Currency = "RSD",
                        PictureUrl = "images/products/zreliSir.png",
                        ProductTypeId = Guid.Parse("e141e281-4c7d-4545-82be-662f3e0426d0"),
                        ProductBrandId = Guid.Parse("a0b5ea7d-36f8-4258-b598-bd73fd4e8da4"),
                        City = "Sjenica"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Zreli kajmak",
                        Description = "Zreli kajmak od kravljeg mleka iz Sjenice",
                        Price = 750,
                        Currency = "RSD",
                        PictureUrl = "images/products/domaciKajmak.png",
                        ProductTypeId = Guid.Parse("e141e281-4c7d-4545-82be-662f3e0426d0"),
                        ProductBrandId = Guid.Parse("a0b5ea7d-36f8-4258-b598-bd73fd4e8da4"),
                        City = "Sjenica"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sveza sljiva",
                        Description = "Sveza neprskana sljiva sorte cacanska lepotica",
                        Price = 75,
                        Currency = "RSD",
                        PictureUrl = "images/products/sljiva.png",
                        ProductTypeId = Guid.Parse("d7f12307-7930-4b48-bdb5-c2a66ddac524"),
                        ProductBrandId = Guid.Parse("62e811e5-955c-4839-bfb7-0cda054c20ba"),
                        City = "Valjevo"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kruska",
                        Description = "Sveza kruska viljamovka",
                        Price = 90,
                        Currency = "RSD",
                        PictureUrl = "images/products/kruska.png",
                        ProductTypeId = Guid.Parse("d7f12307-7930-4b48-bdb5-c2a66ddac524"),
                        ProductBrandId = Guid.Parse("62e811e5-955c-4839-bfb7-0cda054c20ba"),
                        City = "Valjevo"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Domaci paradajz",
                        Description = "Domaci neprskani paradajz",
                        Price = 350,
                        Currency = "RSD",
                        PictureUrl = "images/products/domaciParadajz.png",
                        ProductTypeId = Guid.Parse("348d6a7a-98d1-45ac-9e7f-4cc3299e18c9"),
                        ProductBrandId = Guid.Parse("e1ba3f48-594b-4308-8ab8-d69faa322e2a"),
                        City = "Donji Petrovci"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Crvena paprika",
                        Description = "Crvena neprsana paprika sorte slonovo uvo",
                        Price = 120,
                        Currency = "RSD",
                        PictureUrl = "images/products/crvenaPaprika.png",
                        ProductTypeId = Guid.Parse("348d6a7a-98d1-45ac-9e7f-4cc3299e18c9"),
                        ProductBrandId = Guid.Parse("e1ba3f48-594b-4308-8ab8-d69faa322e2a"),
                        City = "Donji Petrovci"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Svinjski vrat",
                        Description = "Svinjski vrat sa koskom",
                        Price = 620,
                        Currency = "RSD",
                        PictureUrl = "images/products/svinjskiVrat.png",
                        ProductTypeId = Guid.Parse("fa186b9a-9b5d-4b07-8df5-3dccef273f9a"),
                        ProductBrandId = Guid.Parse("653cc842-e8ba-4b1b-af05-72d7613b11f9"),
                        City = "Lezimir"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pilece meso",
                        Description = "Sveze pilece meso",
                        Price = 320,
                        Currency = "RSD",
                        PictureUrl = "images/products/pileceMeso.png",
                        ProductTypeId = Guid.Parse("fa186b9a-9b5d-4b07-8df5-3dccef273f9a"),
                        ProductBrandId = Guid.Parse("653cc842-e8ba-4b1b-af05-72d7613b11f9"),
                        City = "Lezimir"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Burek sa mesom",
                        Description = "Burek na stari nacin",
                        Price = 280,
                        Currency = "RSD",
                        PictureUrl = "images/products/burek.png",
                        ProductTypeId = Guid.Parse("294ec6d5-aed0-45c9-8604-36d0bfa1d5de"),
                        ProductBrandId = Guid.Parse("b60a16c2-5756-44d0-81a6-b26f30ccfe8c"),
                        City = "Lezimir"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pita sa sirom",
                        Description = "Pita sa sjenickim sirom",
                        Price = 220,
                        Currency = "RSD",
                        PictureUrl = "images/products/pitaSaSirom.png",
                        ProductTypeId = Guid.Parse("294ec6d5-aed0-45c9-8604-36d0bfa1d5de"),
                        ProductBrandId = Guid.Parse("b60a16c2-5756-44d0-81a6-b26f30ccfe8c"),
                        City = "Lezimir"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "med",
                        Description = "Domaci med",
                        Price = 800,
                        Currency = "RSD",
                        PictureUrl = "images/products/domaciMed.png",
                        ProductTypeId = Guid.Parse("6c9901dc-ca5f-41e2-92d8-cb4ddc3a4578"),
                        ProductBrandId = Guid.Parse("88c46ef3-82f7-48e8-a055-a12bd3c32848"),
                        City = "Backi breg"
                    },
                    new Product
                    {
                        Id = Guid.NewGuid(),
                        Name = "Med u sacu",
                        Description = "Med u sacu",
                        Price = 1200,
                        Currency = "RSD",
                        PictureUrl = "images/products/domaciMedUSacu.png",
                        ProductTypeId = Guid.Parse("6c9901dc-ca5f-41e2-92d8-cb4ddc3a4578"),
                        ProductBrandId = Guid.Parse("88c46ef3-82f7-48e8-a055-a12bd3c32848"),
                        City = "Backi breg"
                    }
                };

                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }

        }
    }
}