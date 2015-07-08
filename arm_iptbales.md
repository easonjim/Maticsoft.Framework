**1.4.5**

  1. ./configure --prefix=_arm-filesys-root_ --host=arm-none-linux-gnueabi  LDFLAGS='-march=armv4t -mcpu=arm920t'  CFLAGS='-march=armv4t -mcpu=arm920t'
    * _arm-filesys-root_ : 安装目录所在位置
  1. 修改Makefile中$xtlibdir的设置，去掉$(exec\_prefix),如下
```
@@ -343,7 +343,8 @@
 top_build_prefix = 
 top_builddir = .
 top_srcdir = .
-xtlibdir = ${exec_prefix}/libexec/xtables
+xtlibdir = /libexec/xtables
 ACLOCAL_AMFLAGS = -I m4
 AUTOMAKE_OPTIONS = foreign subdir-objects
 AM_CFLAGS = ${regular_CFLAGS} -I${top_builddir}/include -I${top_srcdir}/include ${kinclude_CFLAGS}
```
  1. make
  1. make install (必要时，使用sudo make install)



**1.4.8**

  1. ./configure --prefix=_arm-filesys-root_ --host=arm-none-linux-gnueabi --disable-shared LDFLAGS='-march=armv4t -mcpu=arm920t'  CFLAGS='-march=armv4t -mcpu=arm920t'
  1. 修改Makefile,和1.4.5相同
  1. make
  1. make install
    * make install如出错，修改libtool的ranlib路径