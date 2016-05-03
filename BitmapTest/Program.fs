module BitmapTest.Root

open System
open FredsImageMagickScripts
open ImageMagick
open Tesseract

[<EntryPoint>]
let main argv = 
    use img = new MagickImage(__SOURCE_DIRECTORY__ + "/original.jpg")
    let cleaner = TextCleanerScript()
    cleaner.FilterOffset <- new Percentage(9.1)
    cleaner.Trim <- true
    cleaner.Execute(img).Write("temp.jpg")

    use engine = new TesseractEngine(__SOURCE_DIRECTORY__ + "/tessdata", "eng")
    use img = Pix.LoadFromFile("temp.jpg")
    use page = engine.Process img

    printfn "%s" (page.GetText())
    printfn "Confidence: %.4f" (page.GetMeanConfidence())

    Console.ReadKey() |> ignore
    0
