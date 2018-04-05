mkdir %1\src\shuffle
mkdir %1\tests 
cd %1\src\shuffle
dotnet new console -lang F#
cd ..\..\..\%1\tests
dotnet new xunit -lang F# 
dotnet add package FsCheck
dotnet add package FsCheck.Xunit
dotnet add reference ..\src\shuffle\shuffle.fsproj
cd ..
dotnet new sln 
dotnet sln add src\shuffle\shuffle.fsproj
dotnet sln add tests\tests.fsproj

dotnet restore
dotnet build  