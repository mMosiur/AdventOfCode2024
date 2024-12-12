namespace AdventOfCode.Year2024.Day12.Puzzle.GardenBuilders;

internal sealed class GardenPlotBuilder(PlantType plotPlantType)
{
    public PlantType PlotPlantType { get; } = plotPlantType;
    public GardenRegionBuilder? RegionBuilder { get; set; }
}
