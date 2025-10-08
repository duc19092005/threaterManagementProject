using BussinessLogic.Enums;

namespace BussinessLogic.Result;

public class baseResultForCRUD
{
    public bool isSuccess { get; set; }
    
    public string message { get; set; }
    
    public crudStatus  CrudStatus { get; set; }
        
    public baseResultForCRUD(bool status ,string message , crudStatus CRUDstatus)
    {
        this.isSuccess = status;
        this.message = message;
        this.CrudStatus = CRUDstatus;
    }

    public static baseResultForCRUD successStatus(string msg , crudStatus CRUDstatus)
    {
        return new baseResultForCRUD(true, msg , CRUDstatus);
    }

    public static baseResultForCRUD failedStatus(string msg , crudStatus CRUDstatus)
    {
        return new baseResultForCRUD(false, msg , CRUDstatus);
    }
}