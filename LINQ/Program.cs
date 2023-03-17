using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void GroupByExample(List<Invoice> invoiceList)
        {
            var query = invoiceList.GroupBy(s => new
            {
                IsPaid = s.IsPaid,
                Month = s.InvoiceDate.ToString("MMMM")
            },
                                            e => e.TotalAmount,
                                            (key, invTotal) => new
                                            {
                                                Key = key,
                                                InvoicedAmount = invTotal.Sum()
                                            });
            foreach (var el in query)
            {
                Console.WriteLine(el.Key + "   " + el.InvoicedAmount);
            }
        }

        static void getInvoiceTotalByCustomerType(List<Customer> custList, List<CustomerType> ctypeList)
        {
            //var ctypeQuery = custList.Join(ctypeList,c=>c.CustomerTypeId,ct=>ct.)
        }
    }
}
