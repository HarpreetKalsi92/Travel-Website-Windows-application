namespace ClassLibrary.Interfaces
{
    /// <summary>
    /// Interface that allows sub-forms (frmSupplier, frmProduct, AddPackage) to pass object back to Main form (ManageData)
    /// Author: James Defant
    /// Date: Aug 8 2019
    /// </summary>
    public interface ITravelAdmin
    {
        Package NewPackage { set; }
        Product NewProduct { set; }
        Supplier NewSupplier { set; }
    }
}
