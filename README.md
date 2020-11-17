# app_awsDotNetCoreShoppingCart
## AWS Lambda Function Application

With this application I have built a simple shopping basket, each item consisting only of a primitive string value.

The basket can be modified using the individual request inputs. The user interface and application state are React driven with data modification being processed via .NET Core running on AWS Lambda.

Whilst this functionality could be achieved with JavaScript alone, I wanted to explore AWS Lambda and .NET Core. So the decision was made to go serverless compute for data modifications.

- Portfolio Repository (https://github.com/fsereno/portfolio//tree/master/app/app_awsDotNetCoreShoppingCart)

### Project commands ###

Build solution
```
    dotnet build project
```

Execute unit tests
```
    dotnet test test
```
