# SkillsTracker.NBench.SkillsTrackerPerfSpecs+BenchmarkAddAssociate
__Test to ensure the performance parameters of AddNewAssociate API.__
_5/14/2018 6:14:51 AM_
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
|TotalBytesAllocated |           bytes |   25,616,920.00 |   13,656,982.40 |    5,079,704.00 |    7,785,699.29 |
|TotalCollections [Gen2] |     collections |            7.00 |            6.10 |            6.00 |            0.32 |
|[Counter] TestCounter |      operations |           17.00 |           17.00 |           17.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalBytesAllocated |           bytes |   23,754,605.55 |   12,861,433.18 |    4,769,062.89 |    7,267,894.21 |
|TotalCollections [Gen2] |     collections |            6.40 |            5.75 |            5.56 |            0.24 |
|[Counter] TestCounter |      operations |           16.45 |           16.05 |           15.54 |            0.29 |

### Raw Data
#### TotalBytesAllocated
|           Run # |           bytes |       bytes / s |      ns / bytes |
|---------------- |---------------- |---------------- |---------------- |
|               1 |    7,095,096.00 |    6,813,211.66 |          146.77 |
|               2 |    7,548,544.00 |    7,302,128.52 |          136.95 |
|               3 |   14,212,016.00 |   13,663,442.57 |           73.19 |
|               4 |   19,993,680.00 |   18,865,786.15 |           53.01 |
|               5 |   18,734,488.00 |   17,419,193.09 |           57.41 |
|               6 |   23,692,920.00 |   22,456,449.55 |           44.53 |
|               7 |    6,688,960.00 |    6,342,233.14 |          157.67 |
|               8 |   25,616,920.00 |   23,754,605.55 |           42.10 |
|               9 |    5,079,704.00 |    4,769,062.89 |          209.68 |
|              10 |    7,907,496.00 |    7,228,218.69 |          138.35 |

#### TotalCollections [Gen2]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            6.00 |            5.76 |  173,562,199.40 |
|               2 |            6.00 |            5.80 |  172,290,950.84 |
|               3 |            6.00 |            5.77 |  173,358,165.10 |
|               4 |            6.00 |            5.66 |  176,630,858.25 |
|               5 |            6.00 |            5.58 |  179,251,395.30 |
|               6 |            6.00 |            5.69 |  175,843,469.41 |
|               7 |            6.00 |            5.69 |  175,778,253.80 |
|               8 |            6.00 |            5.56 |  179,733,006.20 |
|               9 |            6.00 |            5.63 |  177,522,786.57 |
|              10 |            7.00 |            6.40 |  156,282,250.73 |

#### [Counter] TestCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |           17.00 |           16.32 |   61,257,246.85 |
|               2 |           17.00 |           16.45 |   60,808,570.89 |
|               3 |           17.00 |           16.34 |   61,185,234.74 |
|               4 |           17.00 |           16.04 |   62,340,302.91 |
|               5 |           17.00 |           15.81 |   63,265,198.34 |
|               6 |           17.00 |           16.11 |   62,062,400.97 |
|               7 |           17.00 |           16.12 |   62,039,383.69 |
|               8 |           17.00 |           15.76 |   63,435,178.66 |
|               9 |           17.00 |           15.96 |   62,655,101.14 |
|              10 |           17.00 |           15.54 |   64,351,515.01 |


## Benchmark Assertions

* [PASS] Expected TotalBytesAllocated to must be greater than or equal to 32,768.00 bytes; actual value was 13,656,982.40 bytes.
* [PASS] Expected TotalCollections [Gen2] to must be greater than or equal to 0.00 collections; actual value was 6.10 collections.

