using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Media;

namespace GameSnake
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    /// 
    
    public partial class Menu : Page
    {

        SoundPlayer backSound;
        public Menu()
        {
            InitializeComponent();
            backSound = new SoundPlayer(@"D:\Проекты\GameSnake\GameSnake\Sounds\background.wav");
            backSound.PlayLooping();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new EmptyPage());
            backSound.Stop();
        }
    }
}
