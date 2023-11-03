using FerreteriaLinq.Entities;
using FerreteriaLinq.Extensions;

internal class Program
{
    private static void Main(string[] args)
    {
        bool flag = true;
        int option = 0; // Cambiado a int ya que estamos esperando un número entero

        while (flag)
        {
            Console.WriteLine(" ");
            Console.WriteLine(" -------------------- MENU -------------------- ");
            Console.WriteLine(" 1. List Inventory Products.");
            Console.WriteLine(" 2. List the Products that are about to run out of Stock.");
            Console.WriteLine(" 3. List the Products that need to be purchased and the Quantity to be Purchased.");
            Console.WriteLine(" 4. List the Total Invoices for the Month of January 2023.");
            Console.WriteLine(" 5. List the Products Sold on a Certain Invoice.");
            Console.WriteLine(" 6. Calculate the Total Value of the Inventory.");
            Console.WriteLine(" 7. List Customer Data.");
            Console.WriteLine(" 8. Closed Program.");
            Console.WriteLine(" ");

            Console.Write("Ingrese opción: ");
            if (int.TryParse(Console.ReadLine(), out option))
            {
                ProductExtension PrintListProducts = new ProductExtension();
                BillExtension PrintListBills = new BillExtension();
                BillDetailExtension PrintListBillsDetails= new BillDetailExtension();
                ClientExtension PrintListClients=new ClientExtension();
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        PrintListProducts.ProductsInventory();
                        break;
                    case 2:
                        Console.Clear();
                        PrintListProducts.ProductsStockMin();
                        break;
                    case 3:
                        Console.Clear();
                        PrintListProducts.PurchasesProductsRequired();
                        //PrintListProducts.AddProducts();
                        break;  
                    case 4:
                        Console.Clear();
                        PrintListBills.InvoicesJanuary2023();
                        break;
                    case 5:
                        Console.Clear();
                        PrintListBillsDetails.ProductsSoldInvoice();
                        break;
                    case 6:
                        Console.Clear();
                        PrintListProducts.TotalInventoryValue();
                        break;
                    case 7: 
                        Console.Clear();
                        PrintListClients.CustomerData();
                        break;
                    case 8: 
                        Console.Clear();
                        Console.WriteLine("Closing Program");
                        flag=false;
                        break;
                    default:
                        Console.WriteLine("Non-existent option");
                        break;
                }
            }
            else{
                Console.WriteLine("Inconsistent data error");
            }
        }
    }
}