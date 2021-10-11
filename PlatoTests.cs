using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover.Tests
{

    [TestClass()]
    public class PlatoTests
    {
        [TestMethod()]
        public void TestCaseIsFirstInputValid()
        {
            Validation validation = new Validation();
            string input = "5 5"; // "55" yazıldığında fail olacaktır

            try
            {
                validation.isFirstInputValid(input);

            }
           
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Invalid Input");
                Assert.Fail("INVALID INPUT");
            }

        }
        [TestMethod()]
        public void TestCaseIsSecondInputValid()
        {
            Validation validation = new Validation();
            string input = "1 2 N"; // "12 N" veya "1 2N" şeklinde yazıldığında fail olacaktır.
            string[] arr = input.Split(' ');

            try
            {
                validation.isSecondInputValid(arr);

            }

            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Invalid Input");
                Assert.Fail("INVALID INPUT");
            }

        }
        [TestMethod()]
        public void TestCaseIsThirdInputValid()
        {
            Validation validation = new Validation();
            string input = "LLMLMLMM"; // boşluk bırakıldığında fail olacaktır

            try
            {
                validation.isThirdInputValid(input);

            }

            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "Invalid Input");
                Assert.Fail("INVALID INPUT");
            }

        }
        [TestMethod()]
        public void TestCaseTravelling()  
        {
            
            try
            {
                Plato plato = new Plato(5, 5);
                plato.Travelling(1, 2, 'N', "LMLMLMLMM"); // "LMMMMLMLMM" yazıldığında fail olacaktır. Çünkü platonun sınırları dışına taşmış oluyor.
            }
            
            catch(ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, " Traveller out of the plato");
                Assert.Fail("TRAVELLER OUT OF PLATO");
                
            }
            
            
        }
        [TestMethod()]
        public void TestCaseMoveToRight() 
        {
            char location = 'N';
            
            Plato plato = new Plato(5, 5);
            location = plato.MoveToRight(location);
            Assert.AreEqual(location, 'E'); // 'E' yerine başka bir şey yazıldığında fail olacaktır.
           
        }
        [TestMethod()]
        public void TestCaseMoveToLeft()
        {
            char location = 'N';

            Plato plato = new Plato(5, 5);
            location = plato.MoveToLeft(location);
            Assert.AreEqual(location, 'W'); // 'W' yerine başka bir şey yazıldığında fail olacaktır.

        }
        [TestMethod()]
        public void TestCaseCreatingPlato() // x veya y yerine sıfır veya daha küçük sayı girildiğinde fail olacaktır.
        {
            int x = 1;
            int y = 5;
            try
            {
                Plato plato = new Plato(x, y);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "Plato values can not be equal or less than 0 ");
                Assert.Fail("X AND Y CAN NOT BE EQUAL OR LESS THAN 0");

            }
        }
        

    }
}