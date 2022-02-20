using SignalResponsibilityPrincipleDemo;

ShowMessage.ShowWelcomeMessage();

var user = UserDataCapture.GetUser();

bool isValid = ValidateUserName.Validate(user);

if (!isValid) {

    ShowMessage.ShowEndMessage();

    return;
}

UserGenerate.CreateAccount(user);

ShowMessage.ShowEndMessage();
