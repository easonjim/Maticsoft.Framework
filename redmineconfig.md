# REDMINE CONFIG #




# Details #
如果用SqlLite,以下和数据库相关部分可以不执行

```
    sudo apt-get install mysql-server

    sudo apt-get install phpmyadmin
    sudo apt-get install redmine redmine-mysql
    打开phpmyadmin，删除默认生成的redmine_default数据库中的所有数据表。这是因为默认的数据库编码不是utf8，会造成中文乱码的问题。我们需要先删除，然后按下面的步骤重新配置
    在phpmyadmin中修改redmine_default数据库的编码为utf8
    sudo dpkg-reconfigure redmine
    sudo ln -s /usr/share/redmine/public/ /var/www/redmine
    sudo vim /etc/apache2/site-enabed/000-default，加入以下三行代码，特别要注意最后一行，这是指定Passenger运行的帐户与apache2默认的www-data一致，以免造成权限错误。
    RailsEnv production
    RailsBaseURI /redmine
    PassengerDefaultUser www-data
    sudo service apache2 restart，打开http://localhost/redmine 即可以访问redmine。
    在中文环境下redmine的一些字体非常小，看不清楚，这是一个国外软件经常会出现的一个bug，这是因为中文字体在1em以下看不清楚，我们只要修改相应的css文件即可。
    打开/var/www/redmine/stylesheets/application.css，找到font-size: 0.9em和font-size: 0.8em，全部替换为font-size: 1em，就可以达到完美的效果了。
```

最近版本控制主機換機器，就把原本的資料備份出來，由於新版的Bitnami的redmine已經升級，

所以移轉過程中有點小問題，在此紀錄一下。

舊版本：Redmine 1.0.3.stable (MySQL)

新版本：Redmine 1.2.1.stable (MySQL)

備份與還原 Redmine 資料庫、檔案，請參考 TFS 的替代方案：Redmine【Part5】Redmine 與 Subversion 的備份與還原

還原之後，開啟Redmine，會發現網站是亂碼，

首先將 C:\Program Files\BitNami Redmine Stack\apps\redmine\config\database.yml 中的 encoding: utf8mark掉，變成 #encoding: utf8

原因不明，還沒細究XD，估計是新版的跟舊版的資料庫有些不同而造成~ 因為之前移轉過並沒有這個問題。

到這邊，網站顯示就正常了，但是...你會沒法登入，登入會收到 error 500，

看Log的錯誤訊息是：

NameError (undefined local variable or method `salt' for #

&lt;User:0x7c6ebd0&gt;

):
app/models/user.rb:220:in `check\_password?'....之類的，

所以你必須下個指令，到程式集的 bitnami底下，點選 Use BitNami Redmine Stack

進入Redmine的命令視窗，再 cd C:\Program Files\BitNami Redmine Stack\apps\redmine\

執行 rake db:migrate RAILS\_ENV=production，

約莫幾秒鐘跑完，Redmine 登入就正常囉！