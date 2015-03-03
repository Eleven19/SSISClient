namespace SSISClient

module SsisDb =
  module Catalog =
    let createExecution = int64 5

module DataAccess =
  open System
  open FSharp.Data
  open FSharp.Data.Sql
  open System.Data.Linq
  open Microsoft.FSharp.Data.TypeProviders
  open Microsoft.FSharp.Linq

  [<Literal>]
  let private SsisDbConnectionString = "Server=localhost; Database=SSISDB; Trusted_Connection=True;Asynchronous Processing=True;Application Name=SSISClient;"

  [<Literal>]
  let ConnectionName = "name=SSISDB"

  //type SSISDB = SqlDataProvider<connStr,Common.DatabaseProviderTypes.MSSQLSERVER,UseOptionTypes=true>     
  //type SSISDB = SqlDataConnection<SsisDbConnectionString>

  (*
  let getContext connectionString = 
    match connectionString with
    | ""
    | null -> SSISDB.GetDataContext()
    | conStr -> SSISDB.GetDataContext connStr
  *)

  (*
  let execPackage connectionString name =
    let proc = SSISDB.catalog.create_folder


    //let ctx = getContext connectionString
    ()
  *)