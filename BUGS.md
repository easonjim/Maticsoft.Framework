
```
BUG: Bad page state in process sh  pfn:230800 [ubi_bgt0d]
page:c0500000 count:134316031 mapcount:0 mapping:  (null) index:0x0
page flags: 0x0()
[<c0033474>] (unwind_backtrace+0x0/0xe4) from [<c006dbf8>] (bad_page+0xc8/0xf4)
[<c006dbf8>] (bad_page+0xc8/0xf4) from [<c006eb98>] (get_page_from_freelist+0x330/0x454)
[<c006eb98>] (get_page_from_freelist+0x330/0x454) from [<c006eda8>] (__alloc_pages_nodemask+0xec/0x578)
[<c006eda8>] (__alloc_pages_nodemask+0xec/0x578) from [<c007d3d0>] (__pte_alloc+0x20/0x158)
[<c007d3d0>] (__pte_alloc+0x20/0x158) from [<c007d560>] (handle_mm_fault+0x58/0xa8)
[<c007d560>] (handle_mm_fault+0x58/0xa8) from [<c0034394>] (do_page_fault+0xdc/0x1c8)
[<c0034394>] (do_page_fault+0xdc/0x1c8) from [<c00282b4>] (do_DataAbort+0x34/0x98)
[<c00282b4>] (do_DataAbort+0x34/0x98) from [<c002dda0>] (ret_from_exception+0x0/0x10)
Exception stack(0xc335dfb0 to 0xc335dff8)
dfa0:                                     00001ab4 00000000 00000000 00000000
dfc0: 001f9068 bebf8780 001f54b4 00000078 00000000 001f9000 00001ab4 bebf87b4
dfe0: 001f94c0 bebf876c 0011a560 00100354 60000010 ffffffff
Internal error: Oops - undefined instruction: 0 [#1]
last sysfs file: /sys/devices/platform/at91_ohci/usb1/1-1/usb_device/usbdev1.4/dev
Modules linked in:
CPU: 0    Tainted: G    B        (2.6.38+ #1)
PC is at __ip_route_output_key+0x14c/0x76c
LR is at __ip_route_output_key+0x94/0x76c
pc : [<c02a8174>]    lr : [<c02a80bc>]    psr: 60000013
sp : c334bcb8  ip : c049871c  fp : 00005b23
r10: 00000063  r9 : 00000000  r8 : c0498848
r7 : 00000000  r6 : c049871c  r5 : c3051080  r4 : c334bd80
r3 : 0005ca95  r2 : 00000036  r1 : 00000001  r0 : 000003ff
Flags: nZCv  IRQs on  FIQs on  Mode SVC_32  ISA ARM  Segment user
Control: 0005317f  Table: 23074000  DAC: 00000015
Process PPPprobe (pid: 6824, stack limit = 0xc334a270)
Stack: (0xc334bcb8 to 0xc334c000)
bca0:                                                       c305bc60 c305e1a0
bcc0: 0000000e c334bdcc c305e1b4 c02afd88 c305bc60 c3b94260 c3b94260 00000000
bce0: c3b57c10 c02ad510 c3b57c00 00000000 c3b94260 c02af1c8 c3b94260 00000000
bd00: c3b94260 c305bc60 00000000 c3b57c24 c04583dc c334bd80 c334bdcc c334bf5c
bd20: 00000000 0100007f 00000000 00000063 00005b23 c02a87a4 c3b94260 c3b94260
bd40: 00000000 c02ccde0 00000001 c334bdbc c334bdcc 00000000 c049871c 00000000
bd60: 00000000 0100007f 00000000 00000000 00000000 00002db1 00000011 00000000
bd80: 00000000 00000000 00000000 0100007f 00000000 00000000 00000000 00000000
bda0: 00000000 00000000 00000000 00000000 00000011 5b232db1 00000000 0100007f
bdc0: 00000000 00000000 00000000 00000000 00000041 c334be10 00000063 c334bf5c
bde0: c3b94260 00000010 c334a000 00029c7c 0001f698 c02d3328 00000063 c334bedc
be00: c334bf5c c352ba40 00000040 c027e3bc ffffffff 00000000 00000000 00000001
be20: ffffffff 00000000 00000000 00000000 00000000 00000000 c32aa900 00000001
be40: 00000000 00000000 c32aa900 00000000 c334be88 c0039cd4 00000000 c3bde8dc
be60: 00000001 c3bde8e8 00000000 00000001 00000000 c00384b4 00000000 60000013
be80: c3bdec00 00000002 c3b16800 c334a000 c3b16800 00000063 c352ba40 c003850c
bea0: 00000000 c334bf5c c3bde800 00000063 c352ba40 00000040 00000010 c334bedc
bec0: 00000010 00000000 c334bedc c334bedc 00000063 c027ecb0 00000000 5b230002
bee0: 0100007f 00000000 00000000 60000013 c334bf30 c34f6c80 c334a000 00000000
bf00: 403dc000 00000001 c334bf24 c003850c 00000000 055d4d40 c3bde800 00000000
bf20: 00000000 00000001 c3bd1280 00000000 00000000 00000000 c334bf38 00000001
bf40: c3836128 00000002 c34f6c00 00000000 c3836120 00000001 00000000 c334bedc
bf60: 00000010 c334bf78 00000001 00000000 00000000 00000040 0002c640 00000063
bf80: 00000001 00000000 00000001 00029c7c 00000010 00029c1c 00000122 c002dfc8
bfa0: 00000000 c002de20 00029c7c 00000010 00000006 0002c640 00000063 00000040
bfc0: 00029c7c 00000010 00029c1c 00000122 484c9d58 00000001 0002c687 0001f698
bfe0: 00000000 484c9c90 4010698c 401078c4 80000010 00000006 00000000 00000000
[<c02a8174>] (__ip_route_output_key+0x14c/0x76c) from [<c02a87a4>] (ip_route_output_flow+0x10/0x50)
[<c02a87a4>] (ip_route_output_flow+0x10/0x50) from [<c02ccde0>] (udp_sendmsg+0x318/0x5c8)
[<c02ccde0>] (udp_sendmsg+0x318/0x5c8) from [<c02d3328>] (inet_sendmsg+0x64/0x6c)
[<c02d3328>] (inet_sendmsg+0x64/0x6c) from [<c027e3bc>] (sock_sendmsg+0x90/0xb0)
[<c027e3bc>] (sock_sendmsg+0x90/0xb0) from [<c027ecb0>] (sys_sendto+0xb4/0xd8)
[<c027ecb0>] (sys_sendto+0xb4/0xd8) from [<c002de20>] (ret_fast_syscall+0x0/0x2c)
Code: e5851080 e121f002 e5952084 e5853088 (e2822001) 
---[ end trace f98fc190b5d4c3b0 ]---
Kernel panic - not syncing: Fatal exception in interrupt
[<c0033474>] (unwind_backtrace+0x0/0xe4) from [<c03411a4>] (panic+0x50/0x174)
[<c03411a4>] (panic+0x50/0x174) from [<c003183c>] (die+0x184/0x1c4)
[<c003183c>] (die+0x184/0x1c4) from [<c00281c8>] (do_undefinstr+0x128/0x148)
[<c00281c8>] (do_undefinstr+0x128/0x148) from [<c002db04>] (__und_svc+0x44/0x60)
Exception stack(0xc334bc70 to 0xc334bcb8)
bc60:                                     000003ff 00000001 00000036 0005ca95
bc80: c334bd80 c3051080 c049871c 00000000 c0498848 00000000 00000063 00005b23
bca0: c049871c c334bcb8 c02a80bc c02a8174 60000013 ffffffff
[<c002db04>] (__und_svc+0x44/0x60) from [<c02a8174>] (__ip_route_output_key+0x14c/0x76c)
[<c02a8174>] (__ip_route_output_key+0x14c/0x76c) from [<c02a87a4>] (ip_route_output_flow+0x10/0x50)
[<c02a87a4>] (ip_route_output_flow+0x10/0x50) from [<c02ccde0>] (udp_sendmsg+0x318/0x5c8)
[<c02ccde0>] (udp_sendmsg+0x318/0x5c8) from [<c02d3328>] (inet_sendmsg+0x64/0x6c)
[<c02d3328>] (inet_sendmsg+0x64/0x6c) from [<c027e3bc>] (sock_sendmsg+0x90/0xb0)
[<c027e3bc>] (sock_sendmsg+0x90/0xb0) from [<c027ecb0>] (sys_sendto+0xb4/0xd8)
[<c027ecb0>] (sys_sendto+0xb4/0xd8) from [<c002de20>] (ret_fast_syscall+0x0/0x2c)
```