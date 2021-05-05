using System.Reflection;
using System.Resources;
using System.Windows;

namespace LocalizedApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор окна.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Вывод в отдельном окне сообщения на определенном языке при нажатии на кнопку.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">События.</param>
        public void ButtonSayHello(object sender, RoutedEventArgs e)
        {
            var resMan = new ResourceManager("LocalizedApp.TextMessages",
                         Assembly.GetExecutingAssembly());
            MessageBox.Show(resMan.GetString("HelloMessage",
              new System.Globalization.CultureInfo("en")));
        }
    }
}
