using System.Windows.Controls;

namespace GameSnake
{
    /// <summary>
    /// Логика взаимодействия для EmptyPage.xaml
    /// </summary>
    public partial class EmptyPage : Page
    {
        public EmptyPage()
        {
            InitializeComponent();
            MainWindow.startGame = 1;
        }
    }
}
