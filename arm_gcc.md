  * 由于GCC 4.4.X版本缺省支持armv5版本指令，而Samsung S3c2440为armv4版本，因此在编译是需要指定指令集版本和CPU类型,如不指定，可能出现非法指令错误（illegal instruction）。在编译命令中增加以下开关即可：
```
-march=armv4t -mcpu=arm920t
```
  * 对于编译和链接分开进行的情况，编译链接指令需要分别增加以上开关。