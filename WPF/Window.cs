using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Utils.WPF
{
    public static class Window
    {

        /// <summary>
        /// Centers the window.
        /// Extends any window
        /// </summary>
        /// <param name="window">The window.</param>
        /// @author : Wild_A (http://stackoverflow.com/users/621044/wild-a)
        /// @original-post : http://stackoverflow.com/a/14334262/2245256
        public static void CenterWindow(this System.Windows.Window window)
        {
            Rect workArea = System.Windows.SystemParameters.WorkArea;
            window.Left = (workArea.Width - window.Width) / 2 + workArea.Left;
            window.Top = (workArea.Height - window.Height) / 2 + workArea.Top;
        }
    }
}
