using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeWebApi.Services;
using CodeWebApi.Models;

namespace UnitTestProject
{
    [TestClass]
    public class FindSpyUnitTest
    {
        [TestMethod]
        public void Test_FindSpy_Calculation()
        {
            // arrange
            /*
            [1,2,4,0,0,7,5] [0,0,7] James Bond true
            [0,2,2,0,4,7,0] [0,0,7] James Bond true
            [1,2,0,7,4,4,0] [0,0,7] James Bond false
            [3,6,0,1,2,6,4] [3,1,4] Ethan Hunt true
            [3,3,1,5,1,4,4] [3,1,4] Ethan Hunt true
            [4,1,3,8,4,3,1] [3,1,4] Ethan Hunt false
            3,3,1,1,4,4
           */
            string message = "4,1,3,8,4,3,1";
            string codename = "3,1,4";
            
            SpyService spyService = new SpyService();
            // act
            bool findingflag = spyService.FindSpy(codename, message);

            // assert
            Assert.AreEqual(findingflag, true);
        }
    }
}
