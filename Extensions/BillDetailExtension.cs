using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FerreteriaLinq.Entities;

namespace FerreteriaLinq.Extensions
{
    public class BillDetailExtension
    {
        List<BillDetail> ListBillsDetails=new List<BillDetail>(){
            new BillDetail(){BillDetailId=10,BillNumber=7,ProductIds=new List<int> {123,124},QuantitySolds=new List<int> {5,5},ValueSolds=new List<double> {2500,1000}},

            new BillDetail(){BillDetailId=11,BillNumber=8,ProductIds=new List<int> {123,124},QuantitySolds=new List<int> {2,8},ValueSolds=new List<double> {1000,1600}}
        };
        public void ProductsSoldInvoice()
        {
            Console.WriteLine("Enter the Invoice Number to Search: ");
            int billNumber;
            
            if (int.TryParse(Console.ReadLine(), out billNumber))
            {
                var relevantBillDetails = ListBillsDetails
                    .Where(billDetail => billDetail.BillNumber == billNumber)
                    .ToList();

                if (relevantBillDetails.Count == 0)
                {
                    Console.WriteLine("No matching invoices found.");
                }
                else
                {
                    Console.WriteLine("--------------------  PRODUCTS SOLD INVOICE -------------------- ");
                    foreach (var billDetail in relevantBillDetails)
                    {
                        Console.WriteLine($"BillDetailId: {billDetail.BillDetailId}, BillNumber: {billDetail.BillNumber}");
                        for (int i = 0; i < billDetail.ProductIds.Count; i++)
                        {
                            Console.WriteLine($"ProductId: {billDetail.ProductIds[i]}, QuantitySold: {billDetail.QuantitySolds[i]}, ValueSold: {billDetail.ValueSolds[i]}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.ReadLine();
        }

    }
}