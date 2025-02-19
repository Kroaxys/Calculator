
using System.Globalization;
using System.Diagnostics;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double temp = 0; 
        string symbol = ""; 
        double operand = 0; 
        int numberbuttonpresses = 0; 
        int symbolbuttonpresses = 0; 
        bool calculationdone = false; 


        public MainPage()
        {
            InitializeComponent();
        }
       
        private void CommaButton(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            EntryCalculation.Text += button.Text; 
            operand = Convert.ToDouble(button.Text); 


        }

        private void NumberButton(object sender, EventArgs e) 
        {
            Button button = (Button)sender;

            operand = (operand * 10) + Convert.ToDouble(button.Text); 

            
            
            EntryCalculation.Text += button.Text;
            numberbuttonpresses++;
            symbolbuttonpresses = 0; 
            
        } 

        private void SymbolButton(object sender, EventArgs e)
        {

            if (symbol != "" && symbolbuttonpresses == 0 && numberbuttonpresses == 1)  //This whole if and else if checks wheter a symbol has been used 
            //previously and wheter we should put operand in temp of if we shall ignore it. Helps with using symbols right after having done a calculation.
            {
                Calculate();
            }
            else if (calculationdone == false && temp != 0 && symbolbuttonpresses == 0 && numberbuttonpresses >= 1)
            {
                temp = operand;
                EntryCalculation.Text = temp.ToString();
            }
            else if (temp != 0 && symbolbuttonpresses == 1 && numberbuttonpresses == 0)
            {
                MissingNumber();
            }
            else if (calculationdone == false)
            {
                temp = operand; 
            }
            else if (calculationdone == true) 
            {}
            else
            {
                EntryResult.Text = "Something has gone wrong";
            }

            operand = 0; 
            
            Button button = (Button)sender; 
            symbol = button.Text; 
            
            EntryCalculation.Text += $" {symbol} "; 
            
            symbolbuttonpresses++; 
            numberbuttonpresses = 0;
            

        }

        private void AnswerButton(object sender, EventArgs e)
        {
            if (symbolbuttonpresses == 0 && numberbuttonpresses > 0) 
            {
                Calculate();
                EntryResult.Text = temp.ToString(); 
                EntryCalculation.Text = temp.ToString(); 
                operand = 0; 

            }
            else
            {
                MissingNumber();
            }
            
            

        }

        public void Calculate()
        {

            if (operand == 0)
            {
                
                switch (symbol) //Perform the calculation based on the symbol
                {
                    case "+": 
                        temp += temp;
                        break;
                    case "-": 
                        temp -= temp;
                        break;
                    case "*": 
                        temp *= temp;
                        break;
                    case "/": 
                        if (temp == 0) //Check if the user is trying to divide by 0
                        {
                            DisplayAlert("Fel", "Division med 0 är inte tillåtet", "Ok");
                            Clear();
                            return;
                        }
                        temp /= temp;
                        break;



                }
                
            }
            else 
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
               
            }
            

            operand = 0; 
            symbol = ""; 
            calculationdone = true;

        }

        private void Clear() //Clear all fields
        {
            EntryResult.Text = "0";
            EntryCalculation.Text = "";
            temp = 0;
            operand = 0;
            symbol = "";
            symbolbuttonpresses = 1;
            numberbuttonpresses = 0;
            calculationdone = false;
        }
        private void ClearButton(object sender, EventArgs e) 
        {
            Clear();
        }
        private void MissingNumber()
        {
            EntryCalculation.Text = "You are missing numbers.";
            
        }

    }
}
