namespace Decapent.FamilyLedger.Api

module HttpHandlers =

    open Microsoft.AspNetCore.Http
    open FSharp.Control.Tasks.V2.ContextInsensitive
    open Giraffe
    open Decapent.FamilyLedger.Api.Models

    let handleGetHello =
        fun (next : HttpFunc) (ctx : HttpContext) ->
            task {
                let response = {
                    Text = "Hello world, from Giraffe!"
                }
                return! json response next ctx
            }