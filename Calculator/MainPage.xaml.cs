

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double temp = 0; 
        string symbol = ""; 
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
       
        private void NumberButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            operand = (operand * 10) + Convert.ToDouble(button.Text);

            
            EntryResult.Text = operand.ToString();
            EntryCalculation.Text += button.Text;
            
        }

        private void SymbolButton(object sender, EventArgs e)
        {
            
            if (symbol != "")
            {
                Calculate();
                
            }
            else
            {
                temp = operand;
            }

            operand = 0;
            Button button = (Button)sender;

            symbol = button.Text;
            EntryCalculation.Text += $" {symbol} ";

            

        }

        private void AnswerButton(object sender, EventArgs e)
        {

            Calculate();
            EntryResult.Text = temp.ToString();
            EntryCalculation.Text = temp.ToString();
            operand = 0; //reset operand
            /*symbol = ""; //reset symbol*/

        }

        public void Calculate()
        {
            switch (symbol)
            {
                case "+":
                    temp += operand; 
                    break;
                case "-":
                    temp -= operand;
                    break;
                case "*":
                    temp *= operand;
                    break;
                case "/":
                    if (operand == 0)
                    {
                        DisplayAlert("Fel", "Division med 0 är inte tillåtet", "Ok");
                        Clear();
                        return;
                    }
                    temp /= operand;
                    break;
                
               
                    
             }
         operand = 0;

        }

        private void Clear()
        {
            EntryResult.Text = "0";
            EntryCalculation.Text = "";
            temp = 0;
            operand = 0;
            symbol = "";
        }
        private void ClearButton(object sender, EventArgs e)
        {
            Clear();
        }

    }
}
