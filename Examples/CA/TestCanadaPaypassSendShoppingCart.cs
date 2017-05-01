namespace Moneris
{
    using System;
    using System.Text;
    using System.Collections;

    public class TestCanadaPaypassSendShoppingCart
    {
        public static void Main(string[] args)
        {
            string store_id = "moneris";
            string api_token = "hurgle";
            string subtotal = "1.00";
            string suppress_shipping_address = "true";
            string processing_country_code = "CA";

            PaypassSendShoppingCart paypassSendShoppingCart = new PaypassSendShoppingCart();
            paypassSendShoppingCart.SetSubtotal(subtotal);
            paypassSendShoppingCart.SetSuppressShippingAddress(suppress_shipping_address);

            /*Optional*/
            paypassSendShoppingCart.SetMerchantCallbackUrl("");
            paypassSendShoppingCart.SetMerchantCardList("");

            HttpsPostRequest mpgReq = new HttpsPostRequest();
            mpgReq.SetProcCountryCode(processing_country_code);
            mpgReq.SetTestMode(true); //false or comment out this line for production transactions
            mpgReq.SetStoreId(store_id);
            mpgReq.SetApiToken(api_token);
            mpgReq.SetTransaction(paypassSendShoppingCart);
            mpgReq.Send();

            try
            {
                Receipt receipt = mpgReq.GetReceipt();

                Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                Console.WriteLine("ISO = " + receipt.GetISO());
                Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                Console.WriteLine("TransDate = " + receipt.GetTransDate());
                Console.WriteLine("TransTime = " + receipt.GetTransTime());
                Console.WriteLine("TransType = " + receipt.GetTransType());
                Console.WriteLine("Complete = " + receipt.GetComplete());
                Console.WriteLine("Message = " + receipt.GetMessage());
                Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                Console.WriteLine("CardType = " + receipt.GetCardType());
                Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                Console.WriteLine("TimedOut = " + receipt.GetTimedOut());
                Console.WriteLine("Ticket = " + receipt.GetTicket());
                Console.WriteLine("MPRequestToken = " + receipt.GetMPRequestToken());
                Console.WriteLine("MPRedirectUrl = " + receipt.GetMPRedirectUrl());

                //PayPassInfo
                Console.WriteLine("\nCardBrandId = " + receipt.GetCardBrandId());
                Console.WriteLine("CardBrandName = " + receipt.GetCardBrandName());
                Console.WriteLine("CardBillingAddressCity = " + receipt.GetCardBillingAddressCity());
                Console.WriteLine("CardBillingAddressCountry = " + receipt.GetCardBillingAddressCountry());
                Console.WriteLine("CardBillingAddressCountrySubdivision = " + receipt.GetCardBillingAddressCountrySubdivision());
                Console.WriteLine("CardBillingAddressLine1 = " + receipt.GetCardBillingAddressLine1());
                Console.WriteLine("CardBillingAddressLine2 = " + receipt.GetCardBillingAddressLine2());
                Console.WriteLine("CardBillingAddressPostalCode = " + receipt.GetCardBillingAddressPostalCode());
                Console.WriteLine("CardCardHolderName = " + receipt.GetCardCardHolderName());
                Console.WriteLine("CardExpiryMonth = " + receipt.GetCardExpiryMonth());
                Console.WriteLine("CardExpiryYear = " + receipt.GetCardExpiryYear());
                Console.WriteLine("TransactionId = " + receipt.GetTransactionId());
                Console.WriteLine("ContactEmailAddress = " + receipt.GetContactEmailAddress());
                Console.WriteLine("ContactFirstName = " + receipt.GetContactFirstName());
                Console.WriteLine("ContactLastName = " + receipt.GetContactLastName());
                Console.WriteLine("ContactPhoneNumber = " + receipt.GetContactPhoneNumber());
                Console.WriteLine("ShippingAddressCity = " + receipt.GetShippingAddressCity());
                Console.WriteLine("ShippingAddressCountry = " + receipt.GetShippingAddressCountry());
                Console.WriteLine("ShippingAddressCountrySubdivision = " + receipt.GetShippingAddressCountrySubdivision());
                Console.WriteLine("ShippingAddressLine1 = " + receipt.GetShippingAddressLine1());
                Console.WriteLine("ShippingAddressLine2 = " + receipt.GetShippingAddressLine2());
                Console.WriteLine("ShippingAddressPostalCode = " + receipt.GetShippingAddressPostalCode());
                Console.WriteLine("ShippingAddressRecipientName = " + receipt.GetShippingAddressRecipientName());
                Console.WriteLine("ShippingAddressRecipientPhoneNumber = " + receipt.GetShippingAddressRecipientPhoneNumber());
                Console.WriteLine("PayPassWalletIndicator = " + receipt.GetPayPassWalletIndicator());
                Console.WriteLine("AuthenticationOptionsAuthenticateMethod = " + receipt.GetAuthenticationOptionsAuthenticateMethod());
                Console.WriteLine("AuthenticationOptionsCardEnrollmentMethod = " + receipt.GetAuthenticationOptionsCardEnrollmentMethod());
                Console.WriteLine("CardAccountNumber = " + receipt.GetCardAccountNumber());
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
