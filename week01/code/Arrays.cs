using System;
using System.Collections.Generic;

public static class Arrays
{
    public static double[] MultiplesOf(double number, int length)
    {
        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    public static void RotateListRight(List<int> data, int amount)
    {
        int splitIndex = data.Count - amount;

        List<int> rotatedPart = data.GetRange(splitIndex, amount);
        data.RemoveRange(splitIndex, amount);
        data.InsertRange(0, rotatedPart);
    }
}