module Tests

open Xunit
open FsCheck.Xunit
open Shuffle
open System.Linq
open FsCheck 
open System


type NonSparseListGenerator() = 
    static member GetLists () = 
        let isNotSparse source = 
            let distinctElementsLength = 
                source
                |> List.distinct 
                |> List.length 
            (distinctElementsLength > 5) && (source |> List.length < (distinctElementsLength + 2))
        Arb.Default.FsList()
        |> Arb.filter isNotSparse

let toStringHash source = 
    source 
    |> Seq.map (fun x -> x.ToString()) 
    |> Seq.sort
    |> String.concat ","

[<Property(Verbose=true)>]
let ``shuffled result contains the same elements as the source`` (source: int list) = 
    //printfn "%A" source 
    let result = source |> Seq.shuffle
    (source |> toStringHash) = (result |> toStringHash)
 
[<Property(Verbose=false, Arbitrary = [| typeof<NonSparseListGenerator> |] )>]
let ``shuffled result differs from source`` (source: char list) = 
   //source |> List.distinct |> List.length > 3) ==> lazy

   let result = source |> Seq.shuffle
   not (Enumerable.SequenceEqual(source, result))

[<Property(Verbose=true, Arbitrary = [| typeof<NonSparseListGenerator> |] )>]
let ``shuffle returns different results for same input`` (source: int list) = 
    //(source |> List.distinct |> List.length > 3) ==> lazy
    let shuffled = source |> Seq.shuffle
    let anotherShuffled = source |> Seq.shuffle
    let result = not (Enumerable.SequenceEqual(shuffled, anotherShuffled))
    if (not result) then 
        printfn "%A, %A, %A" source shuffled anotherShuffled
    
    result 
