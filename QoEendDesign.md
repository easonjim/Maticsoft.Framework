# 基本思路 #

构造一个支持RTCP协议的视频流媒体服务器，使用支持RTCP协议的客户端播放标准媒体流，客户端播放的同时计算QoE值，并随RR报告上传给服务器。

# 程序结构 #
libnemesi是开源的支持RTP/RTCP协议的库，因此选择使用此库的服务器和客户端改造后即可满足要求。
## 服务器 ##
服务器采用feng, feng使用libnemesi库支持RTCP协议。
_rtcp\_read\_cb()_（src/network/rtp.c）函数可用于输出rtcp数据，修改此函数实现，使之输出网络性能参数

## 客户端 ##
客户端采用mplayer。
mplayer可以使用libnemesi库实现对RTP/RTCP的支持。

mplayer处理流程
```
_RTP数据流_->libnemesi->_视频流_->解码库->_视频帧_
                 |
                 |
_RTCP报告_  <----
```
mplayer支持到文件输出，和YUV4MPEG格式，可供计算QoE。（-vo yuv4mpeg选项）

改造mplayer的处理流程为
```
_RTP数据流_->libnemesi->_视频流_->解码库->_视频帧_-->QoE计算函数
               |  ^                                      |            
               |  |                                      |
_RTCP报告_ <----  ------------- _QoE_ <-------------------            
```

改造在yuv4mpeg帧输出函数\_draw\_slice()_（？libvo/vo\_yuv4mpeg.c），增加计算QoE的功能。_

改造QoE计算函数，实现递推计算，形如：

  * QoE-_n+1_ = FQoE(FrameN,QoE-_n_)

并将计算结果保存在共享内存中。

改造libnemesi的RR报告生成函数\_rtcp\_build\_rr()_，从共享内存读取QoE值，并填入私有扩展字段_




