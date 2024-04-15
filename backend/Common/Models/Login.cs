namespace backend.Common.Models;

public class UserLoginRequest
{
    public string phoneNumber { get; set; }
}
public class UserLoginResponse
{
    public bool success { get; set; }
    public string message { get; set; }
    public string phoneNumber { get; set; }
}