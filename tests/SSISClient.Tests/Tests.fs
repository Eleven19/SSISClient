module SSISClient.Tests

open SSISClient
open NUnit.Framework

[<Test>]
let ``Package.execute does not fail`` () =
  let result = 
    Package.execute 
      <| Package.descriptor "SSISManagement-Examples" "EmptyParameterLessPackage.dtsx" 

  printfn "%i" result
  Assert.AreEqual(42,result)
