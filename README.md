# Write C# Unit Tests Alongside Your Code

This is a sample project demonstrating how to configure dotnet core C# project to support unit tests side-by-side with code.

* In Release mode unit tests are excluded and are not compiled into final assembly.
  * Project is configured to exlude *.test.cs files in Release build
* In Debug mode test are compiled in and are available
  * Run tests using standard `dotnet test`
  * Run application using standard `dotnet run`

Unit tests may be organized as desired, in this sample they are kept locally close to the functionality being tested. For example Unit tests for Program.cs are located in Program.test.cs

## Steps

Amend .csproj project file as follows to enable side-by-side unit tests.

1. (optional) Create new project
    ```Shell
    mkdir cstest
    cd cstest
    dotnet new console
    ```

1. (optional) Add xunit to the project
    ```Shell
    dotnet new xuint --force
    ```

1. Add condition to ItemGroup which is referencing unit test packages to only have effect in Debug build.
    ```XML
    <ItemGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.7.0" />
        <PackageReference Include="xunit" Version="2.3.1" />
        <PackageReference Include="xunit.runner.visualstudio" Version="2.3.1" />
        <DotNetCliToolReference Include="dotnet-xunit" Version="2.3.1" />
    </ItemGroup>
    ```

1. Add following three lines to exclude *.test.cs files from non-Debug builds.
    ```XML
    <PropertyGroup Condition=" '$(Configuration)|$(Platform)' != 'Debug|AnyCPU' ">
        <DefaultItemExcludes>**\*.test.cs</DefaultItemExcludes>
    </PropertyGroup>
    ```

1. Add following three lines to instruct compiler where to locate `main` in Debug build. Since both our project and XUnit define `main` compiler requires help disambiguating.
    ```XML
    <PropertyGroup Condition=" '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ">
        <StartupObject>cstest.Program</StartupObject>
    </PropertyGroup>
    ```
