using System.Drawing;

namespace AdventOfCode.Year2024.Day14.Puzzle;

internal sealed class BathroomImager(Bathroom bathroom, string folderName)
{
    private readonly Bathroom _bathroom = bathroom;
    private readonly string _folderName = folderName;

    public void SimulateSecondsWithImages(int seconds)
    {
        PrepareFolder();
        for (int i = 1; i <= seconds; i++)
        {
            _bathroom.SimulateSecond();
            int imageIndex = _bathroom.SecondsPassed;
            GenerateImage($"bathroom_{imageIndex}.bmp");
        }
    }

    private void PrepareFolder()
    {
        Directory.CreateDirectory(_folderName);
        // delete all files in the folder
        foreach (var file in Directory.EnumerateFiles(_folderName))
        {
            File.Delete(file);
        }
    }


#pragma warning disable CA1416 // Temporary solution that works on Windows, later fixes should avoid image file generation
    private void GenerateImage(string filename)
    {
        using Bitmap image = new(_bathroom.Width, _bathroom.Height);
        foreach (var robot in _bathroom.Robots)
        {
            image.SetPixel(robot.Position.X, robot.Position.Y, Color.White);
        }
        image.Save($"{_folderName}/{filename}");
    }
#pragma warning restore CA1416
}
