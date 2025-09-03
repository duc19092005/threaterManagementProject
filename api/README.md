Hướng dẫn sử dụng trước tiên thêm vào file appsettings.Development.json ở đường dẫn backend/backend sau đó thêm file config như sau 

``` json

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*" ,
  "MSSQL" : {
    "connectString" : "Your_ConnectString"
  } ,
  "Cloudinary" : {
    "apiKey" : "Your_API_Key",
    "apiSecret" : "Your_API_Secrect"
  } ,
  "OAuth2" : {
    "clientSecret" : "Ypur_Client_Secrect" ,
    "clientId" : "Your_ClientID"
  },
  "Vnpay" : {
    "tmnCode" : "Your_Tmncode" ,
    "hashSecret" : "Your_Hash"
  } ,
  "Jwt" : {
    "secretKey" : "Your_JWT_SecrectKey" ,
    "aud" : "" ,
    "iss" : ""
  }
}
```

Sau khi add bạn chạy thêm lệnh

``` bash
dotnet restore

&&

dotnet build

```

Nếu muốn Update Database thì chạy lệnh LƯU Ý : ĐẢM BẢO ĐÃ CHẠY LỆNH Ở TRÊN THÀNH CÔNG

``` bash

dotnet ef database update

```

