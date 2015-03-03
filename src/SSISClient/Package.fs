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
 open SSISClient.Connections

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
    ConnectionProvider: ConnectionProvider    
    Parameters: Map<string,ExecutionParameter>
  }

  let descriptor folder name = {Name=name;Folder=folder}

  let DefaultExecutionParameters =
  [
    {Name="SYNCHRONISED"; Value=false; DataType=ParameterDataType.Boolean}
  ]

 let DefaultExecutionArgs = {
    ConnectionProvider = (fun ()-> "SSISDB"|> ConnectionName |> getConnectionString |>createDbConnection)
    Parameters = DefaultExecutionParameters |> List.map (fun p-> p.Name,p) |> Map.ofList}

 /// Returns 42
 ///
 /// ## Parameters
 ///  - `package` - PackageDescriptor
 let execute (package:Descriptor) (args:ExecutionArgs)= 
  let ssisConnection =  SsisConnection(args.ConnectionProvider())
  SsisDb.Catalog.createExecution ssisConnection
 
 let exec (package:Descriptor) = execute package DefaultExecutionArgs 
