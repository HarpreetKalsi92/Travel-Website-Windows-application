using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts_Winforms
{

    public static class Validator
    {
        // all methods in a static class are static

        /// <summary>
        /// tests if textbox has content
        /// </summary>
        /// <param name="tb">text box tested</param>
        /// <param name="name">name to use in error message</param>
        /// <returns>is it valid</returns>
        public static bool IsPresent(TextBox tb, string name)
        {
            bool valid = true; // "innocent until proven guilty"
            if (tb.Text == "")// empty
            {
                valid = false;
                MessageBox.Show(name + " has to be provided");
                tb.Focus();
            }
            return valid;


        }

        private static string title = "Entry Error";

        /// <summary>
        /// The title that will appear in dialog boxes.
        /// </summary>
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        /// <summary>
        /// Checks whether the user entered data into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered data.</returns>
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (textBox.Text == "")
                {
                    MessageBox.Show(textBox.Name + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is a required field.", "Entry Error");
                    comboBox.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks whether the user entered a decimal value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered a decimal value.</returns>
        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered an int value into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <returns>True if the user has entered an int value.</returns>
        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        /// <summary>
        /// Checks whether the user entered a value within a specified range into a text box.
        /// </summary>
        /// <param name="textBox">The text box control to be validated.</param>
        /// <param name="min">The minimum value for the range.</param>
        /// <param name="max">The maximum value for the range.</param>
        /// <returns>True if the user has entered a value within the specified range.</returns>
        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min
                    + " and " + max + ".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }
        public static bool CheckCommission(TextBox Commission, TextBox BasePrice)
        {
            bool success1 = Decimal.TryParse(Commission.Text, out decimal comm);
            bool success2 = Decimal.TryParse(BasePrice.Text, out decimal Bsprice);

            if (Commission.Text == "")
            {
                return true;
            }

            if (success1 && success2)
            {
                if (comm > Bsprice)
                {
                    MessageBox.Show("Agency commission can not be greater than base price");
                    BasePrice.Focus();
                    return false;

                }
            }    
            return true;

        }

        public static bool CheckDates(DateTimePicker PkgStartDate, DateTimePicker PkgEndDate)
        {
            bool success = false;

            if (PkgStartDate.Text == " " && PkgEndDate.Text == " ")
            {
                //Null entries
                success = true;
            }else if (PkgStartDate.Text == " " || PkgEndDate.Text == " ")
            {
                MessageBox.Show("Package needs start and end date, or neither");
                success = false;
            }
            else
            {
                //End date must be later than start date

            if (PkgStartDate.Value.Date > PkgEndDate.Value.Date)
                {
                    MessageBox.Show("End date must be later than start date!");
                    success = false;
                }
            }

            return success;
        }
    }// end class
}//end namespace
