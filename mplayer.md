  1. 具有RTCP客户端的mplayer依赖libnemesi->libnetembryo->libssl->libz。移植思路是先将依赖的库分别编译后，安装在一个临时目录，最后编译mplayer。
  1. zlib-1.2.5编译
    * 配置
```
CC=arm-none-linux-gnueabi-gcc ./configure --prefix=/usr
```
    * 修改Makefile，在以下变量处加入处理器选项
```
CFLAGS=-O3 -D_LARGEFILE64_SOURCE=1 -march=armv4t -mcpu=arm920t
LDFLAGS= -L. libz.a -march=armv4t -mcpu=arm920t
LDSHARED=arm-none-linux-gnueabi-gcc -shared -march=armv4t -mcpu=arm920t -Wl,-soname,libz.so.1,--version-script,zlib.map
```
    * Make
    * 安装
```
make DESTDIR=/tmp install
```
  1. openssl-0.9.8o编译
    * 配置
```
MACHINE=arm-l-linux2 CC=arm-none-linux-gnueabi-gcc ./config shared no-krb5 --prefix=/usr
```
    * 修改Makefile，在以下变量处加入处理器选项
```
CFLAG= -fPIC -DOPENSSL_PIC -DOPENSSL_THREADS -D_REENTRANT -DDSO_DLFCN -DHAVE_DLFCN_H -DL_ENDIAN -DTERMIO -O3 -fomit-frame-pointer -Wall -march=armv4t -mcpu=arm920t
SHARED_LDFLAGS=-march=armv4t -mcpu=arm920t
```
    * Make
    * 安装
```
make INSTALL_PREFIX=/tmp install
```
  1. netembryo-0.1.1编译
    * 配置
```
CC=arm-none-linux-gnueabi-gcc ./configure --prefix=/usr
```
    * 修改Makefile中ssl连接库的位置
```
OPENSSL_CFLAGS = -I/tmp/usr/kerberos/include
OPENSSL_LIBS = -L/tmp/usr/kerberos/lib -lssl -lcrypto -ldl -lz
```
    * Make
```
make CFLAGS='-march=armv4t -mcpu=arm920t -I/tmp/usr/include' LDFLAGS='-march=armv4t -mcpu=arm920t -L/tmp/usr/lib'
```
    * 安装
```
make DESTDIR=/tmp install
```
  1. libnemesi-master编译
    * 配置。如果configue过程出错，根据提示添加缺少的配置项
```
autoreconf --install
./configure PKG_CONFIG_PATH=/tmp/usr/lib/pkgconfig CFLAGS='-march=armv4t -mcpu=arm920t -I/tmp/usr/include' LDFLAGS='-march=armv4t -mcpu=arm920t -L/tmp/usr/lib' --host=arm-none-linux-gnueabi
```
    * 修改/tmp/usr/lib中la文件中的路径配置为/tmp起始
    * Make
    * 安装
```
make DESTDIR=/tmp install
```
  1. mplayer-checkout-2010-06-28
    * 编译配置
```
./configure  --target=arm-linux --enable-cross-compile --cc=arm-none-linux-gnueabi-gcc --prefix=/usr  --extra-cflags='-march=armv4t -mcpu=arm920t -I/tmp/usr/include' --extra-ldflags='-march=armv4t -mcpu=arm920t -L/tmp/usr/lib' --enable-nemesi --extra-libs-mplayer='-lnemesi -lnetembryo -lssl -lcrypto -lz'
```
    * Make
    * 安装。编译完成的程序安装在/tmp目录下，然后拷贝到目标机
```
make DESTDIR=/tmp INSTALLSTRIP=  install
```