**编译配置
```
./configure --arch=arm --target-os=linux --enable-cross-compile --cross-prefix=arm-none-linux-gnueabi- --prefix=/usr  --extra-cflags='-march=armv4t -mcpu=arm920t' --extra-ldflags='-march=armv4t -mcpu=arm920t' --disable-static --enable-shared

```**

