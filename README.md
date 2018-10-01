# F# + React Web Application Template Introduction

## Prerequisites
1. .NET Core 2.1 SDK >= 2.1.400, download: https://dot.net
2. nodejs >= 8.11.0, download: https://nodejs.org

## Get started
```
git clone https://github.com/SYSU-MSC-Studio/ReactFS.git
cd ./ReactFS
dotnet restore

cd ./ClientApp
npm install

cd ..
dotnet run
```

## Add F# source files
You need to refer the source file you added in ReactFS.fsproj  
Example:  
If you add Example.fs in Example folder, you need to add the line below in ItemGroup node:
```xml
<Compile Include="Example/Example.fs"></Compile>
```
And the order is important, if A.fs refers something decleared in B.fs, B.fs should be placed above A.fs, otherwise it will fail to build

## Build
```
dotnet build [-r system] [-c runtime]
```
> system: win-x64, linux-x64, osx-x64...... default value: your current system
>
> runtime: Release, Debug default value: Debug

## Run
#### Manually configure and run
1. Set development environment
    ```
    Windows Powershell: 
    $env:ASPNETCORE_ENVIRONMENT = 'Development'

    Windows Command Prompt: 
    set ASPNETCORE_ENVIRONMENT=Development

    Linux Bash: export ASPNETCORE_ENVIRONMENT=Development
    ```

2. Run
    ```
    dotnet run
    ```

#### Automatically configure and run
> If you use Visual Studio, you can open ReactFS.sln and press F5 directly to run this web application automatically

## Publish
```
dotnet publish [-r system] [-c runtime]
```
> system: win-x64, linux-x64, osx-x64...... default value: your current system
>
> runtime: Release, Debug default value: Debug
