# SkillsTracker.NBench.SkillsTrackerPerfSpecs+BenchmarkAddNewSkill
__Test to ensure the performance parameters of AddNewSkill API.__
_5/14/2018 6:13:40 AM_
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
|TotalBytesAllocated |           bytes |   28,711,048.00 |   16,962,427.20 |   10,488,232.00 |    5,704,561.00 |
|TotalCollections [Gen2] |     collections |            6.00 |            5.40 |            5.00 |            0.52 |
|[Counter] TestCounter |      operations |           22.00 |           22.00 |           22.00 |            0.00 |

### Per-second Totals
|          Metric |       Units / s |         Max / s |     Average / s |         Min / s |      StdDev / s |
|---------------- |---------------- |---------------- |---------------- |---------------- |---------------- |
|TotalBytesAllocated |           bytes |   29,289,154.48 |   17,052,138.03 |   10,027,069.29 |    5,846,588.52 |
|TotalCollections [Gen2] |     collections |            6.05 |            5.41 |            4.81 |            0.45 |
|[Counter] TestCounter |      operations |           23.37 |           22.08 |           21.03 |            0.72 |

### Raw Data
#### TotalBytesAllocated
|           Run # |           bytes |       bytes / s |      ns / bytes |
|---------------- |---------------- |---------------- |---------------- |
|               1 |   19,179,616.00 |   19,411,662.36 |           51.52 |
|               2 |   13,872,384.00 |   14,736,501.34 |           67.86 |
|               3 |   21,366,792.00 |   21,940,453.54 |           45.58 |
|               4 |   14,782,640.00 |   14,914,127.78 |           67.05 |
|               5 |   12,407,824.00 |   12,580,223.77 |           79.49 |
|               6 |   28,711,048.00 |   29,289,154.48 |           34.14 |
|               7 |   13,000,984.00 |   12,591,467.64 |           79.42 |
|               8 |   10,488,232.00 |   10,027,069.29 |           99.73 |
|               9 |   13,659,120.00 |   13,718,899.73 |           72.89 |
|              10 |   22,155,632.00 |   21,311,820.43 |           46.92 |

#### TotalCollections [Gen2]
|           Run # |     collections | collections / s |ns / collections |
|---------------- |---------------- |---------------- |---------------- |
|               1 |            5.00 |            5.06 |  197,609,206.67 |
|               2 |            5.00 |            5.31 |  188,272,422.07 |
|               3 |            5.00 |            5.13 |  194,770,741.30 |
|               4 |            6.00 |            6.05 |  165,197,279.35 |
|               5 |            5.00 |            5.07 |  197,259,193.94 |
|               6 |            5.00 |            5.10 |  196,052,419.49 |
|               7 |            6.00 |            5.81 |  172,087,220.44 |
|               8 |            6.00 |            5.74 |  174,331,962.41 |
|               9 |            6.00 |            6.03 |  165,940,421.26 |
|              10 |            5.00 |            4.81 |  207,918,718.86 |

#### [Counter] TestCounter
|           Run # |      operations |  operations / s | ns / operations |
|---------------- |---------------- |---------------- |---------------- |
|               1 |           22.00 |           22.27 |   44,911,183.33 |
|               2 |           22.00 |           23.37 |   42,789,186.84 |
|               3 |           22.00 |           22.59 |   44,266,077.57 |
|               4 |           22.00 |           22.20 |   45,053,803.46 |
|               5 |           22.00 |           22.31 |   44,831,634.99 |
|               6 |           22.00 |           22.44 |   44,557,368.07 |
|               7 |           22.00 |           21.31 |   46,932,878.30 |
|               8 |           22.00 |           21.03 |   47,545,080.66 |
|               9 |           22.00 |           22.10 |   45,256,478.52 |
|              10 |           22.00 |           21.16 |   47,254,254.29 |


## Benchmark Assertions

* [PASS] Expected TotalBytesAllocated to must be greater than or equal to 32,768.00 bytes; actual value was 16,962,427.20 bytes.
* [PASS] Expected TotalCollections [Gen2] to must be greater than or equal to 0.00 collections; actual value was 5.40 collections.

