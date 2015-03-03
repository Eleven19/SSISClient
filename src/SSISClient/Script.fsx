// Learn more about F# at http://fsharp.org. See the 'F# Tutorial' project
// for more guidance on F# programming.

#r "FSharp.Data.SqlProvider.dll"
#load "Package.fs"
open SSISClient

let num = Library.hello 42
printfn "%i" num
