namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double temp;
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

        }

        private void SymbolButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            EntryResult.Text += button.Text;

        }

        private void AnswerButton(object sender, EventArgs e)
        {
            double sum = 0;

            temp = sum;

        }
    }

}
