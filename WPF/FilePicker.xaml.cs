using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

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

        public Behaviour Type { get; set; }

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
            DependencyProperty.Register("ButtonContent", typeof(Object), typeof(FilePicker), new PropertyMetadata(0));




        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValueDp(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(FilePicker), new PropertyMetadata(""));



        private void SetValueDp(DependencyProperty property, object value, [CallerMemberName] String p = null)
        {
            SetValue(property, value);
            OnPropertyChanged(p);
        }


        public FilePicker()
        {
            this.Type = Behaviour.OneFile;
            InitializeComponent();
        }

        private void BrowseKeyButton_Click(object sender, RoutedEventArgs e)
        {
            var ofd = GetOpenFileDialog("Ouvrir", this.Type == Behaviour.MultiFile);//TODO : Localize
            ofd.ShowDialog();
            FilePath = ofd.FileName;
        }

        FileDialog GetOpenFileDialog(String title, Boolean multipleFiles = false)
        {
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
