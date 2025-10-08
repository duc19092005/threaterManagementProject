namespace BussinessLogic.Result;

public class baseResultForCRUD
{
    public bool isSuccess { get; set; }
    
    public string message { get; set; }
    
    public baseResultForCRUD(bool status ,string message)
    {
        this.isSuccess = status;
        this.message = message;
    }

    public static baseResultForCRUD successStatus(string msg )
    {
        return new baseResultForCRUD(true, msg);
    }

    public static baseResultForCRUD failedStatus(string msg)
    {
        return new baseResultForCRUD(false, msg);
    }
}