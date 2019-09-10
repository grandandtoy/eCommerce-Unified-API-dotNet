﻿using System;
using System.Collections.Generic;

using System.Text;
using Moneris;

namespace CanadaPurchaseConsoleTest
{
    class CanadaPurchaseTest
    {
		public static void Main(string[] args)
        {
            string order_id = "Test" + DateTime.Now.ToString("yyyyMMddhhmmss");
            string store_id = "store5";
            string api_token = "yesguy";            
            string amount = "5.00";
            string pan = "4242424242424242";
            string expdate = "1901"; //YYMM format
            string crypt = "7";
            string processing_country_code = "CA";
            bool status_check = false;

			CofInfo cof = new CofInfo();
			cof.SetPaymentIndicator("U");
			cof.SetPaymentInformation("2");
			cof.SetIssuerId("168451306048014");

            Purchase purchase = new Purchase();
            purchase.SetOrderId(order_id);
            purchase.SetAmount(amount);
            purchase.SetPan(pan);
            purchase.SetExpDate("2011");
            purchase.SetCryptType(crypt);
            purchase.SetDynamicDescriptor("2134565");
			//purchase.SetWalletIndicator(""); //Refer to documentation for details
			purchase.SetCofInfo(cof);
			
			//purchase.SetCmId("8nAK8712sGaAkls56"); //set only for usage with Offlinx - Unique max 50 alphanumeric characters transaction id generated by merchant

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(purchase);
            mpgReq.SetStatusCheck(status_check);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("ISO = " + receipt.GetISO());
                Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("IsVisaDebit = " + receipt.GetIsVisaDebit());
                Console.WriteLine("HostId = " + receipt.GetHostId());
                Console.WriteLine("IssuerId = " + receipt.GetIssuerId());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
