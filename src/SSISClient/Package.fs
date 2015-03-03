namespace SSISClient

/// Documentation for my library
///
/// ## Example
///
///     let h = Catalog.hello 1
///     printfn "%d" h
///
[<RequireQualifiedAccess>]
module Package = 
 open System
 open FSharp.Data.Sql

  type Descriptor = {
    Name:string
    Folder:string}

  type ParameterDataType =
  | String
  | Boolean
  | Int32
  | Int64

  type ExecutionParameter = {
    Name:string
    Value:obj
    DataType: ParameterDataType}

  type ExecutionArgs = {  
    Parameters: Map<string,ExecutionParameter>
  }

  let descriptor folder name = {Name=name;Folder=folder}

  let DefaultExecutionParameters =
  [
    {Name="SYNCHRONISED"; Value=false; DataType=ParameterDataType.Boolean}
  ]

 let DefaultExecutionArgs = {
    Parameters = DefaultExecutionParameters |> List.map (fun p-> p.Name,p) |> Map.ofList}

 /// Returns 42
 ///
 /// ## Parameters
 ///  - `package` - PackageDescriptor
 let execute (package:Descriptor)= 
  SsisDb.Catalog.createExecution
