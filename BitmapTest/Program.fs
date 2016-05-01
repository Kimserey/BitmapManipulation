module BitmapTest.Root

open System
open System.Drawing
open System.Drawing.Imaging

let redraw setAttributes (img: Image) =
    let newImg = new Bitmap(img.Width, img.Height)
    use g = Graphics.FromImage newImg
    g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, setAttributes <| new ImageAttributes())
    newImg

let grayscale: (Image -> Bitmap) =
    redraw
        (fun attrs ->
            attrs.SetColorMatrix(
                new ColorMatrix(
                    [| [|  0.3f;  0.3f;  0.3f;  0.f;  0.f |]
                       [| 0.59f; 0.59f; 0.59f;  0.f;  0.f |]
                       [| 0.11f; 0.11f; 0.11f;  0.f;  0.f |]
                       [|   0.f;   0.f;   0.f;  1.f;  0.f |]
                       [|   0.f;   0.f;   0.f;  0.f;  1.f |] |]))
            attrs)

let blackAndWhite: (Image -> Bitmap) =
    redraw
        (fun attrs ->
            attrs.SetColorMatrix(
                new ColorMatrix(
                    [| [|  1.5f;  1.5f;  1.5f;  0.f;  0.f |]
                       [|  1.5f;  1.5f;  1.5f;  0.f;  0.f |]
                       [|  1.5f;  1.5f;  1.5f;  0.f;  0.f |]
                       [|   0.f;   0.f;   0.f;  1.f;  0.f |]
                       [|  -1.f;  -1.f;  -1.f;  0.f;  1.f |] |]))
            attrs)

let invert: (Image -> Bitmap) =
    redraw
        (fun attrs ->
            attrs.SetColorMatrix(
                new ColorMatrix(
                    [| [|  -1.f;   0.f;  0.f;  0.f;  0.f |]
                       [|   0.f;  -1.f;  0.f;  0.f;  0.f |]
                       [|   0.f;   0.f; -1.f;  0.f;  0.f |]
                       [|   0.f;   0.f;  0.f;  1.f;  0.f |]
                       [|   1.f;   1.f;  1.f;  0.f;  1.f |] |]))
            attrs)


let threshold th =
    redraw (fun attrs -> attrs.SetThreshold th; attrs)

let loadBitmap filePath =
    Bitmap.FromFile filePath

let save filePath (image: Image) =
    image.Save filePath

[<EntryPoint>]
let main argv = 

    __SOURCE_DIRECTORY__ + "/small_rec.jpg"
    |> loadBitmap
    |> blackAndWhite 
    |> save "bnw.jpg"

    0
