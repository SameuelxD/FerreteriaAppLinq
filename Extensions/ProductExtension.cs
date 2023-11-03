using System.Numerics;
using ConsoleTables;
using FerreteriaLinq.Entities;

namespace FerreteriaLinq.Extensions
{
    public class ProductExtension
    {
        List<Product> ListProducts = new List<Product>(){
            new Product(){ProductId=123,ProductName="Tornillos",PriceUnit=500,Quantity=4,StockMin=5,StockMax=100},
            new Product(){ProductId=124,ProductName="Cauchos",PriceUnit=200,Quantity=5,StockMin=5,StockMax=50}
        };
        /*public void ValidateData(){
            foreach(var data in ListProducts){
                try{
                    String validateId=Convert.ToString(data.ProductId);
                }
                catch(Exception ex){

                }
            }
        }*/
        public void ProductsInventory()
        {
            Console.Clear();
            Console.WriteLine("|------------------------- PRODUCTS INVENTORY -----------------------|");
            var table = new ConsoleTable("ProductId","ProductName","PriceUnit","Quantity","StockMin","StockMax");
            ListProducts.ForEach(product => table.AddRow(product.ProductId,product.ProductName,product.PriceUnit,product.Quantity,product.StockMin,product.StockMax));  
            table.Write(Format.Alternative);
            Console.ReadLine();
        }
        public void ProductsStockMin()
        {
            Console.Clear();
            var ListStockMin = ListProducts.Where(product => product.Quantity >= 0 && product.Quantity <= product.StockMin).ToList<Product>();
            Console.WriteLine("|------------------- PRODUCTS STOCKMIN ------------------|");
            var table = new ConsoleTable("ProductId","ProductName","Quantity","StockMin","StockMax");
            ListStockMin.ForEach(product => table.AddRow(product.ProductId,product.ProductName,product.Quantity,product.StockMin,product.StockMax));
            table.Write(Format.Alternative);
            Console.ReadLine();
        }
        public void PurchasesProductsRequired()
        {
            Console.Clear();
            var ListProductsRequired = ListProducts.Where(product => product.Quantity >= 0 && product.Quantity < product.StockMin && product.Quantity < product.StockMax).ToList<Product>();
            Console.WriteLine("|-------------------------------- PURCHASES PRODUCTS REQUIRED --------------------------------|");
            var table = new ConsoleTable("ProductId","ProductName","Quantity","StockMin","StockMax","UnitsRequired","AvailableUnitsAdd");
            ListProductsRequired.ForEach(product => table.AddRow(product.ProductId,product.ProductName,product.Quantity,product.StockMin,product.StockMax,product.StockMin-product.Quantity,product.StockMax-product.Quantity));
            table.Write(Format.Alternative);
            Console.ReadLine();
        }
        public void AddProducts()
        {
            Console.Clear();
            int addUnits=0;
            var InventoryProductsAvailable = ListProducts.Where(product => product.Quantity >= 0 && product.Quantity < product.StockMax).ToList<Product>();
            Console.WriteLine(" --------------------  ADD UNITS -------------------- ");

            foreach (var product in InventoryProductsAvailable)
            {
                int availableUnitsAdd = product.StockMax - product.Quantity;
                Console.WriteLine($"ProductId: {product.ProductId}, ProductName: {product.ProductName}, Quantity: {product.Quantity}, StockMin: {product.StockMin}, StockMax: {product.StockMax}, AvailableUnitsAdd: {availableUnitsAdd}");

                bool validInput = false;

                while (!validInput)
                {
                    Console.WriteLine($"How many Units do you want to add to the inventory? AvailableUnitsAdd: {availableUnitsAdd}");
                    if (int.TryParse(Console.ReadLine(), out addUnits))
                    {
                        if (addUnits >= 0 && addUnits <= availableUnitsAdd)
                        {
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("¡Error! The figure to add units cannot exceed the StockMax, nor can it be less than 0");
                        }
                    }
                    else
                    {
                        Console.WriteLine("¡Error! Wrong Data Type");
                    }
                }

                Console.WriteLine($"Adding {addUnits} products");
                product.Quantity += addUnits;
                Console.WriteLine(product.Quantity);
            }

            Console.ReadLine();
        }
        public void TotalInventoryValue()
        {
            Console.Clear();
            double TotalInventoryValue = 0; // Inicializa la variable
            var table = new ConsoleTable("ProductId","ProductName","PriceUnit","Quantity","StockMin","StockMax","ProductInventoryValue");
            var tableTotal = new ConsoleTable("TotalInventoryValue");
            foreach (var product in ListProducts)
            {
                double ProductInventoryValue = product.Quantity * product.PriceUnit;
                table.AddRow(product.ProductId,product.ProductName,product.PriceUnit,product.Quantity,product.StockMin,product.StockMax,ProductInventoryValue);
                TotalInventoryValue += ProductInventoryValue; // Acumula el valor
            }
            Console.WriteLine(" |----------------------------------  PRODUCT INVENTORY VALUE ---------------------------------| ");
            table.Write(Format.Alternative);
            Console.ReadLine();
            tableTotal.AddRow(TotalInventoryValue);
            Console.WriteLine("|TOTAL INVENTORY VALUE|");
            tableTotal.Write(Format.Alternative);
            Console.ReadLine();
        }


    }
}