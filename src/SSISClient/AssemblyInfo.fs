namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("SSISClient")>]
[<assembly: AssemblyProductAttribute("SSISClient")>]
[<assembly: AssemblyDescriptionAttribute("A client library for interacting with SQL Server Integration Services")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
