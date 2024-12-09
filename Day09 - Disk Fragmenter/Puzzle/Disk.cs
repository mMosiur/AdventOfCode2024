namespace AdventOfCode.Year2024.Day09.Puzzle;

internal sealed class Disk
{
    private const short FreeBlock = -1;

    private readonly short[] _disk;

    private Disk(short[] disk)
    {
        _disk = disk;
    }

    public static Disk CreateFromDiskMap(DiskMap diskMap)
    {
        int totalSize = diskMap.BlockLayout.Sum();
        short[] disk = new short[totalSize];

        int blockPosition = 0;
        for (int i = 0; i < diskMap.BlockLayout.Count; i++)
        {
            bool isFreeSector = i % 2 == 1;
            short fileId = Convert.ToInt16(isFreeSector ? FreeBlock : i / 2);
            int blockSize = diskMap[i];
            for (int j = 0; j < blockSize; j++)
            {
                disk[blockPosition + j] = fileId;
            }

            blockPosition += blockSize;
        }

        return new(disk);
    }

    public void Compress()
    {
        int leftIndex = 0;
        int rightIndex = _disk.Length - 1;

        while (leftIndex < rightIndex)
        {
            while (_disk[leftIndex] != -1 && leftIndex < rightIndex)
            {
                leftIndex++;
            }

            while (_disk[rightIndex] == -1 && leftIndex < rightIndex)
            {
                rightIndex--;
            }

            _disk[leftIndex] = _disk[rightIndex];
            _disk[rightIndex] = -1;
        }
    }

    public long CalculateChecksum()
    {
        long checksum = 0;
        for (int i = 0; i < _disk.Length; i++)
        {
            if (_disk[i] == FreeBlock) continue;
            checksum += i * _disk[i];
        }

        return checksum;
    }
}
