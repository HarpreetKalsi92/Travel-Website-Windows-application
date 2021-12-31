namespace ClassLibrary
{
    /*
   * Entity class Product - properties & tostring method is written
   * Author: Jaswinder Sangha
   * Date: July 2019
   */
    public class Product
    {
        //public properties are declared
        public int ProductId { get; set; }

        public string ProdName { get; set; }

        // return the properties of Product in string format
        public override string ToString()
        {
            return ProductId + "  " + ProdName;
        }
    }
}
