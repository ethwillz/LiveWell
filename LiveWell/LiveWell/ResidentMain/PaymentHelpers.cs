﻿using System;

namespace LiveWell.ResidentMain
{
    public class PayDetails
    {
        public String intent { get; set; }
        public Payer payer { get; set; }
        public Transactions transactions { get; set; }
    }

    public class Payer
    {
        public Payer(String payment_method, CreditCard funding_instruments)
        {
            this.payment_method = payment_method;
            this.funding_instruments = funding_instruments;
        }

        public String payment_method { get; set; }
        public CreditCard funding_instruments { get; set; }
    }

    public class CreditCard
    {
        public CreditCard(String number, String type, String expire_month, String expire_year, String cvv2, String first_name, String last_name)
        {
            this.number = number;
            this.type = type;
            this.expire_month = expire_month;
            this.expire_year = expire_year;
            this.cvv2 = cvv2;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public String number { get; set; }
        public String type { get; set; }
        public String expire_month { get; set; }
        public String expire_year { get; set; }
        public String cvv2 { get; set; }
        public String first_name { get; set; }
        public String last_name { get; set; }
    }

    public class Transactions
    {
        public Transactions(Amount amount, String description)
        {
            this.amount = amount;
            this.description = description;
        }

        public Amount amount { get; set; }
        public String description { get; set; }
    }

    public class Amount
    {
        public Amount(String total, String currency)
        {
            this.total = total;
            this.currency = currency;
        }

        public String total { get; set; }
        public String currency { get; set; }
    }

    public class OAuthDetails
    {
        public OAuthDetails(String client_credentials)
        {
            this.client_credentials = client_credentials;
        }

        public String client_credentials { get; set; }
    }

    public class AccessResponse
    {
        public AccessResponse(String scope, String access_token, String token_type, String app_id, String expires_in)
        {
            this.scope = scope;
            this.access_token = access_token;
            this.token_type = token_type;
            this.app_id = app_id;
            this.expires_in = expires_in;
        }

        public String scope { get; set; }
        public String access_token { get; set; }
        public String token_type { get; set; }
        public String app_id { get; set; }
        public String expires_in { get; set; }
    }
}
