_**编译前，请确认交叉编译器arm-none-linux-gnueabi-gcc在可执行文件的搜索路径中**_



**1 下载TCPDUMP 4.1.1 / LIBPCAP 1.1.1，并在同一父目录下解压。
```
tar -xvzf libpcap-1.1.1.tar.gz
tar -xvzf tcpdump-4.1.1.tar.gz
```** 2 进入libpcap-1.1.1目录，修改libpcap下的配置程序configure，注释掉两项检测，diff -u的结果如下，即将-号行内容改为和+号行的内容。（diff -u old new)
```
-- old
++ new
@@ -6898,11 +6898,11 @@
 
 else
 
-if test -z "$with_pcap" && test "$cross_compiling" = yes; then
-	{ { echo "$as_me:$LINENO: error: pcap type not determined when cross-compiling; use --with-pcap=..." >&5
-echo "$as_me: error: pcap type not determined when cross-compiling; use --with-pcap=..." >&2;}
-   { (exit 1); exit 1; }; }
-fi
+#if test -z "$with_pcap" && test "$cross_compiling" = yes; then
+#	{ { echo "$as_me:$LINENO: error: pcap type not determined when cross-compiling; use --with-pcap=..." >&5
+#echo "$as_me: error: pcap type not determined when cross-compiling; use --with-pcap=..." >&2;}
+#   { (exit 1); exit 1; }; }
+#fi
 
 # Check whether --with-pcap was given.
 if test "${with_pcap+set}" = set; then
@@ -7234,11 +7234,11 @@
  	fi
 	{ echo "$as_me:$LINENO: result: $ac_cv_linux_vers" >&5
 echo "${ECHO_T}$ac_cv_linux_vers" >&6; }
- 	if test $ac_cv_linux_vers = unknown ; then
- 		{ { echo "$as_me:$LINENO: error: cannot determine linux version when cross-compiling" >&5
-echo "$as_me: error: cannot determine linux version when cross-compiling" >&2;}
-   { (exit 1); exit 1; }; }
- 	fi
+# 	if test $ac_cv_linux_vers = unknown ; then
+# 		{ { echo "$as_me:$LINENO: error: cannot determine linux version when cross-compiling" >&5
+#echo "$as_me: error: cannot determine linux version when cross-compiling" >&2;}
+#   { (exit 1); exit 1; }; }
+# 	fi
 	if test $ac_cv_linux_vers -lt 2 ; then
 		{ { echo "$as_me:$LINENO: error: version 2 or higher required; see the INSTALL doc for more info" >&5
 echo "$as_me: error: version 2 or higher required; see the INSTALL doc for more info" >&2;}
```
**3 执行配置命令
```
./configure --host=arm-none-linux-gnueabi
```** 4 修改Makefile，在LDFLAGS，和CFLAGS设置中加入CPU代码开关：-march=armv4t -mcpu=arm920t

**5 执行make命令**

**6 进入tcpdump-4.1.1目录，修改tcpdump下的配置程序configure，注释掉1项检测，diff -u的结果如下
```
--old
++new
@@ -4408,11 +4408,11 @@
  	fi
 	{ echo "$as_me:$LINENO: result: $ac_cv_linux_vers" >&5
 echo "${ECHO_T}$ac_cv_linux_vers" >&6; }
- 	if test $ac_cv_linux_vers = unknown ; then
- 		{ { echo "$as_me:$LINENO: error: cannot determine linux version when cross-compiling" >&5
-echo "$as_me: error: cannot determine linux version when cross-compiling" >&2;}
-   { (exit 1); exit 1; }; }
- 	fi
+# 	if test $ac_cv_linux_vers = unknown ; then
+# 		{ { echo "$as_me:$LINENO: error: cannot determine linux version when cross-compiling" >&5
+#echo "$as_me: error: cannot determine linux version when cross-compiling" >&2;}
+#   { (exit 1); exit 1; }; }
+# 	fi
 	if test $ac_cv_linux_vers -lt 2 ; then
 		{ { echo "$as_me:$LINENO: error: version 2 or higher required; see the INSTALL doc for more info" >&5
 echo "$as_me: error: version 2 or higher required; see the INSTALL doc for more info" >&2;}
```** 7 执行配置命令
```
./configure --host=arm-none-linux-gnueabi
```
**8 修改Makefile，增加编译CPU代码开关，并去掉错误的头文件搜索路径，修改的几项参数的结果如下：
```
INCLS = -I. -I./../libpcap-1.1.1  -I$(srcdir)/missing
DEFS = -DHAVE_CONFIG_H  -I./../libpcap-1.1.1  -I$(srcdir)/missing  -D_U_="__attribute__((unused))"
CFLAGS = $(CCOPT) $(DEFS) $(INCLS) -march=armv4t -mcpu=arm920t
LDFLAGS = -march=armv4t -mcpu=arm920t
```** 9 执行make