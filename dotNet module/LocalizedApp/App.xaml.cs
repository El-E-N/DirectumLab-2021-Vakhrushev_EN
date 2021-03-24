using System.Windows;

namespace LocalizedApp
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Конструктор App с настройкой языка.
        /// </summary>
        static App()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture =
              new System.Globalization.CultureInfo("ru");
        }
    }
}
