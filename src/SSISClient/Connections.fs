module SSISClient.Connections
open System
open System.Data
open System.Data.SqlClient
open Chessie.ErrorHandling

type ConnectionName = 
| ConnectionName of string
  member this.Value =
    match this with  | ConnectionName name -> name

  override this.ToString() = this.Value

/// Active recognizer to convert a connection name into a string
let (|ConnectionName|) (ConnectionName.ConnectionName name) = name

/// Function to convert a string into a connection name
let ConnectionName name = ConnectionName.ConnectionName name

type ConnectionString = 
| ConnectionString of string
  member this.Value =
    match this with  | ConnectionString connectionString -> connectionString

  override this.ToString() = this.Value

/// Active recognizer to convert a connection string into a string
let (|ConnectionString|) (ConnectionString.ConnectionString connectionString) = connectionString

/// Function to convert a string into a connection string
let ConnectionString connectionString = ConnectionString.ConnectionString connectionString

let (|ConnectionString|ConnectionName|) (input:string) =
  if input.Contains("=")
    then ConnectionString input
    else ConnectionName input

type ConnectionFactory = ConnectionString -> IDbConnection
type ConnectionNameResolver = ConnectionName -> ConnectionString
type ConnectionProvider = unit -> IDbConnection

let createDbConnection (connectionString:ConnectionString) = new SqlConnection(connectionString.Value):>IDbConnection
let getConnectionString (connectionName:ConnectionName) =
   let setting = Configuration.ConfigurationManager.ConnectionStrings.[connectionName.Value]
   setting.ConnectionString |> ConnectionString

type SsisConnection(connection:IDbConnection) =  
  new(connectionString, ?connectionFactory:ConnectionFactory)=
    let connectionFactoryResolved = defaultArg connectionFactory createDbConnection
    SsisConnection(connectionFactoryResolved connectionString)
  
  new(connectionName, ?connectionNameResolver:ConnectionNameResolver)=
    let connectionNameResolverResolved = defaultArg connectionNameResolver getConnectionString
    SsisConnection(connectionNameResolverResolved connectionName)

  new(connectionStringOrName, ?connectionNameResolver:ConnectionNameResolver, ?connectionFactory:ConnectionFactory) =
    let connectionNameResolverResolved = defaultArg connectionNameResolver getConnectionString
    let connectionFactoryResolved = defaultArg connectionFactory createDbConnection
    match connectionStringOrName with
    | ConnectionString cs -> SsisConnection((ConnectionString cs), connectionFactoryResolved)
    | ConnectionName name -> SsisConnection((ConnectionName name), connectionNameResolverResolved)
  member this.Connection = connection

let createConnection (connectionStringOrName:string) = SsisConnection(connectionStringOrName)
