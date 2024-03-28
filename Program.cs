using System;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearRegression;

class Program
{
    static void Main()
    {
        // Исходные данные
        double[] xValues = { 1, 2, 3, 4, 5 };
        double[] yValues = { 1, 4, 9, 16, 25 };

        // Степень полинома
        int degree = 2;

        // Преобразование входных данных в матрицу
        var vandermondeMatrix = CreateVandermondeMatrix(xValues, degree);

        // Вычисление коэффициентов полиномиальной регрессии
        var coefficients = MultipleRegression.NormalEquations(vandermondeMatrix, Vector<double>.Build.Dense(yValues));

        // Вывод коэффициентов
        Console.WriteLine("Коэффициенты полиномиальной регрессии:");
        for (int i = 0; i <= degree; i++)
        {
            Console.WriteLine($"b{i} = {coefficients[i]}");
        }
    }

    static Matrix<double> CreateVandermondeMatrix(double[] xValues, int degree)
    {
        var rows = xValues.Length;
        var matrix = Matrix<double>.Build.Dense(rows, degree + 1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j <= degree; j++)
            {
                matrix[i, j] = Math.Pow(xValues[i], j);
            }
        }
        return matrix;
    }
}
