using System.Numerics;
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
            Console.WriteLine("--------------------  PRODUCTS INVENTORY -------------------- ");
            ListProducts.ForEach(product => Console.WriteLine($"ProductId: {product.ProductId} ProductName: {product.ProductName}  PriceUnit: {product.PriceUnit} Quantity: {product.Quantity} StockMin: {product.StockMin} StockMax: {product.StockMax} "));
            Console.ReadLine();
        }
        public void ProductsStockMin()
        {
            Console.Clear();
            var ListStockMin = ListProducts.Where(product => product.Quantity >= 0 && product.Quantity <= product.StockMin).ToList<Product>();
            Console.WriteLine(" --------------------  PRODUCTS STOCKMIN -------------------- ");
            ListStockMin.ForEach(product => Console.WriteLine($"ProductId: {product.ProductId}  ProductName: {product.ProductName}  Quantity: {product.Quantity}  StockMin: {product.StockMin}  StockMax: {product.StockMax} "));
            Console.ReadLine();
        }
        public void PurchasesProductsRequired()
        {
            Console.Clear();
            var ListProductsRequired = ListProducts.Where(product => product.Quantity >= 0 && product.Quantity < product.StockMin && product.Quantity < product.StockMax).ToList<Product>();
            Console.WriteLine("--------------------  PURCHASES PRODUCTS REQUIRED --------------------  ");
            ListProductsRequired.ForEach(product => Console.WriteLine($"ProductId: {product.ProductId} ProductName: {product.ProductName} Quantity: {product.Quantity} StockMin: {product.StockMin} StockMax: {product.StockMax} UnitsRequired: {product.StockMin - product.Quantity} AvailableUnitsAdd: {product.StockMax - product.Quantity}"));
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
            Console.WriteLine("--------------------  TOTAL INVENTORY VALUE -------------------- ");

            foreach (var product in ListProducts)
            {
                double ProductInventoryValue = product.Quantity * product.PriceUnit;

                Console.WriteLine($"ProductId: {product.ProductId} ProductName: {product.ProductName} PriceUnit: {product.PriceUnit} Quantity: {product.Quantity} StockMin: {product.StockMin} StockMax: {product.StockMax} ProductInventoryValue: {ProductInventoryValue}");

                TotalInventoryValue += ProductInventoryValue; // Acumula el valor
            }

            Console.WriteLine($"TotalInventoryValue: {TotalInventoryValue}");
            Console.ReadLine();
        }


    }
}