module LearnFSharp.RomanNumerals
open System
open System.Text

let raw_mappings =
    [("I", 1); ("IV", 4); ("V", 5); ("IX", 9); ("X", 10)
     ("XL", 40); ("L", 50); ("XC", 90); ("C", 100); ("CD", 400)
     ("D", 500); ("CM", 900); ("M", 1000)]
let numerals = List.sortByDescending snd raw_mappings

let repeat num f =
    for _ in 1 .. num do
        f()

let to_roman number =
    let sb = StringBuilder()
    let rec convert num numerals =
        match numerals with
        | [] -> ()
        | (letter: String, value) :: tail ->
           if num = 0 then () else
           let count = num / value
           let remainder = num % value
           repeat count (fun () -> sb.Append(letter) |> ignore)
           convert remainder tail
    
    convert number numerals
    string sb
        
let solution(num: int): String =
    to_roman num