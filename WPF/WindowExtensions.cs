using System.Windows;

namespace Utils.WPF
{
    /// <summary>
    /// A class containing extension methods for the <see cref="Window"/> class
    /// </summary>
    public static class WindowExtensions
    {

        /// <summary>
        /// Centers the window.
        /// </summary>
        /// <param name="window">The window.</param>
        /// @author : Wild_A (http://stackoverflow.com/users/621044/wild-a)
        /// @original-post : http://stackoverflow.com/a/14334262/2245256
        public static void CenterWindow(this Window window)
        {
            Rect workArea = SystemParameters.WorkArea;
            window.Left = (workArea.Width - window.Width) / 2 + workArea.Left;
            window.Top = (workArea.Height - window.Height) / 2 + workArea.Top;
        }
    }
}
