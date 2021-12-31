namespace ClassLibrary.Enums
{
    /// <summary>
    /// Enum to define the type of transaction when adding a package/product/supplier to DB
    /// Author: James Defant
    /// Date: Aug 8 2019
    /// </summary>
    public enum Pkg_Prod_SuppTransactionType
    {
        NewPkg_NewProd_NewSupp,
        NewPkg_NewProd_OldSupp,
        NewPkg_OldProd_OldSupp,
        NewPkg_OldProd_NewSupp,

        OldPkg_NewProd_NewSupp,
        OldPkg_NewProd_OldSupp,
        OldPkg_OldProd_NewSupp,
        OldPkg_OldProd_OldSupp
    }
}
