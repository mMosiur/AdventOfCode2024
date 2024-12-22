using SkiaSharp;

namespace AdventOfCode.Year2024.Day14.Puzzle;

internal sealed class BathroomImager(Bathroom bathroom, string folderName)
{
    private readonly Bathroom _bathroom = bathroom;
    private readonly string _folderName = folderName;

    public void PrepareFolder()
    {
        if (Directory.Exists(_folderName))
        {
            Directory.Delete(_folderName, recursive: true);
        }

        Directory.CreateDirectory(_folderName);
    }

    public void GenerateImage(string filenameWithoutExtension)
    {
        using var image = new SKBitmap(_bathroom.Width, _bathroom.Height);
        using (var paint = new SKPaint())
        {
            paint.Color = SKColors.White;
            paint.BlendMode = SKBlendMode.Src;
            using (SKCanvas canvas = new(image))
            {
                foreach (var robot in _bathroom.Robots)
                {
                    canvas.DrawPoint(robot.Position.X, robot.Position.Y, paint);
                }
            }
        }

        using var stream = File.OpenWrite($"{_folderName}/{filenameWithoutExtension}.bmp");
        image.Encode(stream, SKEncodedImageFormat.Bmp, 100);
    }
}
