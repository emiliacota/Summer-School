// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


//eroare de exemplu 
int error = 0;
string captureType = "capt";
Console.WriteLine($"Error{error}");
Console.WriteLine($"Variable 'captureType' is {captureType} and should be of typecapstv, captfail or captnote");

//codul 1
/*
 if (deviceState.Trim().ToLower() == "ready" ||
    deviceState.Trim().ToLower() == "busy" ||
    deviceState.Trim().ToLower() == "error")
{
    // Device state is valid
}
else
{
    TheExec.Datalog.WriteComment("Variable 'deviceState' must be 'ready', 'busy' or 'error'");
    return tlResult_Module.TL_ERROR;
}*/

int error1 = 0;
string deviceState = "device";
Console.WriteLine($"Error {error1}");
Console.WriteLine($"Variable 'deviceState' is {deviceState} and should be of ready, busy or error");

//codul 2
/*
 * if (userRole.Trim().ToLower() == "admin" ||
    userRole.Trim().ToLower() == "operator" ||
    userRole.Trim().ToLower() == "viewer")
{
    // Role is valid
}
else
{
    TheExec.Datalog.WriteComment("Variable 'userRole' must be 'admin', 'operator' or 'viewer'");
    return tlResult_Module.TL_ERROR;
}
 */

int error2 = 0;
string userRole = "user";
Console.WriteLine($"Error {error2}");
Console.WriteLine($"Variable 'userRole' is {userRole} and should be of admin, operator or viewer");

//cod 3
/*
 * if (testMode.Trim().ToLower() == "normal" ||
    testMode.Trim().ToLower() == "debug" ||
    testMode.Trim().ToLower() == "safe")
{
    // Do nothing
}
else
{
    TheExec.Datalog.WriteComment("Variable 'testMode' must be 'normal', 'debug' or 'safe'");
    return tlResult_Module.TL_ERROR;
}
 */
int error3 = 0;
string testMode = "test";
Console.WriteLine($"Error {error3}");
Console.WriteLine($"Variable 'testMode' is {testMode} and should be of normal, debug or safe");


