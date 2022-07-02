using BPRoc_LIB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEMICO_Dialog;
using System;

namespace UITesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetlistBarang()
        {
            Setting.UpdateMySetting(".", "sa", "123456");
            PublicFunction PF = new PublicFunction();

            var barangs = PF.GetListBarang();
            Assert.AreNotEqual(barangs.Count, 0);
        }

        [TestMethod]
        public void TestGetlistSatuanDetWthoutParam()
        {
            //Setting.ConectionString = ClsQuickCode.ProviderSQLserver("sa", "123456", ".", "mandiri");
            PublicFunction PF = new PublicFunction();
            var barangs = PF.GetListSatuanDet();
            Assert.AreNotEqual(barangs.Count, 0);
        }
    }
}