using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Border = System.Windows.Controls.Border;
namespace _4inRow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Border[,] Borders = new Border[6, 7];
        private bool[,] isFilled = new bool[6, 7]; // To track if a cell is filled
        private SolidColorBrush playerOne = new SolidColorBrush(Colors.Green);
        private SolidColorBrush playerTwo = new SolidColorBrush(Colors.BlueViolet);
        private bool isPlayerOneTurn = true; // Track the current player


        public MainWindow()
        {
            InitializeComponent();
            InitializeBordersGrid();
        }
        private void InitializeBordersGrid()
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Border Border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(2),
                        Width = 50,
                        Height = 50,
                        CornerRadius = new CornerRadius(30),


                    };
                    Borders[row, col] = Border;
                    LabelsGrid.Children.Add(Border);
                    Grid.SetRow(Border, row);
                    Grid.SetColumn(Border, col);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            int column = Grid.GetColumn(clickedButton);

            // Find the most bottom empty border in the clicked column
            for (int row = 5; row >= 0; row--)
            {
                if (!isFilled[row, column])
                {
                    Borders[row, column].Background = isPlayerOneTurn ? playerOne : playerTwo;
                    isFilled[row, column] = true;
                    isPlayerOneTurn = !isPlayerOneTurn;
                    break;
                }
            }
        }
    }
}
