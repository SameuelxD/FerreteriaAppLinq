using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using FerreteriaLinq.Entities;

namespace FerreteriaLinq.Extensions
{
    public class BillExtension
    {
        List<Bill> ListBills=new List<Bill>(){
            new Bill(){BillNumber=7,BillDate=new DateTime(2023,1,25,10,30,0),ClientId=1,TotalBill=2500},
            new Bill(){BillNumber=8,BillDate=new DateTime(2023,1,30,5,10,0),ClientId=2,TotalBill=1000},
            new Bill(){BillNumber=9,BillDate=new DateTime(2023,8,20,5,10,0),ClientId=3,TotalBill=1500}
        };
        public void InvoicesJanuary2023()
        {
            var ListInvoicesJanuary2023 = ListBills.Where(bill => bill.BillDate.Month == 1 && bill.BillDate.Year == 2023).ToList<Bill>();
            var table = new ConsoleTable("BillNumber","BillDate","ClientId","TotalBill");
            ListInvoicesJanuary2023.ForEach(bill => table.AddRow(bill.BillNumber,bill.BillDate,bill.ClientId,bill.TotalBill));
            Console.WriteLine("---------------INVOICES JANUARY 2023---------------");
            table.Write(Format.Default);
            Console.ReadLine();
        }

    }
}
