namespace CoreTools.WPF.IO
{
    public class FileDialogOptions
    {
        /// <summary>
        /// Gets or sets the file dialog box title.
        /// </summary>
        /// <value>
        /// The file dialog box title. The default value is an empty string ("").
        /// </value>
        public string? Title { get; set; } = string.Empty;
        
        /// <summary>
        /// Gets or sets the current file name filter string, which determines the choices that appear in the 
        /// "Save as file type" or "Files of type" box in the dialog box.
        /// </summary>
        /// <value>
        /// The file filtering options available in the dialog box.
        /// </value>
        /// <exception cref="System.ArgumentException">Filter format is invalid.</exception>
        public string? Filter { get; set; }

        /// <summary>
        /// Gets or sets the default file name extension.
        /// </summary>
        /// <value>
        /// The default file name extension. The returned string does not include the period. The default value is an empty string ("").
        /// </value>
        public string? DefaultExt { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box automatically adds an extension to a file name 
        /// if the user omits the extension.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box adds an extension to a file name if the user omits the extension; otherwise, <see langword="false" />. 
        /// The default value is <see langword="true" />.
        /// </value>
        public bool AddExtension { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box allows multiple files to be selected.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box allows multiple files to be selected together or concurrently; otherwise, <see langword="false" />. 
        /// The default value is <see langword="false" />.
        /// </value>
        public bool Multiselect { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a file name that does not exist.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box displays a warning if the user specifies a file name that does not exist; otherwise, <see langword="false" />. The default value is <see langword="true" />.
        /// </value>
        public bool CheckFileExists { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box contains a read-only check box.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box contains a read-only check box; otherwise, <see langword="false" />. The default value is <see langword="false" />.
        /// </value>
        /// <remarks>
        /// If the Vista style dialog is used, this property can only be used to determine whether the user chose
        /// Open as read-only on the dialog; setting it in code will have no effect.
        /// </remarks>
        public bool ShowReadOnly { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the read-only check box is selected.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the read-only check box is selected; otherwise, <see langword="false" />. The default value is <see langword="false" />.
        /// </value>
        public bool ReadOnlyChecked { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box displays a warning if the user specifies a path that does not exist.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box displays a warning when the user specifies a path that does not exist; otherwise, <see langword="false" />. 
        /// The default value is <see langword="true" />.
        /// </value>
        public bool CheckPathExists { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box accepts only valid Win32 file names.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box accepts only valid Win32 file names; otherwise, <see langword="false" />. The default value is <see langword="false" />.
        /// </value>
        public bool ValidateNames { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the dialog box restores the current directory before closing.
        /// </summary>
        /// <value>
        /// <see langword="true" /> if the dialog box restores the current directory to its original value if the user changed the 
        /// directory while searching for files; otherwise, <see langword="false" />. The default value is <see langword="false" />.
        /// </value>
        public bool RestoreDirectory { get; set; } = false;
    }
}