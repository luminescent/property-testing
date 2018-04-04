namespace Shuffle 

open System
open System.Linq 

module Seq = 

    let shuffle source = 
        let tagElements source = 
            source 
            |> Seq.map (fun x -> (Guid.NewGuid().ToString(), x))

        source
        |> tagElements
        |> Seq.sortBy fst
        |> Seq.map snd 



