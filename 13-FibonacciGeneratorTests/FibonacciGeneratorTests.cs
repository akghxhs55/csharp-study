using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FibonacciGenerator;

[TestFixture]
public class FibbonacciGeneratorTests
{
    [TestCase(-1)]
    [TestCase(-10)]
    public void FibonacciGenerator_ShallThrowArgumentException_WhenNIsNegative(int n)
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));
    }

    [TestCase(47)]
    [TestCase(100)]
    public void FibonacciGenerator_ShallThrowArgumentException_WhenNIsGreaterThan46(int n)
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(n));
    }

    [TestCaseSource(nameof(FibonacciGeneralTestCases))]
    public void FibonacciGenerator_ShallReturnExpectedResult_WhenNIsValid(int n, IEnumerable<int> expected)
    {
        var result = Fibonacci.Generate(n);
        CollectionAssert.AreEqual(expected, result);
    }

    private static IEnumerable<object> FibonacciGeneralTestCases()
    {
        int[] fibonacciNumbers = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733, 1134903170, 1836311903];

        yield return new object[] { 0, fibonacciNumbers[0..0] };
        yield return new object[] { 1, fibonacciNumbers[0..1] };
        yield return new object[] { 2, fibonacciNumbers[0..2] };
        yield return new object[] { 3, fibonacciNumbers[0..3] };
        yield return new object[] { 5, fibonacciNumbers[0..5] };
        yield return new object[] { 10, fibonacciNumbers[0..10] };
        yield return new object[] { 20, fibonacciNumbers[0..20] };
        yield return new object[] { 30, fibonacciNumbers[0..30] };
        yield return new object[] { 40, fibonacciNumbers[0..40] };
        yield return new object[] { 45, fibonacciNumbers[0..45] };
        yield return new object[] { 46, fibonacciNumbers[0..46] };
    }
}
