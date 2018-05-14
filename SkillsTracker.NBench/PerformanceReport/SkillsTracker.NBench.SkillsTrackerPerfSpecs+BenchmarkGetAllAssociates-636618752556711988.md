# SkillsTracker.NBench.SkillsTrackerPerfSpecs+BenchmarkGetAllAssociates
__Test to ensure the performance parameters of GetAllAssociates API.__
_5/14/2018 6:14:15 AM_
### System Info
```ini
NBench=NBench, Version=1.0.4.0, Culture=neutral, PublicKeyToken=null
OS=Microsoft Windows NT 6.2.9200.0
ProcessorCount=4
CLR=4.0.30319.42000,IsMono=False,MaxGcGeneration=2
```

### NBench Settings
```ini
RunMode=Throughput, TestMode=Test
NumberOfIterations=10, MaximumRunTime=00:00:01
Concurrent=False
Tracing=False
```

## Data
-------------------

### Totals
|          Metric |           Units |             Max |         Average |             Min |          StdDev |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalBytesAllocated |           bytes |   19,370,136.00 |   19,217,596.00 |   19,094,736.00 |       88,102.88 |
|TotalCollections [Gen2] |     collections |            7.00 |            7.00 |            7.00 |            0.00 |
|[Counter] TestCounter |      operations |           21.00 |           21.00 |           21.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalBytesAllocated |           bytes |   20,707,406.67 |   19,909,798.55 |   17,387,138.49 |      987,092.87 |
|TotalCollections [Gen2] |     collections |            7.54 |            7.25 |            6.34 |            0.36 |
|[Counter] TestCounter |      operations |           22.63 |           21.76 |           19.02 |            1.07 |

### Raw Data
#### TotalBytesAllocated
|           Run # |           bytes |       bytes / s |      ns / bytes |
|---------------- |---------------- |---------------- |---------------- |
|               1 |   19,261,952.00 |   19,311,812.82 |           51.78 |
|               2 |   19,195,944.00 |   17,387,138.49 |           57.51 |
|               3 |   19,240,504.00 |   20,263,785.31 |           49.35 |
|               4 |   19,293,280.00 |   20,414,607.67 |           48.98 |
|               5 |   19,096,176.00 |   19,608,346.74 |           51.00 |
|               6 |   19,370,136.00 |   20,573,307.77 |           48.61 |
|               7 |   19,267,264.00 |   20,075,340.48 |           49.81 |
|               8 |   19,094,736.00 |   20,247,197.42 |           49.39 |
|               9 |   19,213,048.00 |   20,707,406.67 |           48.29 |
|              10 |   19,142,920.00 |   20,509,042.19 |           48.76 |

#### TotalCollections [Gen2]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            7.00 |            7.02 |  142,488,302.61 |
|               2 |            7.00 |            6.34 |  157,718,748.06 |
|               3 |            7.00 |            7.37 |  135,643,138.10 |
|               4 |            7.00 |            7.41 |  135,010,327.01 |
|               5 |            7.00 |            7.19 |  139,125,708.99 |
|               6 |            7.00 |            7.43 |  134,502,546.51 |
|               7 |            7.00 |            7.29 |  137,106,829.58 |
|               8 |            7.00 |            7.42 |  134,725,778.21 |
|               9 |            7.00 |            7.54 |  132,547,797.37 |
|              10 |            7.00 |            7.50 |  133,341,324.87 |

#### [Counter] TestCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |           21.00 |           21.05 |   47,496,100.87 |
|               2 |           21.00 |           19.02 |   52,572,916.02 |
|               3 |           21.00 |           22.12 |   45,214,379.37 |
|               4 |           21.00 |           22.22 |   45,003,442.34 |
|               5 |           21.00 |           21.56 |   46,375,236.33 |
|               6 |           21.00 |           22.30 |   44,834,182.17 |
|               7 |           21.00 |           21.88 |   45,702,276.53 |
|               8 |           21.00 |           22.27 |   44,908,592.74 |
|               9 |           21.00 |           22.63 |   44,182,599.12 |
|              10 |           21.00 |           22.50 |   44,447,108.29 |


## Benchmark Assertions

* [PASS] Expected TotalBytesAllocated to must be greater than or equal to 32,768.00 bytes; actual value was 19,217,596.00 bytes.
* [PASS] Expected TotalCollections [Gen2] to must be greater than or equal to 0.00 collections; actual value was 7.00 collections.

