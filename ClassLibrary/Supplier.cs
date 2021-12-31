namespace ClassLibrary
{
    /*
  * Entity class Supplier - properties & tostring method is written
  * Author: Jaswinder Sangha
  * Date: July 2019
  */
    public class Supplier
    {
        //public properties are declared
        public int SupplierId { get; set; }

        public string SupName { get; set; }

        // return the properties of Supplier in string format
        public override string ToString()
        {
            return SupplierId + "  " + SupName;
        }
    }
}
