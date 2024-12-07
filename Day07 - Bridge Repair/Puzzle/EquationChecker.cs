using AdventOfCode.Year2024.Day07.Puzzle.Operations;

namespace AdventOfCode.Year2024.Day07.Puzzle;

internal sealed class EquationChecker
{
    private readonly IOperation[] _availableOperations;

    public EquationChecker(params IEnumerable<IOperation> availableOperations)
    {
        _availableOperations = availableOperations.ToArray();
        if (_availableOperations.Length == 0)
        {
            throw new ArgumentException("At least one operation must be provided", nameof(availableOperations));
        }
    }

    public bool IsEquationPossiblyTrue(Equation equation)
    {
        return IsEquationPossiblyTrue(equation.Result, equation.Numbers.AsSpan());
    }

    private bool IsEquationPossiblyTrue(long result, ReadOnlySpan<long> numbers)
    {
        if (numbers.Length == 1)
        {
            return result == numbers[0];
        }

        if (numbers[0] > result)
        {
            return false;
        }

        // Copy all elements except the first two leaving first space empty
        Span<long> numbersCopy = stackalloc long[numbers.Length - 1];
        numbers[2..].CopyTo(numbersCopy[1..]);

        foreach (var operation in _availableOperations.AsSpan())
        {
            numbersCopy[0] = operation.Execute(numbers[0], numbers[1]);

            if (IsEquationPossiblyTrue(result, numbersCopy))
            {
                return true;
            }
        }

        return false;
    }
}
