using System.Net;
using System.Web;

namespace backend.helper;

public class generateVNPAYURLHelper
{
    // DI
    private readonly IConfiguration _configuration;
    public generateVNPAYURLHelper(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    public string generateVnpayURL
        (string orderId , string IPAddress ,
            string orderInfo ,
            double amount
            )
    {

        var VnpaySandboxURL = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";

        // Các Params 

        Dictionary<string, string> VnpayParams = new Dictionary<string, string>()
        {
            {"vnp_Version" , "2.1.0" } ,
            {"vnp_Command" , "pay"} ,
            {"vnp_TmnCode" , _configuration["Vnpay:TmnCode"]} ,
            {"vnp_Amount" , "100000"} ,
            {"vnp_CreateDate" , DateTime.Now.ToString("yyyyMMddHHmmss")} ,
            {"vnp_CurrCode" , "VND"} ,
            {"vnp_IpAddr" , "1"} ,
            {"vnp_Locale" , "vn"} ,
            {"vnp_OrderInfo" , WebUtility.UrlEncode("123")} ,
            {"vnp_OrderType" , "other"} ,
            {"vnp_ReturnUrl" , WebUtility.UrlEncode("http://localhost:5000") } ,
            {"vnp_TxnRef" , "123" }
        };
        

        var generateParamsURL
            = String.Join("&" ,VnpayParams.OrderBy(x => x.Key).Select(x => $"{x.Key}={x.Value}"));
        var hashConfig = _configuration
            ["VNPAY:Hash"];
            
        var hashParams = HMACSHA512Helper.SHA512_ComputeHash(generateParamsURL, hashConfig);
        
        string convertToVNPAYURL
            = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html?" +
              generateParamsURL + "&" + "vnp_SecureHash=" + hashParams;

        return convertToVNPAYURL;
    }
}