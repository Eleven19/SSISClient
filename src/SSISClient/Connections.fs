module SSISClient.Connections
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

