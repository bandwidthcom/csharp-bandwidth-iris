﻿using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bandwidth.Iris.Model
{
    public class Order: BaseModel
    {
        internal const string OrderPath = "orders";


        public static Task<OrderResult> Create(Client client, Order item)
        {
            return client.MakePostRequest<OrderResult>(client.ConcatAccountPath(OrderPath), item);
        }

#if !PCL
        public static Task<OrderResult> Create(Order item)
        {
            return Create(Client.GetInstance(), item);
        }

#endif
        public Task Update(Order item)
        {
            return Client.MakePutRequest(Client.ConcatAccountPath(string.Format("{0}/{1}", OrderPath, Id)),
                item, true);
        }

        public override string Id {
            get { return OrderId; }
            set { OrderId = value; } 
        }
        
        [XmlAttribute("id")]
        [DefaultValue(null)]
        public string OrderId { get; set; }
        [DefaultValue(null)]
        public string Name { get; set; }
        [DefaultValue(null)]
        public string SiteId { get; set; }
        [DefaultValue(null)]
        public bool? BackOrderRequested { get; set; }
        [DefaultValue(null)]
        public DateTime? OrderCreateDate { get; set; }
        public string CustomerOrderId { get; set; }
        [DefaultValue(null)]
        public bool? PartialAllowed { get; set; }
        [DefaultValue(null)]
        public bool? CloseOrder { get; set; }
        [DefaultValue(null)]
        public ExistingTelephoneNumberOrderType ExistingTelephoneNumberOrderType { get; set; }
        [DefaultValue(null)]
        public AreaCodeSearchAndOrderType AreaCodeSearchAndOrderType { get; set; }
        [DefaultValue(null)]
        public RateCenterSearchAndOrderType RateCenterSearchAndOrderType { get; set; }
        [XmlElement("NPANXXSearchAndOrderType")]
        [DefaultValue(null)]
        public NpaNxxSearchAndOrderType NpaNxxSearchAndOrderType { get; set; }
        [DefaultValue(null)]
        public TollFreeVanitySearchAndOrderType TollFreeVanitySearchAndOrderType { get; set; }
        [DefaultValue(null)]
        public TollFreeWildCharSearchAndOrderType TollFreeWildCharSearchAndOrderType { get; set; }
        [DefaultValue(null)]
        public StateSearchAndOrderType StateSearchAndOrderType { get; set; }
        [DefaultValue(null)]
        public CitySearchAndOrderType CitySearchAndOrderType { get; set; }
        [XmlElement("ZIPSearchAndOrderType")]
        [DefaultValue(null)]
        public ZipSearchAndOrderType ZipSearchAndOrderType { get; set; }
        [XmlElement("LATASearchAndOrderType")]
        [DefaultValue(null)]
        public LataSearchAndOrderType LataSearchAndOrderType { get; set; }

    }

    public class LataSearchAndOrderType
    {
        public string Lata { get; set; }
        public int Quantity { get; set; }
    }

    public class ZipSearchAndOrderType
    {
        public string Zip { get; set; }
        public int Quantity { get; set; }
    }

    public class CitySearchAndOrderType
    {
        public string City{ get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }
    }

    public class StateSearchAndOrderType
    {
        public string State { get; set; }
        public int Quantity { get; set; }
    }

    public class TollFreeWildCharSearchAndOrderType
    {
        public string TollFreeWildCardPattern { get; set; }
        public int Quantity { get; set; }
    }

    public class TollFreeVanitySearchAndOrderType
    {
        public string TollFreeVanity { get; set; }
        public int Quantity { get; set; }
    }

    public class NpaNxxSearchAndOrderType
    {
        public string NpaNxx { get; set; }
        [XmlElement("EnableTNDetail")]
        public bool EnableTnDetail { get; set; }
        [XmlElement("EnableLCA")]
        public bool EnableLca { get; set; }
        public int Quantity { get; set; }
    }

    public class RateCenterSearchAndOrderType
    {
        public string AreaCode { get; set; }
        public int Quantity { get; set; }
    }

    public class AreaCodeSearchAndOrderType
    {
        public string RateCenter { get; set; }
        public string State { get; set; }
        public int Quantity { get; set; }
    }

    public class ExistingTelephoneNumberOrderType
    {
        [XmlArrayItem("TelephoneNumber")]
        public string[] TelephoneNumberList { get; set; }
    }

    [XmlType("OrderResponse")]
    public class OrderResult
    {
        public Order Order { get; set; }
        public string CreatedByUser { get; set; }
        public int CompletedQuantity { get; set; }
        public int FailedQuantity { get; set; }
        public int PendingQuantity { get; set; }
        public DateTime OrderCompleteDate { get; set; }
        public string OrderStatus { get; set; }
        public TelephoneNumber[] CompletedNumbers { get; set; }
    }


    public class TelephoneNumber
    {
        public string FullNumber { get; set; }
    }
}
