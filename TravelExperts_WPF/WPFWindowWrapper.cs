using System;

namespace TravelExperts_WPF
{
    /// <summary>
    /// Class that allows a WPF window to open a Winforms form
    /// Author: James Defant
    /// Date: Aug 5 2019
    /// </summary>
    public class WPFWindowWrapper : System.Windows.Forms.IWin32Window
    {
        // Constructor
        public WPFWindowWrapper(System.Windows.Window wpfWindow)
        {
            Handle = new System.Windows.Interop.WindowInteropHelper(wpfWindow).Handle;
        }
        public IntPtr Handle { get; private set; }
    }
}
