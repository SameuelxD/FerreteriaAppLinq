using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;
using FerreteriaLinq.Entities;

namespace FerreteriaLinq.Extensions
{
    public class ClientExtension
    {
        List<Client> ListClients=new List<Client>(){
            new Client(){ClientId=1,ClientName="Samuel",ClientEmail="lineaddr2004@gmail.com"},
            new Client(){ClientId=2,ClientName="Jose",ClientEmail="millonarios13525@gmail.com"}
        };
        public void CustomerData()
        {
            Console.Clear();
            var table = new ConsoleTable("ClientId","ClientName","ClientEmail");
            ListClients.ForEach(client => table.AddRow(client.ClientId,client.ClientName,client.ClientEmail));
            Console.WriteLine("|-------------------CUSTOMER DATA-------------------|");
            table.Write(Format.Alternative);
            Console.ReadLine();
        } 
    }
}




