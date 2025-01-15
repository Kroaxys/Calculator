namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double temp = 0;
        string symbol;
        double operand = 0; 

        public MainPage()
        {
            InitializeComponent();
        }

        /*protected override Window CreateWindow(IActivationState? activationState)
        {

            var window = new Window(new AppShell()


            {
                Width


            };


        }*/
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            EntryResult.Text += button.Text;
            symbol += button.Text;
        }

        private void SymbolButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            EntryResult.Text += button.Text;

            symbol = button.Text;

        }

        private void AnswerButton(object sender, EventArgs e)
        {
            Calculate();

        }

        public void Calculate()
        {
            switch (symbol)
            {
                case "+":
                    temp += double.Parse(EntryResult.Text);
                    break;
                case "-":
                    temp -= double.Parse(EntryResult.Text);
                    break;
                case "*":
                    temp *= double.Parse(EntryResult.Text);
                    break;
                case "/":
                    if (double.Parse(EntryResult.Text) == 0)
                    {
                        DisplayAlert("Fel", "Division med 0 är inte tillåtet", "Ok");
                    }
                    temp /= double.Parse(EntryResult.Text);
                    break;
                default:
                    EntryCalculation.Text = "Error";
                    break;
            }

        }

    }
}
