using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HCICalculator
{
    public partial class Form1 : Form
    {
        private static string calcDisplay;
        private static int firstValue;
        private static int secondValue;
        private static char operand;
        private static int firstDecimal;
        private static int secondDecimal;
        private static CalcState currentState;
        private static bool inInfix;

        public static void setState(CalcState newState)
        {
            currentState = newState;
        }
        public static void setDisplay(string newDisplay)
        {
            calcDisplay = newDisplay;
        }
        public static string getDisplay()
        {
            return calcDisplay;
        }
        public static void setFirstValue(int newValue)
        {
            firstValue = newValue;
        }
        public static int getFirstValue()
        {
            return firstValue;
        }
        public static void setSecondValue(int newValue)
        {
            secondValue = newValue;
        }
        public static int getSecondValue()
        {
            return secondValue;
        }
        public static void setOperand(char newOp)
        {
            operand = newOp;
        }
        public static char getOperand()
        {
            return operand;
        }
        public static void setFirstDec(int count)
        {
            firstDecimal = count;
        }
        public static int getFirstDecimalCount()
        {
            return firstDecimal;
        }
        public static void setSecondDec(int count)
        {
            secondDecimal = count;
        }
        public static int getSecondDecimalCount()
        {
            return secondDecimal;
        }
        public static void resetToInfix()
        {
            calcDisplay = "";
            firstValue = 0;
            secondValue = 0;
            firstDecimal = 0;
            secondDecimal = 0;
            operand = 'n';
            inInfix = true;
            currentState = new InfixWaitFirstInput();
        }
        public static void resetToRPN()
        {
            calcDisplay = "";
            firstValue = 0;
            secondValue = 0;
            firstDecimal = 0;
            secondDecimal = 0;
            operand = 'n';
            inInfix = false;
            currentState = new RPNWaitFirstInput();
        }
        public static double doCalculation()
        {
            double result = 0;

            double value1 = Form1.getFirstDecimalCount();
            while (value1 >= 1)
            {
                value1 /= 10;
            }

            double value2 = Form1.getSecondDecimalCount();
            while (value2 >= 1)
            {
                value2 /= 10;
            }

            if (Form1.getOperand() == 'a')
            {
                result = ((Form1.getFirstValue() + value1) + (Form1.getSecondValue() + value2));
            }
            else if (Form1.getOperand() == 's')
            {
                result = ((Form1.getFirstValue() + value1) - (Form1.getSecondValue() + value2));
            }
            if (Form1.getOperand() == 'm')
            {
                result = ((Form1.getFirstValue() + value1) * (Form1.getSecondValue() + value2));
            }
            if (Form1.getOperand() == 'd')
            {
                result = ((Form1.getFirstValue() + value1) / (Form1.getSecondValue() + value2));
            }

            int resultInt = (int)Math.Floor(result);
            Form1.setFirstValue(resultInt);

            value1 = result - resultInt;
            value1 *= 100000;

            Form1.setFirstDec((int)value1);

            return result;
        }

        public Form1()
        {
            InitializeComponent();
            calcDisplay = "";
            firstValue = 0;
            secondValue = 0;
            firstDecimal = 0;
            secondDecimal = 0;
            operand = 'n';
            inInfix = true;
            label4.Text = "Infix";
            currentState = new InfixWaitFirstInput();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void modeButton_Click(object sender, EventArgs e)
        {
            currentState.clickMode();
            label1.Text = calcDisplay;
            
            if(inInfix)
            {
                label4.Text = "Infix";
                equalButton.Text = "=";
            }
            else
            {
                label4.Text = "RPN";
                equalButton.Text = "enter";
            }
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            currentState.clickEight();
            label1.Text = calcDisplay;
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            currentState.clickSeven();
            label1.Text = calcDisplay;
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            currentState.clickNine();
            label1.Text = calcDisplay;
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            currentState.clickFour();
            label1.Text = calcDisplay;
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            currentState.clickFive();
            label1.Text = calcDisplay;
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            currentState.clickSix();
            label1.Text = calcDisplay;
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            currentState.clickOne();
            label1.Text = calcDisplay;
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            currentState.clickTwo();
            label1.Text = calcDisplay;
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            currentState.clickThree();
            label1.Text = calcDisplay;
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            currentState.clickZero();
            label1.Text = calcDisplay;
        }

        private void decimalButton_Click(object sender, EventArgs e)
        {
            currentState.clickDecimal();
            label1.Text = calcDisplay;
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            currentState.clickEqual();
            label1.Text = calcDisplay;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            currentState.clickAdd();
            label1.Text = calcDisplay;
        }

        private void subButton_Click(object sender, EventArgs e)
        {
            currentState.clickSub();
            label1.Text = calcDisplay;
        }

        private void multButton_Click(object sender, EventArgs e)
        {
            currentState.clickMult();
            label1.Text = calcDisplay;
        }

        private void divButton_Click(object sender, EventArgs e)
        {
            currentState.clickDiv();
            label1.Text = calcDisplay;
        }
    }

    public interface CalcState
    {
        void clickMode();
        void clickOne();
        void clickTwo();
        void clickThree();
        void clickFour();
        void clickFive();
        void clickSix();
        void clickSeven();
        void clickEight();
        void clickNine();
        void clickZero();
        void clickAdd();
        void clickSub();
        void clickMult();
        void clickDiv();
        void clickDecimal();
        void clickEqual();
    }

    public class InfixWaitFirstInput: CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setFirstValue(1);
            Form1.setDisplay("1");
            Form1.setFirstDec(0);
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickTwo()
        {
            Form1.setFirstValue(2);
            Form1.setFirstDec(0);
            Form1.setDisplay("2");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickThree()
        {
            Form1.setFirstValue(3);
            Form1.setFirstDec(0);
            Form1.setDisplay("3");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickFour()
        {
            Form1.setFirstValue(4);
            Form1.setFirstDec(0);
            Form1.setDisplay("4");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickFive()
        {
            Form1.setFirstValue(5);
            Form1.setFirstDec(0);
            Form1.setDisplay("5");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickSix()
        {
            Form1.setFirstValue(6);
            Form1.setFirstDec(0);
            Form1.setDisplay("6");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickSeven()
        {
            Form1.setFirstValue(7);
            Form1.setFirstDec(0);
            Form1.setDisplay("7");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickEight()
        {
            Form1.setFirstValue(8);
            Form1.setFirstDec(0);
            Form1.setDisplay("8");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickNine()
        {
            Form1.setFirstValue(9);
            Form1.setFirstDec(0);
            Form1.setDisplay("9");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickZero()
        {
            Form1.setFirstValue(0);
            Form1.setFirstDec(0);
            Form1.setDisplay("0");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickAdd()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.setDisplay("0.");
            Form1.setFirstDec(0);
            Form1.setState(new InfixInputFirstValueDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
    }

    public class InfixInputFirstValue : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setFirstValue(10*Form1.getFirstValue() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.setOperand('a');
            Form1.setDisplay(Form1.getDisplay() + "+");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickSub()
        {
            Form1.setOperand('s');
            Form1.setDisplay(Form1.getDisplay() + "-");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickMult()
        {
            Form1.setOperand('m');
            Form1.setDisplay(Form1.getDisplay() + "*");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');
            Form1.setDisplay(Form1.getDisplay() + "/");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay() + ".");
            Form1.setState(new InfixInputFirstValueDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error"); 
        }
    }
    public class InfixInputFirstValueDecimal : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setFirstDec(Form1.getFirstDecimalCount() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.setOperand('a');
            Form1.setDisplay(Form1.getDisplay() + "+");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickSub()
        {
            Form1.setOperand('s');
            Form1.setDisplay(Form1.getDisplay() + "-");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickMult()
        {
            Form1.setOperand('m');
            Form1.setDisplay(Form1.getDisplay() + "*");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');
            Form1.setDisplay(Form1.getDisplay() + "/");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDecimal()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickEqual()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
    }
    public class InfixWaitMoreInput : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setSecondValue(1);
            Form1.setDisplay(Form1.getDisplay() + "1");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickTwo()
        {
            Form1.setSecondValue(2);
            Form1.setDisplay(Form1.getDisplay() + "2");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickThree()
        {
            Form1.setSecondValue(3);
            Form1.setDisplay(Form1.getDisplay() + "3");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickFour()
        {
            Form1.setSecondValue(4);
            Form1.setDisplay(Form1.getDisplay() + "4");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickFive()
        {
            Form1.setSecondValue(5);
            Form1.setDisplay(Form1.getDisplay() + "5");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickSix()
        {
            Form1.setSecondValue(6);
            Form1.setDisplay(Form1.getDisplay() + "6");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickSeven()
        {
            Form1.setSecondValue(7);
            Form1.setDisplay(Form1.getDisplay() + "7");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickEight()
        {
            Form1.setSecondValue(8);
            Form1.setDisplay(Form1.getDisplay() + "8");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickNine()
        {
            Form1.setSecondValue(9);
            Form1.setDisplay(Form1.getDisplay() + "9");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickZero()
        {
          
            Form1.setDisplay(Form1.getDisplay() + "0");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValues());
        }
        public void clickAdd()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay()+"0.");
            Form1.setSecondDec(0);
            Form1.setState(new InfixInputMoreValuesDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
    }
    public class InfixInputMoreValues : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.doCalculation();

            Form1.setOperand('a');
            
            Form1.setDisplay(Form1.getDisplay() + "+");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickSub()
        {
            Form1.doCalculation();

            Form1.setOperand('s');

            Form1.setDisplay(Form1.getDisplay() + "-");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickMult()
        {
            Form1.doCalculation();

            Form1.setOperand('m');

            Form1.setDisplay(Form1.getDisplay() + "*");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDiv()
        {
            Form1.doCalculation();

            Form1.setOperand('d');

            Form1.setDisplay(Form1.getDisplay() + "/");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay() + ".");
            Form1.setState(new InfixInputMoreValuesDecimal());
        }
        public void clickEqual()
        {
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new InfixResultActive());
        }
    }
    public class InfixInputMoreValuesDecimal : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.doCalculation();

            Form1.setOperand('a');

            Form1.setDisplay(Form1.getDisplay() + "+");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickSub()
        {
            Form1.doCalculation();

            Form1.setOperand('s');

            Form1.setDisplay(Form1.getDisplay() + "-");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickMult()
        {
            Form1.doCalculation();

            Form1.setOperand('m');

            Form1.setDisplay(Form1.getDisplay() + "*");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDiv()
        {
            Form1.doCalculation();

            Form1.setOperand('d');

            Form1.setDisplay(Form1.getDisplay() + "/");
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDecimal()
        {
            Form1.resetToInfix();
            Form1.setDisplay("error");
        }
        public void clickEqual()
        {
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new InfixResultActive());
        }
    }
    public class InfixResultActive : CalcState
    {
        public void clickMode()
        {
            Form1.resetToRPN();
        }
        public void clickOne()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(1);
            Form1.setDisplay("1");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickTwo()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(2);
            Form1.setDisplay("2");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickThree()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(3);
            Form1.setDisplay("3");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickFour()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(4);
            Form1.setDisplay("4");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickFive()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(5);
            Form1.setDisplay("5");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickSix()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(6);
            Form1.setDisplay("6");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickSeven()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(7);
            Form1.setDisplay("7");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickEight()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(8);
            Form1.setDisplay("8");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickNine()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(9);
            Form1.setDisplay("9");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickZero()
        {
            Form1.resetToInfix();
            Form1.setFirstValue(0);
            Form1.setDisplay("0");
            Form1.setState(new InfixInputFirstValue());
        }
        public void clickAdd()
        {
            Form1.setOperand('a');
            Form1.setDisplay(Form1.getDisplay() + '+');
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickSub()
        {
            Form1.setOperand('s');
            Form1.setDisplay(Form1.getDisplay() + '-');
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickMult()
        {
            Form1.setOperand('m');
            Form1.setDisplay(Form1.getDisplay() + '*');
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');
            Form1.setDisplay(Form1.getDisplay() + '/');
            Form1.setState(new InfixWaitMoreInput());
        }
        public void clickDecimal()
        {
            Form1.resetToInfix();
            Form1.setDisplay("0.");
            Form1.setFirstDec(0);
            Form1.setState(new InfixInputFirstValueDecimal());
        }
        public void clickEqual()
        {
            Form1.setDisplay(Form1.doCalculation().ToString());
        }
    }

    public class RPNWaitFirstInput : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setFirstValue(1);
            Form1.setDisplay("1");
            Form1.setFirstDec(0);
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickTwo()
        {
            Form1.setFirstValue(2);
            Form1.setFirstDec(0);
            Form1.setDisplay("2");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickThree()
        {
            Form1.setFirstValue(3);
            Form1.setFirstDec(0);
            Form1.setDisplay("3");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickFour()
        {
            Form1.setFirstValue(4);
            Form1.setFirstDec(0);
            Form1.setDisplay("4");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickFive()
        {
            Form1.setFirstValue(5);
            Form1.setFirstDec(0);
            Form1.setDisplay("5");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickSix()
        {
            Form1.setFirstValue(6);
            Form1.setFirstDec(0);
            Form1.setDisplay("6");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickSeven()
        {
            Form1.setFirstValue(7);
            Form1.setFirstDec(0);
            Form1.setDisplay("7");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickEight()
        {
            Form1.setFirstValue(8);
            Form1.setFirstDec(0);
            Form1.setDisplay("8");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickNine()
        {
            Form1.setFirstValue(9);
            Form1.setFirstDec(0);
            Form1.setDisplay("9");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickZero()
        {
            Form1.setFirstValue(0);
            Form1.setFirstDec(0);
            Form1.setDisplay("0");
            Form1.setState(new RPNInputFirstValue());
        }
        public void clickAdd()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.setDisplay("0.");
            Form1.setFirstDec(0);
            Form1.setState(new RPNInputFirstValueDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
    }

    public class RPNInputFirstValue : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setFirstValue(10 * Form1.getFirstValue());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay() + ".");
            Form1.setState(new RPNInputFirstValueDecimal());
        }
        public void clickEqual()
        {
            Form1.setDisplay(Form1.getDisplay() + ",");
            Form1.setState(new RPNWaitMoreInput());
        }
    }
    public class RPNInputFirstValueDecimal : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setFirstDec(Form1.getFirstDecimalCount() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setFirstDec(10 * Form1.getFirstDecimalCount());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickEqual()
        {
            Form1.setDisplay(Form1.getDisplay() + ",");
            Form1.setState(new RPNWaitMoreInput());
        }
    }
    public class RPNWaitMoreInput : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setSecondValue(1);
            Form1.setDisplay(Form1.getDisplay() + "1");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickTwo()
        {
            Form1.setSecondValue(2);
            Form1.setDisplay(Form1.getDisplay() + "2");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickThree()
        {
            Form1.setSecondValue(3);
            Form1.setDisplay(Form1.getDisplay() + "3");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickFour()
        {
            Form1.setSecondValue(4);
            Form1.setDisplay(Form1.getDisplay() + "4");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickFive()
        {
            Form1.setSecondValue(5);
            Form1.setDisplay(Form1.getDisplay() + "5");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickSix()
        {
            Form1.setSecondValue(6);
            Form1.setDisplay(Form1.getDisplay() + "6");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickSeven()
        {
            Form1.setSecondValue(7);
            Form1.setDisplay(Form1.getDisplay() + "7");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickEight()
        {
            Form1.setSecondValue(8);
            Form1.setDisplay(Form1.getDisplay() + "8");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickNine()
        {
            Form1.setSecondValue(9);
            Form1.setDisplay(Form1.getDisplay() + "9");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickZero()
        {

            Form1.setDisplay(Form1.getDisplay() + "0");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickAdd()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickSub()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickMult()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDiv()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay() + "0.");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValuesDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
    }
    public class RPNInputMoreValues : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setSecondValue(10 * Form1.getSecondValue());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.setOperand('a');
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickSub()
        {
            Form1.setOperand('s');
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickMult()
        {
            Form1.setOperand('m');
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');
            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickDecimal()
        {
            Form1.setDisplay(Form1.getDisplay() + ".");
            Form1.setState(new RPNInputMoreValuesDecimal());
        }
        public void clickEqual()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
    }
    public class RPNInputMoreValuesDecimal : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 1);
            Form1.setDisplay(Form1.getDisplay() + "1");
        }
        public void clickTwo()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 2);
            Form1.setDisplay(Form1.getDisplay() + "2");
        }
        public void clickThree()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 3);
            Form1.setDisplay(Form1.getDisplay() + "3");
        }
        public void clickFour()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 4);
            Form1.setDisplay(Form1.getDisplay() + "4");
        }
        public void clickFive()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 5);
            Form1.setDisplay(Form1.getDisplay() + "5");
        }
        public void clickSix()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 6);
            Form1.setDisplay(Form1.getDisplay() + "6");
        }
        public void clickSeven()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 7);
            Form1.setDisplay(Form1.getDisplay() + "7");
        }
        public void clickEight()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 8);
            Form1.setDisplay(Form1.getDisplay() + "8");
        }
        public void clickNine()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount() + 9);
            Form1.setDisplay(Form1.getDisplay() + "9");
        }
        public void clickZero()
        {
            Form1.setSecondDec(10 * Form1.getSecondDecimalCount());
            Form1.setDisplay(Form1.getDisplay() + "0");
        }
        public void clickAdd()
        {
            Form1.setOperand('a');

            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickSub()
        {
            Form1.setOperand('s');

            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickMult()
        {
            Form1.setOperand('m');

            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');

            Form1.setDisplay(Form1.doCalculation().ToString());
            Form1.setState(new RPNResultActive());
        }
        public void clickDecimal()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
        public void clickEqual()
        {
            Form1.resetToRPN();
            Form1.setDisplay("error");
        }
    }
    public class RPNResultActive : CalcState
    {
        public void clickMode()
        {
            Form1.resetToInfix();
        }
        public void clickOne()
        {
            Form1.setSecondValue(1);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",1");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickTwo()
        {
            Form1.setSecondValue(2);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",2");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickThree()
        {
            Form1.setSecondValue(3);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",3");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickFour()
        {
            Form1.setSecondValue(4);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",4");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickFive()
        {
            Form1.setSecondValue(5);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",5");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickSix()
        {
            Form1.setSecondValue(6);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",6");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickSeven()
        {
            Form1.setSecondValue(7);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",7");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickEight()
        {
            Form1.setSecondValue(8);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",8");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickNine()
        {
            Form1.setSecondValue(9);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",9");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickZero()
        {
            Form1.setSecondValue(0);
            Form1.setDisplay(Form1.getDisplay() + ",0");
            Form1.setSecondDec(0);
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickAdd()
        {
            Form1.setOperand('a');

            Form1.setDisplay(Form1.doCalculation().ToString());
        }
        public void clickSub()
        {
            Form1.setOperand('s');

            Form1.setDisplay(Form1.doCalculation().ToString());
        }
        public void clickMult()
        {
            Form1.setOperand('m');

            Form1.setDisplay(Form1.doCalculation().ToString());
        }
        public void clickDiv()
        {
            Form1.setOperand('d');

            Form1.setDisplay(Form1.doCalculation().ToString());
        }
        public void clickDecimal()
        {
            Form1.setSecondValue(0);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",0.");
            Form1.setState(new RPNInputMoreValues());
        }
        public void clickEqual()
        {
            Form1.setSecondValue(0);
            Form1.setSecondDec(0);
            Form1.setDisplay(Form1.getDisplay() + ",");
            Form1.setState(new RPNWaitMoreInput());
        }
    }
}
