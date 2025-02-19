
using System.Globalization;
using System.Diagnostics;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        double temp = 0; //Temporary variable to store the result of the calculation
        string symbol = ""; //Variable to store the symbol of the operation
        double operand = 0; //Variable to store the number entered by the user
        int numberbuttonpresses = 0; //Variable to store the number of times a number button has been pressed
        int symbolbuttonpresses = 0; //Variable to store the number of times a symbol button has been pressed
        bool calculationdone = false; 


        public MainPage()
        {
            InitializeComponent();
        }
       
        private void CommaButton(object sender, EventArgs e)
        {
            Button button = (Button)sender; //Get the button that was clicked
            EntryCalculation.Text += button.Text; //Display the comma in the calculation field
            operand = Convert.ToDouble(button.Text); //Get the number from the result field and add the comma


        }

        private void NumberButton(object sender, EventArgs e) 
        {
            Button button = (Button)sender; //Get the button that was clicked

            operand = (operand * 10) + Convert.ToDouble(button.Text); //Get the number from the button and add it to the operand

            Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp number button inserted1");
            
            EntryCalculation.Text += button.Text; //Display the number in the calculation field along with any previously inputed numbers
            numberbuttonpresses++; //Increment the number of times a number button has been pressed by one
            symbolbuttonpresses = 0; //Reset the number of times a symbol button has been pressed
            Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp number button inserted2");
        } 

        private void SymbolButton(object sender, EventArgs e)
        {

            if (symbol != "" && symbolbuttonpresses == 0 && numberbuttonpresses == 1) //If there is already a symbol, calculate the result. Check if the user has entered a number before pressing a symbol button
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
                temp = operand; //Set the temp variable to the operand
            }
            else if (calculationdone == true) 
            {}
            else
            {
                EntryResult.Text = "Something has gone wrong";
            }


                Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp symbol button inserted1");

            operand = 0; //Reset operand so that the user can enter a new number
            Button button = (Button)sender; //Get the button that was clicked
            symbol = button.Text; //Set the symbol to the symbol variable of the button that was clicked
            EntryCalculation.Text += $" {symbol} "; //Display the symbol in the calculation field
            symbolbuttonpresses++; //Increment the number of times a symbol button has been pressed by one
            numberbuttonpresses = 0; //Reset the number of times a number button has been pressed
            Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp symbol button inserted2");

        }

        private void AnswerButton(object sender, EventArgs e)
        {
            if (symbolbuttonpresses == 0 && numberbuttonpresses > 0) //Check if the user has entered a number before pressing the answer button
            {
                Calculate();
                EntryResult.Text = temp.ToString(); //Display the result in the result field
                EntryCalculation.Text = temp.ToString(); //Display the result in the calculation field
                operand = 0; //reset operand

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
                Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp if opperand == 0 begining");
                switch (symbol) //Perform the calculation based on the symbol
                {
                    case "+": //Addition
                        temp += temp;
                        break;
                    case "-": //Subtraction
                        temp -= temp;
                        break;
                    case "*": //Multiplication 
                        temp *= temp;
                        break;
                    case "/": //Division
                        if (temp == 0) //Check if the user is trying to divide by 0
                        {
                            DisplayAlert("Fel", "Division med 0 är inte tillåtet", "Ok");
                            Clear();
                            return;
                        }
                        temp /= temp;
                        break;



                }
                Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp if opperand == 0 end");
            }
            else 
            {
                Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp else begining");
                switch (symbol) //Perform the calculation based on the symbol
                {
                    case "+": //Addition
                        temp += operand;
                        break;
                    case "-": //Subtraction
                        temp -= operand;
                        break;
                    case "*": //Multiplication
                        temp *= operand;
                        break;
                    case "/": //Division
                        if (operand == 0) //Check if the user is trying to divide by 0
                        {
                            DisplayAlert("Fel", "Division med 0 är inte tillåtet", "Ok");
                            Clear();
                            return;
                        }
                        temp /= operand;
                        break;
                        }
                Debug.WriteLine($"{operand}operand {symbol}symbol {temp}temp else ending");
            }
            

            operand = 0; //Reset operand
            symbol = ""; //Reset symbol
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
        }
        private void ClearButton(object sender, EventArgs e) //Clear all fields if the clear button is clicked
        {
            Clear();
        }
        private void MissingNumber()
        {
            EntryCalculation.Text = "You are missing numbers.";
            
        }

    }
}
