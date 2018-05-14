# SkillsTracker.NBench.SkillsTrackerPerfSpecs+BenchmarkGetAllSkills
__Test to ensure the performance parameters of GetAllSkills API__
_5/14/2018 6:13:05 AM_
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
|TotalBytesAllocated |           bytes |   36,128,280.00 |   34,246,853.60 |   27,335,792.00 |    2,690,531.38 |
|TotalCollections [Gen2] |     collections |            5.00 |            4.50 |            4.00 |            0.53 |
|[Counter] TestCounter |      operations |           25.00 |           25.00 |           25.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalBytesAllocated |           bytes |   33,734,070.80 |   28,657,358.98 |   24,113,107.79 |    3,021,429.71 |
|TotalCollections [Gen2] |     collections |            4.01 |            3.74 |            3.34 |            0.27 |
|[Counter] TestCounter |      operations |           25.03 |           21.06 |           16.69 |            2.87 |

### Raw Data
#### TotalBytesAllocated
|           Run # |           bytes |       bytes / s |      ns / bytes |
|---------------- |---------------- |---------------- |---------------- |
|               1 |   35,976,176.00 |   28,868,551.23 |           34.64 |
|               2 |   36,018,776.00 |   28,688,127.86 |           34.86 |
|               3 |   36,128,280.00 |   24,113,107.79 |           41.47 |
|               4 |   36,062,424.00 |   24,846,333.74 |           40.25 |
|               5 |   33,795,400.00 |   28,457,701.33 |           35.14 |
|               6 |   36,064,816.00 |   28,535,741.52 |           35.04 |
|               7 |   33,674,856.00 |   30,710,497.29 |           32.56 |
|               8 |   27,335,792.00 |   26,477,111.21 |           37.77 |
|               9 |   33,722,232.00 |   32,142,347.05 |           31.11 |
|              10 |   33,689,784.00 |   33,734,070.80 |           29.64 |

#### TotalCollections [Gen2]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            5.00 |            4.01 |  249,241,298.73 |
|               2 |            5.00 |            3.98 |  251,105,796.62 |
|               3 |            5.00 |            3.34 |  299,656,770.18 |
|               4 |            5.00 |            3.44 |  290,283,664.20 |
|               5 |            4.00 |            3.37 |  296,891,512.83 |
|               6 |            5.00 |            3.96 |  252,769,432.85 |
|               7 |            4.00 |            3.65 |  274,131,477.59 |
|               8 |            4.00 |            3.87 |  258,107,765.12 |
|               9 |            4.00 |            3.81 |  262,288,189.06 |
|              10 |            4.00 |            4.01 |  249,671,794.69 |

#### [Counter] TestCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |           25.00 |           20.06 |   49,848,259.75 |
|               2 |           25.00 |           19.91 |   50,221,159.32 |
|               3 |           25.00 |           16.69 |   59,931,354.04 |
|               4 |           25.00 |           17.22 |   58,056,732.84 |
|               5 |           25.00 |           21.05 |   47,502,642.05 |
|               6 |           25.00 |           19.78 |   50,553,886.57 |
|               7 |           25.00 |           22.80 |   43,861,036.41 |
|               8 |           25.00 |           24.21 |   41,297,242.42 |
|               9 |           25.00 |           23.83 |   41,966,110.25 |
|              10 |           25.00 |           25.03 |   39,947,487.15 |


## Benchmark Assertions

* [PASS] Expected TotalBytesAllocated to must be greater than or equal to 32,768.00 bytes; actual value was 34,246,853.60 bytes.
* [PASS] Expected TotalCollections [Gen2] to must be greater than or equal to 0.00 collections; actual value was 4.50 collections.

