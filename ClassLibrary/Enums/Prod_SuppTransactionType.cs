namespace ClassLibrary.Enums
{
    /// <summary>
    /// Enum to define the type of transaction when adding a product/supplier to DB
    /// Author: James Defant
    /// Date: Aug 8 2019
    /// </summary>
    public enum Prod_SuppTransactionType
    {
        NewProduct_NewSupplier,
        NewProduct_OldSupplier,
        OldProduct_NewSupplier,
        OldProduct_OldSupplier
    }
}
