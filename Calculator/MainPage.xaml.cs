using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int currentState = 1;
        string op;
        double num1, num2;

        public MainPage()
        {
            InitializeComponent();
            Clear(this, null);
        }
        
        void OnClickNumber(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;
            

            //excludes the 0 when pressing buttons
            if (this.resultText.Text == "0" || currentState < 0)
            {
                this.resultText.Text = "";//clearing the 0

                if (currentState < 0) //value starts at 1, so then this is excluded
                    currentState *= -1;
            }

            this.resultText.Text += pressed;// this condition is called when current state is greater and text box will aquire the pressed 

            double number;
            if (double.TryParse(this.resultText.Text, out number))
            {
                this.resultText.Text = number.ToString("N0");
                if (currentState == 1)
                {
                    num1 = number;//current state = 1 and current value is assigned to number
                }
                else
                {
                    num2 = number;
                }
            }
        }
        void Clear(object sender, EventArgs e)//this is linked to the AC button, clears everything
        {
            num1 = 0;
            num2 = 0;
            currentState = 1;
            this.resultText.Text = "0";
        }

        void OnClickOperator(object sender, EventArgs e)//Called when an operator button is pressed
        {
            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            op = pressed;
        }

        
        
        void Calculate(object sender, EventArgs e) //Linked to "=" button. Does calculation.
        {
            if (currentState == 2)
            {
                var result = OperatorCase.Calculate(num1, num2, op); //passing in our 2 numbers and the operation.
                this.resultText.Text = result.ToString();
                num1 = result;
                currentState = -1;
            }
        }
       


    }
}
