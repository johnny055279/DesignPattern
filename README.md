# DesignPattern
## Singleton Design Pattern
>定義: 單例對象的Class必須保證只有一個實例存在。

想像今天有一家餐廳，餐廳裡有三位服務生，每次客人需要服務時，都會按照順序出場。

因此我們可以建構一個類別:
```
// 建構服務生
public class TableServers{
    private List<string> servers = new();
    private int serverNum = 0;
    public TableServers()
    {
        servers.Add("Johnny");
        servers.Add("Marry");
        servers.Add("David");
    }

    // 呼叫服務生
    public string GetWhoIsServer()
    {
        string result = servers[serverNum];

        serverNum++;

        if(serverNum >= servers.Count) serverNum = 0;

        return result;
    }
}

```
我們可以呼叫這個類別來執行需要的程式碼:
```
// 建立一組客人的服務線
TableServers servers = new();
Console.WriteLine("Start Serving...");

// 需要出場5次
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"The next server is: { servers.GetWhoIsServer()}");
}
Console.WriteLine("End Serving...");
```
這樣看起來沒有問題，但是如果今天有兩組客人呢?
可能程式碼會這樣寫:
```
// 建立兩組客人的服務線
TableServers serverList1 = new();
TableServers serverList2 = new();
Console.WriteLine("Start Serving...");
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"The next server is: { serverList1.GetWhoIsServer() form server list 1}");
    Console.WriteLine($"The next server is: { serverList2.GetWhoIsServer() form server list 2}");
}
Console.WriteLine("End Serving...");
```
我們想要服務生依照順序出場服務客人:
- 第一位服務生去A桌
- 第二位服務生去B桌
- 第三位服務生去A桌
- 第四位服務生去B桌
...依此類推。

但是這樣寫會發現同一位服務生竟然會同時服務兩組客人，這顯然不是我們要的結果。

因此，Singleton Design Pattern就是用來解決這種問題。
修改程式碼如下:
```
public class TableServers
    {
        // 在取得TableServers的時候就建立實例
        // 此種作法既能保證是執行續安全，而且只會在真正使用到實體時才建立
        private static readonly TableServers instance = new();
        private List<string> servers = new();
        private int serverNum = 0;
        public TableServers()
        {
            servers.Add("Johnny");
            servers.Add("Marry");
            servers.Add("David");
        }
        
        // 建立static的方法來取得唯讀的實例
        public static TableServers GetTableServer()
        {
            return instance;
        }

        public string GetWhoIsServer()
        {
            string result = servers[serverNum];

            serverNum++;

            if(serverNum >= servers.Count) serverNum = 0;

            return result;
        }
    }
```
```
// 一樣建立兩條服務線，但是取得的都是同樣的TableServers實例(因為static)
TableServers serverList1 = TableServers.GetTableServer();
TableServers serverList2 = TableServers.GetTableServer();

Console.WriteLine("Start Serving...");

for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"The next server is: { serverList1.GetWhoIsServer()} from server list 1");
    Console.WriteLine($"The next server is: { serverList2.GetWhoIsServer()} from server list 2");
}

Console.WriteLine("End Serving...");
```
這樣就可以確保今天不管有幾組客人，服務生都會依序地去不同的客人服務，而不會發生影分身的情況。

Singleton Design Pattern要注意的是，一旦建立實例之後就會一直存在於記憶體中，直到程式關閉為止。
因此在使用時要確定是否真的需要時做這種設計模式。

上述程式碼是用來讀取【儲存】資料，並使其可以共用，但是有些單例模式並不是設計用來讀取儲存資料，最常見到的就是DI注入的AddSingleton<Class>()
當需要Class的時候，會給你一個singleton的Class，而Class中的方法並不需要是static。當第一位使用者因需要而建立一個實例之後，第二位使用者會繼續用同樣的實例。
