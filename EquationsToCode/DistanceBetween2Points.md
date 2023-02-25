> What is the equation to find the distance between 2 points on a 2D plane?

---

The equation to find the distance between two points (x1, y1) and (x2, y2) in a 2D plane is given by the distance formula:

distance = √\[(x2 - x1)² + (y2 - y1)²\]

In this formula, (x1, y1) and (x2, y2) are the coordinates of the two points and the symbol √ represents the square root operation.

The distance formula is derived from the Pythagorean theorem, which is a fundamental principle in geometry. It states that in a right triangle, the square of the length of the hypotenuse (the side opposite the right angle) is equal to the sum of the squares of the lengths of the other two sides. By applying this theorem to the two sides of a triangle formed by the two points and the horizontal axis, we can derive the distance formula.

---

> Thanks. Can you wrap that in a C# method for me?

---

Sure! Here's an example C# method that calculates the distance between two points:

csharp

```csharp
using System;

public static double DistanceBetweenPoints(double x1, double y1, double x2, double y2)
{
    double deltaX = x2 - x1;
    double deltaY = y2 - y1;
    double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
    return distance;
}
```

This method takes four double arguments, which represent the x and y coordinates of the two points on the 2D plane. It uses the distance formula to calculate the distance between the two points and returns the result as a double value.

You can call this method like this:

csharp

```csharp
double distance = DistanceBetweenPoints(1.0, 2.0, 4.0, 6.0);
Console.WriteLine("Distance between points: " + distance);
```

This will output the following:

sql

```sql
Distance between points: 5
```

Note that you'll need to include the `System` namespace in your code to use the `Math` class.

---