using ClassLibrary;
using System;
using System.Collections.Generic;

namespace TravelExperts_Winforms
{
    public static class DummyData
    {
        // Complete Products table
        public static List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new Product() { ProductId = 1, ProdName = "Air" },
                new Product() { ProductId = 2, ProdName = "Attractions" },
                new Product() { ProductId = 3, ProdName = "Car Rental" },
                new Product() { ProductId = 4, ProdName = "Cruise" },
                new Product() { ProductId = 5, ProdName = "Hotel" },
                new Product() { ProductId = 6, ProdName = "Motor Coach" },
                new Product() { ProductId = 7, ProdName = "Railroad" },
                new Product() { ProductId = 8, ProdName = "Tours" },
                new Product() { ProductId = 9, ProdName = "Travel Insurance" },
                new Product() { ProductId = 10, ProdName = "Yacht/Boat Charters" }
            };
        }

        // Complete Packages table
        public static List<Package> GetPackages()
        {
            return new List<Package>()
            {
                new Package() { PackageId = 1, PkgName = "Caribean New Year", PkgStartDate = new DateTime(2005, 12, 25), PkgEndDate = new DateTime(2006, 1, 4), PkgDesc = "Cruise the Caribean & Celebrate the New Year", PkgBasePrice = 4800m, PkgAgencyCommission = 400m},
                new Package() { PackageId = 2, PkgName = "Polynesian Paradise", PkgStartDate = new DateTime(2005, 12, 12), PkgEndDate = new DateTime(2005, 12, 20), PkgDesc = "8 Day All Inclusive Hawaiian Vacation", PkgBasePrice = 3000m, PkgAgencyCommission = 310m},
                new Package() { PackageId = 3, PkgName = "Asian Expedition", PkgStartDate = new DateTime(2006, 5, 14), PkgEndDate = new DateTime(2006, 5, 28), PkgDesc = "Airfaire, Hotel and Eco Tour", PkgBasePrice = 2800m, PkgAgencyCommission = 300m},
                new Package() { PackageId = 4, PkgName = "European Vacation", PkgStartDate = new DateTime(2005, 11, 1), PkgEndDate = new DateTime(2005, 11, 14), PkgDesc = "Euro Tour with Rail Pass and Travel Insurance", PkgBasePrice = 3000m, PkgAgencyCommission = 280m}
            };
        }

        // Complete Packages_Products_Suppliers
        public static List<Package_Product_Supplier> GetPackages_Products_Suppliers()
        {
            return new List<Package_Product_Supplier>()
            {
                new Package_Product_Supplier() { PackageId = 1, ProductSupplierId = 65 },
                new Package_Product_Supplier() { PackageId = 1, ProductSupplierId = 93 },
                new Package_Product_Supplier() { PackageId = 2, ProductSupplierId = 32 },
                new Package_Product_Supplier() { PackageId = 2, ProductSupplierId = 33 },
                new Package_Product_Supplier() { PackageId = 2, ProductSupplierId = 90 },
                new Package_Product_Supplier() { PackageId = 3, ProductSupplierId = 28 },
                new Package_Product_Supplier() { PackageId = 3, ProductSupplierId = 82 },
                new Package_Product_Supplier() { PackageId = 3, ProductSupplierId = 87 },
                new Package_Product_Supplier() { PackageId = 4, ProductSupplierId = 9 },
                new Package_Product_Supplier() { PackageId = 4, ProductSupplierId = 65 },
                new Package_Product_Supplier() { PackageId = 4, ProductSupplierId = 84 }
            };
        }

        // Incomplete ProductSupplier table
        public static List<Product_Supplier> GetProducts_Suppliers()
        {
            return new List<Product_Supplier>()
            {
                new Product_Supplier() { ProductSupplierId = 16, ProductId = 1, SupplierId = 69 },
                new Product_Supplier() { ProductSupplierId = 13, ProductId = 1, SupplierId = 80 },
                new Product_Supplier() { ProductSupplierId = 68, ProductId = 4, SupplierId = 100 },
                new Product_Supplier() { ProductSupplierId = 55, ProductId = 3, SupplierId = 317 },
                new Product_Supplier() { ProductSupplierId = 20, ProductId = 3, SupplierId = 323 },
                new Product_Supplier() { ProductSupplierId = 3, ProductId = 8, SupplierId = 796 },

                new Product_Supplier() { ProductSupplierId = 65, ProductId = 9, SupplierId = 2998 },
                new Product_Supplier() { ProductSupplierId = 93, ProductId = 4, SupplierId = 3650 },
                new Product_Supplier() { ProductSupplierId = 32, ProductId = 3, SupplierId = 1416 },
                new Product_Supplier() { ProductSupplierId = 33, ProductId = 5, SupplierId = 13596 }


            };
        }

        // Incomplete Suppliers table
        public static List<Supplier> GetSuppliers()
        {
            return new List<Supplier>()
            {
                new Supplier() { SupplierId = 69, SupName = "NEW CONCEPTS - CANADA" },
                new Supplier() { SupplierId = 80, SupName = "CHAT / TRAVELINE" },
                new Supplier() { SupplierId = 100, SupName = "AVILA TOURS INC." },
                new Supplier() { SupplierId = 317, SupName = "BLYTH & COMPANY TRAVEL" },
                new Supplier() { SupplierId = 323, SupName = "COMPAGNIA ITALIANA TURISM" },
                new Supplier() { SupplierId = 796, SupName = "CYPRUS AIRWAYS LTD" },

                new Supplier() { SupplierId = 2998, SupName = "ALIOTOURS" },
                new Supplier() { SupplierId = 3650, SupName = "CUNARD LINES" },
                new Supplier() { SupplierId = 1416, SupName = "THE HOLIDAY NETWORK" },
                new Supplier() { SupplierId = 13596, SupName = "A & TIC SUPPORT INC." }

            }; 
        }



    }
}
