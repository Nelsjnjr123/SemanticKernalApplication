using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace SemanticKernalApplication.WebAPI.Models.CDP
{
    public class CDP_Order_Checkout : CDPBase
    {
        [JsonProperty("order")]
        public CDP_Order Order { get; set; }
    }
    public class CDP_Order
    {
        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("cardType")]
        public string CardType { get; set; }

        [JsonProperty("extensions")]
        public dynamic[] Extensions { get; set; }

        [JsonProperty("orderItems")]
        public CDP_Orderitem[] OrderItems { get; set; }
    }
    public class CDP_Orderitem
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }

        [JsonProperty("orderedAt")]
        public DateTime OrderedAt { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("extensions")]
        public dynamic Extensions { get; set; }
    }





    public class CDP_ADDProduct : CDPBase
    {


        [JsonProperty("product")]
        public Product Product { get; set; }
    }

    public class Product
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("item_id")]
        public string ItemId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("orderedAt")]
        public string OrderedAt { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("productId")]
        public string ProductId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("originalPrice")]
        public float OriginalPrice { get; set; }

        [JsonProperty("originalCurrencyCode")]
        public string OriginalCurrencyCode { get; set; }

        [JsonProperty("referenceId")]
        public string ReferenceId { get; set; }
    }
    public class CDP_ADDContact : CDPBase
    {
        [JsonProperty("contact")]
        public Contact[] Contact { get; set; }
    }

    public class Contact
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("firstname")]
        public string Firstname { get; set; }

        [JsonProperty("lastname")]
        public string Lastname { get; set; }

        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("street")]
        public string[] Street { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("dob")]
        public string Dob { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("identifiers")]
        public Identifier[] Identifiers { get; set; }
    }



    public class CDP_Confirm : CDPBase
    {


        [JsonProperty("product")]
        public ConfrimProduct[] Product { get; set; }
    }

    public class ConfrimProduct
    {
        [JsonProperty("item_id")]
        public string ItemId { get; set; }
    }



    public class CDP_Checkout : CDPBase
    {
        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("price")]
        public double Price { get; set; }
        
    }

}
