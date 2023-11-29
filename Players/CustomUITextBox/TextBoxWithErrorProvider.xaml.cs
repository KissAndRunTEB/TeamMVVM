using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace Players.MyOwnTextBox
{

    public partial class TextBoxWithErrorProvider : UserControl
    {
        #region Public Properties

        public static Brush BrushForAll { get; set; } = Brushes.Red;

        public Brush TextBoxBorderBrush
        {
            get
            {
                return border.BorderBrush;
            }
            set
            {
                border.BorderBrush = value;
            }
        }

        public string ToolTipText { get; set; } = "Fill in the data";

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TextBoxWithErrorProvider()
        {
            InitializeComponent();
            // Set border color
            border.BorderBrush = BrushForAll;
        }

        #endregion

        #region SetError Method

        /// <summary>
        /// Method to set ToolTip and border thickness
        /// in case the TextBox has an empty string
        /// </summary>
        /// <param name="errorText"></param>
        public void SetError(string errorText)
        {
            textBlockToolTip.Text = errorText;


            if (textBox.Text == "")
            {
                // No data
                border.BorderThickness = new Thickness(1);
                toolTip.Visibility = Visibility.Visible;
                this.IsNotEmpty = false;
            }
            else
            {
                // Error reported
                border.BorderThickness = new Thickness(0);
                toolTip.Visibility = Visibility.Hidden;
                this.IsNotEmpty = true;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// When the text changes in the control,
        /// check if there is an empty string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetError(ToolTipText);
        }

        /// <summary>
        /// On focus of the control,
        /// check if there is an empty string
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SetError(ToolTipText);
        }

        #endregion

        #region Data Binding Handling for Text Property

        /// <summary>
        /// Registering the TextProperty (for data binding)
        /// </summary>
        public static readonly DependencyProperty TextProperty =
       DependencyProperty.Register(
          "Text",
          typeof(string),
          typeof(TextBoxWithErrorProvider),
          new FrameworkPropertyMetadata(null));

        /// <summary>
        /// Public Text property
        /// </summary>
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion

        #region Data Binding Handling for IsNotEmpty Property

        /// <summary>
        /// Registering the IsEmptyProperty (for data binding)
        /// </summary>
        public static readonly DependencyProperty IsNotEmptyProperty =
       DependencyProperty.Register(
          "IsNotEmpty",
          typeof(bool),
          typeof(TextBoxWithErrorProvider));

        /// <summary>
        /// Public IsNotEmpty property
        /// </summary>
        public bool IsNotEmpty
        {
            get { return (bool)GetValue(IsNotEmptyProperty); }
            set { SetValue(IsNotEmptyProperty, value); }
        }

        #endregion
    }
}

