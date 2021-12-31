namespace ClassLibrary
{
    /// <summary>
    /// Model class to hold data from single row from Packages_Products_Suppliers table
    /// Author: James Defant
    /// Date: July 25 2019
    /// </summary>
    public class Package_Product_Supplier
    {
        public int PackageId { get; set; }

        public int ProductSupplierId { get; set; }

        public override string ToString()
        {
            return "PackageId: " + PackageId +
                 "\nProductSupplierId: " + ProductSupplierId;
        }
    }
}
