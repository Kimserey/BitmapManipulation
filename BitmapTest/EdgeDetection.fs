module BitmapTest.EdgeDetection

open ImageProcessor
open ImageProcessor.Imaging.Filters.EdgeDetection

let makeFactory() =
    (new ImageFactory())
        .Load(__SOURCE_DIRECTORY__ + "/small_rec.jpg")

let edgeDetection (factory: ImageFactory) =
    factory
        .Reset()
        .DetectEdges(new Laplacian3X3EdgeFilter())
        .Image
        .Save("laplacian3x3.jpg")
        
    factory
        .Reset()
        .DetectEdges(new KayyaliEdgeFilter())
        .Image
        .Save("kayyali.jpg")

    factory
        .Reset()
        .DetectEdges(new KirschEdgeFilter())
        .Image
        .Save("kirsch.jpg")

    factory
        .Reset()
        .DetectEdges(new PrewittEdgeFilter())
        .Image
        .Save("prewitt.jpg")

    factory
        .Reset()
        .DetectEdges(new RobertsCrossEdgeFilter())
        .Image
        .Save("robertscross.jpg")

    factory
        .Reset()
        .DetectEdges(new ScharrEdgeFilter())
        .Image
        .Save("scharr.jpg")

    factory
        .Reset()
        .DetectEdges(new SobelEdgeFilter())
        .Image
        .Save("sobel.jpg")
    
    factory
        .Reset()
        .DetectEdges(new Laplacian5X5EdgeFilter())
        .Image
        .Save("laplacian5x5.jpg")
    
    factory
        .Reset()
        .DetectEdges(new LaplacianOfGaussianEdgeFilter())
        .Image
        .Save("laplacianGauss.jpg")
    