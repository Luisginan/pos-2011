using BPRoc_LIB;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UITesting
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class UITest1
    {
        [TestMethod]
        public void Register()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            //this.UIMap.OpenRegister();
            this.UIMap.Registering();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void AddItemDiferentUnit()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();

            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                this.UIMap.ChangeUnit();
                this.UIMap.InputBarcode();
                i += 1;
                if (i == 5) break;
            }
            this.UIMap.FinishTransaction();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void AddItemChangeQtyAndPrice()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();
            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                this.UIMap.ChangeQtyAndPriceParams.UIItemEditText1 = (satuan.HargaJual + 1000).ToString();
                this.UIMap.ChangeQtyAndPrice();
                i += 1;
                if (i == 5) break;
            }
            this.UIMap.FinishTransaction();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void AddItemChangePrice()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();
            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                //this.UIMap.ChangePriceParams.UIItemEditText = (satuan.HargaJual + 1000).ToString();
                this.UIMap.ChangeQtyAndPriceParams.UIItemEditText = 100.ToString();
                this.UIMap.ChangeQtyAndPriceParams.UIItemEditText1 = 10000.ToString();
                this.UIMap.ChangeQtyAndPrice();
                i += 1;
                if (i == 5) break;
            }
            this.UIMap.FinishTransactionPrint();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void AddItemChangePriceAndCancel()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();
            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 ");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                this.UIMap.ChangePriceAndQtyCancelParams.UIItemEditText = (satuan.HargaJual + 1000).ToString();
                this.UIMap.ChangePriceAndQtyCancel();

                i += 1;
                if (i == 5) break;
            }
            this.UIMap.FinishTransactionPrint();
            this.UIMap.CloseCashier();
            // this.UIMap.CloseApp();
        }

        [TestMethod]
        public void AddItemChangeUnit()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();
            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                this.UIMap.ChangeUnit();

                i += 1;
                if (i == 5) break;
            }
            this.UIMap.FinishTransaction();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void TransactionWithBarcode()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();

            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = satuan.Barcode;
                this.UIMap.InputBarcode();
                i += 1;
                if (i == 5) break;
            }

            this.UIMap.FinishTransactionPrint();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void TransactionWithBarcodeAbnormal()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();

            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = "0" + satuan.Barcode;
                this.UIMap.InputBarcode();
                i += 1;
                if (i == 5) break;
            }

            this.UIMap.FinishTransactionPrint();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        [TestMethod]
        public void TransactionWithBarcodeCustom()
        {
            //this.UIMap.OpenApp();
            //this.UIMap.Login();
            this.UIMap.OpenCashier();
            this.UIMap.AddPenjualan();

            PublicFunction PF = new PublicFunction();
            var Satuans = PF.GetListSatuanDet("(SatuanDet.HargaJual - SatuanDet.HargaBeli) > 50 and par = 1 and left(barcode,1) = '0'");
            var i = 0;
            foreach (var satuan in Satuans)
            {
                this.UIMap.InputBarcodeParams.UIItemEditText = "0" + satuan.Barcode;
                this.UIMap.InputBarcode();
                i += 1;
                if (i == 5) break;
            }

            this.UIMap.FinishTransactionPrint();
            this.UIMap.CloseCashier();
            //this.UIMap.CloseApp();
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}