# DesignPattern
## 目錄:
- <a href="#Singleton">Singleton Design Pattern</a>
- <a href="#SRP">Single Responsibility Principle</a>
- <a href="#OCP">Open Closed Principle</a>
- <a href="#LSP">Liskov Substitution Principle</a>

## <a name="Singleton">Singleton Design Pattern</a>
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
...依此類推。

但是這樣寫會發現同一位服務生竟然會同時服務兩組客人，這顯然不是我們要的結果。

因此，Singleton Design Pattern就是用來解決這種問題。
修改程式碼如下:
```
public class TableServers
    {
        // 在取得TableServers的時候就建立實例
        // 此種作法既能保證是執行緒安全，而且只會在真正使用到實體時才建立
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
因此在使用時要確定是否真的需要實作這種設計模式。

上述程式碼是用來讀取【儲存】資料，並使其可以共用，但是有些單例模式並不是設計用來讀取儲存資料，最常見到的就是DI注入的AddSingleton<Class>()
當需要Class的時候，會給你一個singleton的Class，而Class中的方法並不需要是static。當第一位使用者因需要而建立一個實例之後，第二位使用者會繼續用同樣的實例。

## <a name="SRP">Single Responsibility Principle</a>
> 定義: 保持一個Class專注於單一功能點，意味著如果想要修改，只能有唯一的原因
    
光看描述似懂非懂的，不如實作一個:
```
Console.WriteLine("Welcome!");

User user = new();

Console.Write("What is your first name?");

user.FirstName = Console.ReadLine();

Console.Write("What is your last name?");

user.LastName = Console.ReadLine();

if (string.IsNullOrWhiteSpace(user.FirstName)){
    Console.WriteLine("You don't give us a valid first name");
    Console.ReadLine();
    return;
}

if (string.IsNullOrWhiteSpace(user.LastName))
{
    Console.WriteLine("You don't give us a valid last name");
    Console.ReadLine();
    return;
}

Console.WriteLine($"Your name is {user.FirstName} {user.LastName}");
Console.ReadLine();
```
很明顯地，上述範例做了四個功能:
- 印出訊息
- 輸入名字
- 確認名字有效
- 創建帳號
    
無論今天要變更哪種功能的邏輯，都會修改到這一支程式碼。因此完全不符合單一職責的原則。我們必須針對這四種功能，將其提取出來，使其各別為一個小功能。
```
public class ShowMessage
{
    // 印出訊息的功能
    public static void ShowWelcomeMessage()
    {
        Console.WriteLine("Welcome");
    }

    public static void ShowEndMessage()
    {
        Console.WriteLine("Press any button to exit.");
        Console.ReadLine();
    }

    public static void ShowErrorMessage(string message)
    {
        Console.WriteLine($"You don't give us a valid {message}.");
    }
}
```
```
public class UserDataCapture
{
    // 產生使用者
    public static User GetUser()
    {
        User user = new();

        Console.Write("What is your first name?");

        user.FirstName = Console.ReadLine();

        Console.Write("What is your last name?");

        user.LastName = Console.ReadLine();

        return user;
    }
}
```
```
public class ValidateUserName
{
    // 驗證輸入資訊
    public static bool Validate(User user)
    {
        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            ShowMessage.ShowErrorMessage("first name");

            return false;
        }

        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            ShowMessage.ShowErrorMessage("last name");

            return false;
        }

        return true;
    }
}
```
```
public class UserGenerate
{
    // 產生帳號
    public static void CreateAccount(User user)
    {
        Console.WriteLine($"Your name is {user.FirstName} {user.LastName}");
    }
}
```
建立以上類別之後，我們主要的程式碼就變得很簡潔
```
ShowMessage.ShowWelcomeMessage();

var user = UserDataCapture.GetUser();

bool isValid = ValidateUserName.Validate(user);

if (!isValid) {

    ShowMessage.ShowEndMessage();

    return;
}

UserGenerate.CreateAccount(user);

ShowMessage.ShowEndMessage();
```
如此一來就保證每一個程式碼只能找到一種理由去改變它。


## <a name="OCP">Open Closed Principle</a>
> 定義: 程式對於修改是封閉的，但是對於擴展是開放的

這句話的意思是，對於已經上線的產品而言，任意地去修改現有的程式碼，有可能會導致你沒想到的錯誤發生。因此我們必須在不影響到現有的程式碼為前提進行擴充。
下面有一段範例:

```
var users = new List<UserModel>
{
    new UserModel{FirstName = "Johnny", LastName = "Wang"},
    new UserModel{FirstName = "Mary", LastName = "Cheng"},
    new UserModel {FirstName = "Jack", LastName = "Du"}
};

var employees = new List<EmployeeModel>();

var accounts = new Accounts();

foreach (var user in users)
{
    employees.Add(accounts.Create(user));
}

foreach (var employee in employees)
{
   Console.WriteLine($"{employee.FirstName} {employee.LastName} email address: {employee.Email}");
}

Console.WriteLine("Press any key to exit");

Console.ReadLine();
```
用到的類別:

```
public class UserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
```
```
public class EmployeeModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}
```
```
public class Accounts
{
    public EmployeeModel Create(UserModel userModel)
    {
        EmployeeModel result = new();

        result.FirstName = userModel.FirstName;

        result.LastName = userModel.LastName;

        result.Email = $"{userModel.FirstName}{userModel.LastName}@gmail.com";

        return result;
    }
}
```
今天客戶說，我想要新增一個flag，來判斷User是不是Manager。以直觀來說，會想要直接在<code>new UserModel{FirstName = "Johnny", LastName = "Wang"},</code>上面直接加一個<code>IsManager: false</code>的屬性來判斷，而UserModel也加上<code>public bool IsManager { 0get; set; } = false</code>以及在Account class中的Create()加一個判斷是不是Manager的程式。
那如果老闆又說，我要新增一個Super employee的flag，那是不是以上程式碼又要再改一次? 那麼是否能夠完全保證這些修改，對於程式運行是不影響的呢?
因此，如果想要符合OCP，我們可以這樣做:
- 建立一個UserModel的Interface並修改UserModel
```
public interface IUserModel
{
    string FirstName { get; set; }
    string LastName { get; set; }
    IAccounts Account { get; set; }
}
    
public class UserModel : IUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAccounts Account { get; set; } = new Accounts();
}
```
- 建立Accounts Interface
```
public interface IAccounts
{
    EmployeeModel Create(IUserModel userModel);
}
```
如此一來，所有的IUserModel都會有Create可以用。
執行的程式碼就會變成:
```
// 使用interface而不直接使用class
var users = new List<IUserModel>
{
    new UserModel{FirstName = "Johnny", LastName = "Wang"},
    new UserModel{FirstName = "Mary", LastName = "Cheng"},
    new UserModel {FirstName = "Jack", LastName = "Du"}
};

var employees = new List<EmployeeModel>();

foreach (var user in users)
{
    // 藉由user就可以呼叫到create
    employees.Add(user.Account.Create(user));
}

foreach (var employee in employees)
{
   Console.WriteLine($"{employee.FirstName} {employee.LastName} email address: {employee.Email}");
}

Console.WriteLine("Press any key to exit");

Console.ReadLine();
```
Ok，如果今天老闆說，我要一個Manager的標記，那我們就可以這樣做:
- 新增一個ManagerAccount class，並繼承IAccounts實作
```
public class ManagerAccounts : IAccounts
{
    public EmployeeModel Create(IUserModel userModel)
    {
        EmployeeModel result = new();

        result.FirstName = userModel.FirstName;

        result.LastName = userModel.LastName;

        result.Email = $"{userModel.FirstName}{userModel.LastName}@gmail.com";

        // 是否為管理者加在這裡
        result.IsManager = true;

        return result;
    }
}
```
- 新增一個Manager class，並繼承IUserModel並實作
```
public class Manager : IUserModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IAccounts Account { get; set; } = new ManagerAccounts();
}
```
最後的執行程式碼就會變成這樣:
```
var users = new List<IUserModel>
{
    // 想要什麼類型的使用者就自己加囉!
    new UserModel{FirstName = "Johnny", LastName = "Wang"},
    new Manager{FirstName = "Mary", LastName = "Cheng"},
    new UserModel {FirstName = "Jack", LastName = "Du"}
};

var employees = new List<EmployeeModel>();

foreach (var user in users)
{
    // 藉由user就可以呼叫到create
    employees.Add(user.Account.Create(user));
}

foreach (var employee in employees)
{
   Console.WriteLine($"{employee.FirstName} {employee.LastName} email address: {employee.Email}, IsManager? {employee.IsManager}");
}

Console.WriteLine("Press any key to exit");

Console.ReadLine();
```
如果今天老闆又說，我要加一個超級員工的標籤，這時候，只要再重複上述步驟，並在List裡面增加一筆資料就完成囉!

備註: 的確，如果要新增這些功能，UserModel勢必也要增加屬性，但這是否違反了OCP原則? 我想OCP應該主要還是專注於邏輯上的修改，我想如果只是對於model上增加屬性，這種微小的變動應該還是可以接受的。

## <a name="LSP">Liskov Substitution Principle</a>
> 定義: 子類別在繼承父類別時，必須遵循父類別的設計
    
什麼意思呢? 先看一下一段程式碼:
```
Manager manager = new Manager();

manager.FirstName = "Johnny";

manager.LastName = "Wang";

manager.CaculateSalary(4);

Employee employee = new Employee();

employee.FirstName = "David";

employee.LastName = "Lin";

employee.AssignManager(manager);

employee.CaculateSalary(2);

Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}\nSalary: {employee.Salary}");

Console.WriteLine("Press any key to exit");

Console.ReadLine();    
```
類別如下:
```
public class Employee
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Employee Manager { get; set; }

    public decimal Salary { get; set; }

    public virtual void AssignManager(Employee manager)
    {
        Manager = manager;
    }

    public virtual void CaculateSalary(int rank)
    {
        decimal baseSalary = 100;

        Salary = baseSalary + (rank * 2);

    }
}
```
```
public class Manager : Employee
{
    public override void CaculateSalary(int rank)
    {
        decimal baseSalary = 200;

        Salary = baseSalary + (rank * 2);
    }

    public void GeneratePerformanceReview()
    {
        Console.WriteLine("Performance report Generated.");
    }
}
```
```
public class CEO : Employee
{
    public override void CaculateSalary(int rank)
    {
        decimal baseSalary = 400;

        Salary = baseSalary + rank;
    }

    public override void AssignManager(Employee manager)
    {
        throw new InvalidOperationException("The CEO have no manager!");
    }

    public void GeneratePerformanceReview()
    {
        Console.WriteLine("Performance report Generated.");
    }

    public void FireSomeone(Employee employee)
    {
        Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} have been fired by CEO!");
    }
}
```
LSP的意思就是如果今天把

<code>Employee employee = new Employee();</code>
    
替換成
    
<code>Employee employee = new CEO();</code>
    
程式不會因為這樣而壞掉。很顯然的，以上這隻程式在執行到<code>employee.AssignManager(manager);</code>的時候，會因為CEO的方法而丟出一個Eception，所以它違反了LSP。
    
因此我們可以做以下的變動:
- 將所有員工都會用到的變數及功能提取出來做成Interface

```
public interface IEmployee
{
    string FirstName { get; set; }
    string LastName { get; set; }
    decimal Salary { get; set; }
    void CaculateSalary(int rank);
}
```
- 將管理者具有的功能提取出來變成Interface，此Interface也必須繼承IEmployee

```
public interface IManager : IEmployee
{
    void GeneratePerformanceReview();
}
```
- 將具有分配管理者的功能提取出來變成Interface，此Interface也必須繼承IEmployee

```
public interface IManaged : IEmployee
{
    IEmployee Manager { get; set; }

    void AssignManager(IEmployee manager);
}
```
- 創建一個基礎抽象類別，並繼承IEmployee

```
public abstract class BaseEmployee : IEmployee
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public decimal Salary { get; set; }

    public virtual void CaculateSalary(int rank)
    {
        decimal baseSalary = 100;

        Salary = baseSalary + (rank * 2);

    }
}
```
接下來就要開始修改類別了。

首先是Employee: 員工必須繼承基礎類別才能得到一些基本的資訊，同時也必須繼承IManaged才能被分派管理者
```
public class Employee : BaseEmployee, IManaged
{
    public IEmployee Manager { get; set; }

    public void AssignManager(IEmployee manager)
    {
        Manager = manager;
    }
}
```
接下來是Manager: 管理者可以被指定另一個管理者，同時也可以送出報告，因此要繼承Employee與IManager，不繼承IEmployee的原因是Employee已經繼承BaseEmployee，如果再繼承一次就要再重新實作裡面的內容。
```
public class Manager : Employee, IManager
{
    public override void CaculateSalary(int rank)
    {
        decimal baseSalary = 200;

        Salary = baseSalary + (rank * 2);
    }

    public void GeneratePerformanceReview()
    {
        Console.WriteLine("Performance report Generated.");
    }
}
```
最後是CEO: 因為CEO並不能被指定管理者，因此這邊要繼承的是BaseEmployee以及IManager。
    
```
public class CEO : BaseEmployee, IManager
{
    public override void CaculateSalary(int rank)
    {
        decimal baseSalary = 400;

        Salary = baseSalary + rank;
    }

    public void GeneratePerformanceReview()
    {
        Console.WriteLine("Performance report Generated.");
    }

    public void FireSomeone(Employee employee)
    {
        Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} have been fired by CEO!");
    }
}
```

所以因為各種層級繼承的東西不一樣，因此執行的程式碼會變的靈活而且不會出錯(因為出錯的時候會直接Compiler錯誤，而不是執行中錯誤)
```
IManager manager = new Manager();

manager.FirstName = "Johnny";

manager.LastName = "Wang";

manager.CaculateSalary(4);

BaseEmployee employee = new CEO();

employee.FirstName = "David";

employee.LastName = "Lin";

employee.CaculateSalary(2);

Console.WriteLine($"Name: {employee.FirstName} {employee.LastName}\nSalary: {employee.Salary}");

Console.WriteLine("Press any key to exit");

Console.ReadLine();
```
有關於override的原則:
- Precondition 先決條件
簡單的來說子類別在覆寫父類別的時候，必須遵循父類別既有的規則。
例如父類別傳入的參數必須大於10、小於50，則在子類別中不能超出此一範圍進行override，以免出現超出預期的錯誤。
- Postconditions 後置條件
指在執行一段代碼後必須成立的條件，例如父類別回傳的必須是int，子類別也必須回傳一樣的型別與變數，但是可以多指定其他的變數為這個結果。
- Invariants 不變條件
在程序執行過程或部分過程中，可始終被假定成立的條件，子類別也必須維持一致。
