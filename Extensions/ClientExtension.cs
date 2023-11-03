using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            Console.WriteLine("--------------------  CUSTOMER DATA -------------------- ");
            ListClients.ForEach(client => Console.WriteLine($"ClientId: {client.ClientId} ClientName: {client.ClientName} ClientEmail: {client.ClientEmail} "));
            Console.ReadLine();
        } 
    }
}




