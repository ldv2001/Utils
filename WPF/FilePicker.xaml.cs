using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using Utils.Events;
using Utils.WPF.Resources.Lang;

namespace Utils.WPF
{
    /// <summary>
    /// Logique d'interaction pour FilePicker.xaml
    /// </summary>
    public partial class FilePicker : UserControl, INotifyPropertyChanged
    {
        public enum Behaviour
        {
            OneFile,
            MultiFile,
            Save
        }

        public Behaviour Type
        {
            get { return (Behaviour)GetValue(TypeProperty); }
            set { SetValueDp(TypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Behaviour), typeof(FilePicker), new PropertyMetadata(Behaviour.OneFile));

        public String FilePath
        {
            get { return (String)GetValue(FilePathProperty); }
            set { SetValueDp(FilePathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(String), typeof(FilePicker), new PropertyMetadata(""));

        public Object ButtonContent
        {
            get { return GetValue(ButtonContentProperty); }
            set { SetValueDp(ButtonContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(Object), typeof(FilePicker), new PropertyMetadata(Strings.BrowseButton));

        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValueDp(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(FilePicker), new PropertyMetadata(""));

        public FilePicker()
        {
            InitializeComponent();
        }

        private void BrowseKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var ofd = GetOpenFileDialog(Title, this.Type == Behaviour.MultiFile);
            ofd.ShowDialog();
            FilePath = ofd.FileName;
        }

        FileDialog GetOpenFileDialog(String title, Boolean multipleFiles = false)
        {
            if (String.IsNullOrEmpty(title))
            {
                title = (Type == Behaviour.Save) ? Strings.Save : Strings.Open;
            }
            if (Type != Behaviour.Save)
            {
                return new OpenFileDialog()
                {
                    CheckFileExists = true,
                    CheckPathExists = true,
                    DereferenceLinks = true,
                    Multiselect = multipleFiles,
                    RestoreDirectory = true,
                    Title = title
                };

            }
            return new SaveFileDialog()
            {
                OverwritePrompt = true,
                ValidateNames = true,
                Title = title,
                RestoreDirectory = true,
                DereferenceLinks = true,
                CheckPathExists = true
            };
        }

        private void SetValueDp(DependencyProperty property, object value, [CallerMemberName] String p = null)
        {
            SetValue(property, value);
            OnPropertyChanged(p);
        }

        #region Default Implementation of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
