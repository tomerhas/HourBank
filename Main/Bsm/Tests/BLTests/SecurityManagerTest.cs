using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BsmBL.Managers;
using BsmCommon.DataModels.Profiles;

namespace BLTests
{
    [TestClass]
    public class SecurityManagerTest
    {
        [TestMethod]
        public void CreateUserInfo_Succeded()
        {
            getUserInfo();
        }

        [TestMethod]
        public void User_ISPermitted_True()
        {

            var uf = getUserInfo();
            var result = uf.IsPermittedForMasach("WorkCard.aspx");
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void User_ISPermitted_False()
        {

            var uf = getUserInfo();
            var result = uf.IsPermittedForMasach("AAA.aspx");
            Assert.IsFalse(result);
        }


        private UserInfo getUserInfo()
        {
            SecurityManager sm = new SecurityManager();
             return sm.GetUserInfo(@"EGGED_D\meravn");
        }
    }

    
}
