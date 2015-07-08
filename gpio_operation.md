## GPIO到文件系统的映射 ##

  * 控制GPIO的目录位于/sys/class/gpio
  * /sys/class/gpio/export文件用于通知系统需要导出控制的GPIO引脚编号
  * /sys/class/gpio/unexport 用于通知系统取消导出
  * /sys/class/gpio/gpiochipX目录保存系统中GPIO寄存器的信息，包括每个寄存器控制引脚的起始编号base，寄存器名称，引脚总数

## 导出一个引脚的操作步骤 ##

  * 首先计算此引脚编号，引脚编号 = 控制引脚的寄存器基数 + 控制引脚寄存器位数
  * 向/sys/class/gpio/export写入此编号，比如12号引脚，在shell中可以通过以下命令实现，命令成功后生成/sys/class/gpio/gpio12目录，如果没有出现相应的目录，说明此引脚不可导出：
```
echo 12 > /sys/class/gpio/export
```
  * direction文件，定义输入输入方向，可以通过下面命令定义为输出
```
echo out > direction
```

  * direction接受的参数：in, out, high, low。high/low同时设置方向为输出，并将value设置为相应的1/0。
  * value文件是端口的数值，为1或0.