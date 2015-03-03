module SSISClient.Tests

open SSISClient
open NUnit.Framework

[<Test>]
let ``Package.exec does not fail`` () =
  let result = 
    Package.exec
      <| Package.descriptor "SSISManagement-Examples" "EmptyParameterLessPackage.dtsx" 

  printfn "%i" result
  Assert.AreEqual(42,result)
