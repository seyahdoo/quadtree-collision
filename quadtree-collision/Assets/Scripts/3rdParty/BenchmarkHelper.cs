using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public static class BenchmarkHelper
{

    public static long Benchmark(Action act, int iterations)
    {
        GC.Collect();
        act.Invoke(); // run once outside of loop to avoid initialization costs
        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < iterations; i++)
        {
            act.Invoke();
        }
        sw.Stop();
        return sw.ElapsedMilliseconds / iterations;
    }

}
