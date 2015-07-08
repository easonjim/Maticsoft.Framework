**lsof [revision 4](https://code.google.com/p/orisoft/source/detail?r=4).84**

  * 使用./Configure linux生成Makefile。注意
```
Do you want to take inventory (y|n) [y]?
```
选y
```
Do you want to customize (y|n) [y]? n
```
选n
  * 修改生成的Makefile,将以下几项改为所示的内容
```
CC=	/usr/local/arm/4.4.1/bin/arm-none-linux-gnueabi-gcc 
 
CFGF=	 -DLINUXV=26287 -DGLIBCV -march=armv4t -mcpu=arm920t
 
CFGL=	 -L./lib -llsof -march=armv4t -mcpu=arm920t
```
