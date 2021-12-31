namespace ClassLibrary
{
    /// <summary>
    /// Model class to hold data from single row from Products_Suppliers table
    /// Author: James Defant
    /// Date: July 25 2019
    /// </summary>
    public class Product_Supplier
    {
        public int ProductSupplierId { get; set; }

        public int? ProductId { get; set; }     // Nullable

        public int? SupplierId { get; set; }    // Nullable

        public override string ToString()
        {
            return "ProductSupplierId: " + ProductSupplierId +
                   "\nProductId: " + ProductId +
                   "\nSupplierId: " + SupplierId;
        }
    }
}
