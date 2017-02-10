using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Forms;
using Utils.Events;
using Utils.WPF.Resources.Lang;

using DataFormats = System.Windows.DataFormats;
using DragDropEffects = System.Windows.DragDropEffects;
using DragEventArgs = System.Windows.DragEventArgs;
using FileDialog = Microsoft.Win32.FileDialog;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using UserControl = System.Windows.Controls.UserControl;

namespace Utils.WPF
{
    /// <summary>
    /// Logique d'interaction pour FilePicker.xaml
    /// </summary>
    public partial class FilePicker : UserControl, INotifyPropertyChanged
    {
        /// <summary>
        /// List the different possible usages of the <see cref="FilePicker"/> user control
        /// </summary>
        public enum Behaviour
        {
            /// <summary>
            /// Allows to pick one file
            /// </summary>
            OneFile,

            /// <summary>
            /// Allows to pick multiple files
            /// </summary>
            MultiFile,

            /// <summary>
            /// Allows to choose where to save a file
            /// </summary>
            Save,

            /// <summary>
            /// Allows to choose a directory
            /// </summary>
            Folder
        }

        /// <summary>
        /// Gets or Sets a value indicating which <see cref="Behaviour"/> is desired
        /// </summary>
        public Behaviour Type
        {
            get { return (Behaviour)GetValue(TypeProperty); }
            set { SetValueDp(TypeProperty, value); }
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> for the <see cref="Type"/> property
        /// </summary>
        // Using a DependencyProperty as the backing store for Type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProperty =
            DependencyProperty.Register("Type", typeof(Behaviour), typeof(FilePicker), new PropertyMetadata(Behaviour.OneFile));

        /// <summary>
        /// Gets or sets the Selected path
        /// </summary>
        public String FilePath
        {
            get { return (String)GetValue(FilePathProperty); }
            set
            {
                SetValueDp(FilePathProperty, value);
                if (this.OnPathSelected != null) this.OnPathSelected.Invoke(this, new EventArgs<string>(value));
            }
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> for the <see cref="FilePath"/> property
        /// </summary>
        // Using a DependencyProperty as the backing store for FilePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(String), typeof(FilePicker), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        /// <summary>
        /// Gets or sets the selected pathes <br/>
        /// Only used in cunjunction with the <see cref="Behaviour.MultiFile"/> <see cref="Type"/>
        /// </summary>
        public String[] FilePathes
        {
            get { return (String[])GetValue(FilePathesProperty); }
            set
            {
                SetValue(FilePathesProperty, value);
                if (this.OnPathesSelected != null) this.OnPathesSelected.Invoke(this, new EventArgs<string[]>(value));
            }
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> for the <see cref="FilePathes"/> property
        /// </summary>
        // Using a DependencyProperty as the backing store for FilePathes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FilePathesProperty =
            DependencyProperty.Register("FilePathes", typeof(String[]), typeof(FilePicker), new FrameworkPropertyMetadata(new String[] { }, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        /// <summary>
        /// Gets or Sets the button's content
        /// </summary>
        public Object ButtonContent
        {
            get { return GetValue(ButtonContentProperty); }
            set { SetValueDp(ButtonContentProperty, value); }
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> for the <see cref="ButtonContent"/> property
        /// </summary>
        // Using a DependencyProperty as the backing store for ButtonContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(Object), typeof(FilePicker), new PropertyMetadata(Strings.BrowseButton));

        /// <summary>
        /// Gets or Sets the title of the dialog opened on the button click
        /// </summary>
        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValueDp(TitleProperty, value); }
        }

        /// <summary>
        /// <see cref="DependencyProperty"/> for the <see cref="Title"/> property
        /// </summary>
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(FilePicker), new PropertyMetadata(""));

        /// <summary>
        /// Initializes a new instance of the <see cref="FilePicker"/> class
        /// </summary>
        public FilePicker()
        {
            InitializeComponent();
        }

        private void BrowseKeyButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.Type == Behaviour.Folder)
            {
                var fbd = new FolderBrowserDialog() { RootFolder = Environment.SpecialFolder.MyComputer };
                fbd.ShowDialog();
                this.FilePath = fbd.SelectedPath;
                return;
            }

            var ofd = this.GetOpenFileDialog(Title, this.Type == Behaviour.MultiFile);
            ofd.ShowDialog();

            if (this.Type == Behaviour.OneFile || Type == Behaviour.Save)
            {
                this.FilePath = ofd.FileName;
            }
            else if (this.Type == Behaviour.MultiFile)
            {
                this.FilePathes = ofd.FileNames;
                this.FilePath = this.FilePathes[0];
            }
        }

        private FileDialog GetOpenFileDialog(String title, Boolean multipleFiles = false)
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

        /// <summary>
        /// Event fired when a path is selected
        /// </summary>
        public event EventHandler<EventArgs<string>> OnPathSelected;

        /// <summary>
        /// Event fired when multiple pathes are selected
        /// </summary>
        public event EventHandler<EventArgs<string[]>> OnPathesSelected;

        #region Default Implementation of INotifyPropertyChanged

        /// <inheritdoc/>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        private void FilePicker_OnDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            String[] dataStrings = (String[])e.Data.GetData(DataFormats.FileDrop);

            switch (Type)
            {
                case Behaviour.OneFile:
                    if (dataStrings.Length == 1 && File.Exists(dataStrings[0]))
                    {
                        FilePath = dataStrings[0];
                        FilePathes = dataStrings;
                    }
                    break;
                case Behaviour.MultiFile:
                    if (dataStrings.All(s => File.Exists(s) || Directory.Exists(s)))
                    {
                        FilePath = dataStrings[0];
                        FilePathes = dataStrings;
                    }
                    break;
                case Behaviour.Folder:
                    if (dataStrings.Length == 1 && Directory.Exists(dataStrings[0]))
                    {
                        FilePath = dataStrings[0];
                        FilePathes = dataStrings;
                    }
                    break;
            }

        }

        private void FilePicker_OnDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;

            String[] dataStrings = (String[])e.Data.GetData(DataFormats.FileDrop);

            switch (Type)
            {
                case Behaviour.OneFile:
                    if (dataStrings.Length == 1 && File.Exists(dataStrings[0]))
                    {
                        e.Effects = DragDropEffects.Link;
                    }
                    break;
                case Behaviour.MultiFile:
                    if (dataStrings.All(s => File.Exists(s) || Directory.Exists(s)))
                    {
                        e.Effects = DragDropEffects.Link;
                    }
                    break;
            }
        }
    }
}
