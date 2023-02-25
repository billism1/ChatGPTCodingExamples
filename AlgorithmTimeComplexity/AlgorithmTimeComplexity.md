> What is the time complexity of the following function:
```
long Sum3(int n)
{
    long sum = 0;
    for (int a = 1; a < n; a++)
    {
        for (int b = 1; b < n; b++)
        {
            for (int c = 1; c < n; c++)
            {
                sum += a * b * c;
            }
        }
    }
    return sum;
}
```

---

The time complexity of the function is O(n^3).

The function has three nested loops, each of which runs n-1 times. As a result, the total number of iterations is (n-1)^3. Within each iteration, the function performs a constant number of arithmetic operations (i.e., a multiplication and an addition). Therefore, the time complexity of the function is proportional to (n-1)^3, which can be simplified to O(n^3) since the highest order term dominates the complexity.

---

> That's correct. If we have tree nested loops from 1 to N, their complexity is cubic – O(N3).

---

Yes, that's correct. When we have three nested loops, each running from 1 to N, the time complexity would be O(N^3). The same logic applies to any number of nested loops, where each loop runs N times, resulting in a time complexity of O(N^k), where k is the number of nested loops.

---