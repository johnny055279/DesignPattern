using SingletonDemo;

TableServers serverList1 = TableServers.GetTableServer();
TableServers serverList2 = TableServers.GetTableServer();

Console.WriteLine("Start Serving...");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"The next server is: { serverList1.GetWhoIsServer()} from server list 1");
    Console.WriteLine($"The next server is: { serverList2.GetWhoIsServer()} from server list 2");
}

Console.WriteLine("End Serving...");
