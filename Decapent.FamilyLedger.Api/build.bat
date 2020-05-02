dotnet restore src/Decapent.FamilyLedger.Api
dotnet build src/Decapent.FamilyLedger.Api

dotnet restore tests/Decapent.FamilyLedger.Api.Tests
dotnet build tests/Decapent.FamilyLedger.Api.Tests
dotnet test tests/Decapent.FamilyLedger.Api.Tests
