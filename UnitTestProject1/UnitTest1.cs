using System;
using JoshuaC.Nealon_S00198699;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Game p1 = new Game("Halo 5",60,84, "Peace has been devastated as colony worlds are unexpectedly attacked. What's more, when humanity's greatest hero goes missing, a new Spartan is assigned the task of hunting the Master Chief and solving a mystery that threatens the whole of the galaxy.","Xbox");
            decimal finalPrice = 50;
            

            //Act
            p1.DecreasePrice(10);

            //Assert
            Assert.AreEqual(finalPrice, p1.Price);
        }
    }
}
