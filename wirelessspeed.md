|制式|下载|上传|
|:-|:-|:-|
|TD-SCDMA|约330kpbs|？ |
|CDMA2000|约1Mkbps|200Kbps|
|WCDMA|约100～500kpbs|约70kbps|


```

WCDMA# time wget http:///tmp/a.pdf ; rm a.pdf

a.pdf                100% |*******************************|   435k --:--:-- ETA


real	0m 20.72s
user	0m 0.08s
sys	0m 0.54s

real	0m 18.11s
user	0m 0.06s
sys	0m 0.55s

real	0m 14.47s
user	0m 0.09s
sys	0m 0.69s

real	0m 27.31s
user	0m 0.05s
sys	0m 0.92s


TD-SCDMA# time wget http:///tmp/a.pdf ;rm a.pdf

a.pdf                100% |*******************************|   435k --:--:-- ETA
real	0m 15.82s
user	0m 0.05s
sys	0m 0.48s

real	0m 12.55s
user	0m 0.10s
sys	0m 0.71s

real	0m 11.60s
user	0m 0.06s
sys	0m 0.60s

CDMA2000

a.pdf                100% |*******************************|   435k --:--:-- ETA
real	0m 2.99s
user	0m 0.04s
sys	0m 0.36s

a.pdf                100% |*******************************|   435k --:--:-- ETA
real	0m 3.25s
user	0m 0.01s
sys	0m 0.41s

a.pdf                100% |*******************************|   435k --:--:-- ETA
real	0m 2.71s
user	0m 0.10s
sys	0m 0.48s


```