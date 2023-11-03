using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaLinq.Entities;

namespace FerreteriaLinq.Extensions
{
    public class BillExtension
    {
        List<Bill> ListBills=new List<Bill>(){
            new Bill(){BillNumber=7,BillDate=new DateTime(2023,1,25,10,30,0),ClientId=1,TotalBill=2500},
            new Bill(){BillNumber=8,BillDate=new DateTime(2023,1,30,5,10,0),ClientId=2,TotalBill=1000}
        };
        public void InvoicesJanuary2023()
        {
            var ListInvoicesJanuary2023 = ListBills.Where(bill => bill.BillDate.Month == 1 && bill.BillDate.Year == 2023).ToList<Bill>();
            Console.WriteLine("--------------------  INVOICES JANUARY 2023 -------------------- ");
            ListInvoicesJanuary2023.ForEach(bill => Console.WriteLine($"BillNumber: {bill.BillNumber} BillDate: {bill.BillDate}  ClientId: {bill.ClientId} TotalBill: {bill.TotalBill}"));
            Console.ReadLine();
        }

    }
}
