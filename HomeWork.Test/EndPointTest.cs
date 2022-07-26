using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeWork.Entities;


namespace HomeWork.Test
{
    [TestClass]
    public class EndPointTest
    {
        [TestMethod]
        public void meterModel_PassedTrueValue_Return()
        {
            EndPoint endPoint = new EndPoint();

            endPoint.meterNumber = 1234;

            int resultWaited = 1234;

            int resultNow = endPoint.meterNumber;

            Assert.AreEqual(resultWaited, resultNow);
        }
        [TestMethod]
        public void State_PassedTrueValue_Return()
        {
            EndPoint endPoint = new EndPoint();

            endPoint.State = (EState)1;

            var resultWaited = EState.Connected;

            var resultNow = endPoint.State;

            Assert.AreEqual(resultWaited, resultNow);
        }    
        [TestMethod]
        public void MeterModel_PassedTrueValue_Return()
        {
            EndPoint endPoint = new EndPoint();

            endPoint.meterModel = (EMeterModel)17;

            var resultWaited = EMeterModel.NSX1P13W;

            var resultNow = endPoint.meterModel;

            Assert.AreEqual(resultWaited, resultNow);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void MeterModel_PassedFakeValue_Return()
        {
            EndPoint endPoint = new EndPoint();

            endPoint.meterModel = (EMeterModel)10;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void State_PassedFakeValue_Return()
        {
            EndPoint endPoint = new EndPoint();

            endPoint.State = (EState)4;
        }
    }
}
