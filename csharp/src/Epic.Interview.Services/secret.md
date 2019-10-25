## Configuration

```commandline
 dotnet user-secrets --id server set "ConnectionStrings:default" "Database=x;Username=x;Password=x;Host=x" 
 dotnet user-secrets --id server set "AppSettings:secret" "secret key"
```
 
 ### Environment setup
 export ConnectionStrings__default=Database=x;Username=x;Password=x;Host=x
 export AppSettings__secret='Secret key'
 
