using System.Collections.Generic;

namespace LINQ
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CustomerTypeId { get; set; }
        public string EmailAddress { get; set; }

        public List<Invoice> InvoiceList { get; set; }

    }
}
