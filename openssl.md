**编译环境配置
```
MACHINE=arm-l-linux2 CC=arm-none-linux-gnueabi-gcc ./config shared no-krb5 --prefix=/usr
```**

**修改Makefile, 增加编译开关，选择编译指令集
```
CFLAG= -fPIC -DOPENSSL_PIC -DOPENSSL_THREADS -D_REENTRANT -DDSO_DLFCN -DHAVE_DLFCN_H -DL_ENDIAN -DTERMIO -O3 -fomit-frame-pointer -Wall -march=armv4t -mcpu=arm920t
SHARED_LDFLAGS=-march=armv4t -mcpu=arm920t
```** make

