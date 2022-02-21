using OpenClosedPrincipleLibrary;

var users = new List<IUserModel>
{
    // 想要什麼類型的使用者就自己加囉!
    new UserModel{FirstName = "Johnny", LastName = "Wang"},
    new ManagerModel{FirstName = "Mary", LastName = "Cheng"},
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
   Console.WriteLine($"{employee.FirstName}.{employee.LastName} email address: {employee.Email}, IsManager? {employee.IsManager}");
}

Console.WriteLine("Press any key to exit");

Console.ReadLine();