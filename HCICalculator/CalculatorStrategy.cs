using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCICalculator
{
    interface CalculatorStrategy
    {
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
}
