# DorduncuHaftaOdevi

Hangfire yada Quartz kullanarak sql server da oluşturduğunuz bir tabloda işlem yapacak job lar geliştiriniz.
Dataya erişim olarak UnitOfWork veya Dapper kullanabilirsiniz.
Sql server da kendi random tablonuzu herhangi bir model de oluşturabilirsiniz. (Icerisinde Status isminde bir alan olsun.)
Datalar statik yada dinamik generate edilebilir .
15 dakikada 1 kez çalışacak bir job ekleyerek bu tabloya insert atininiz.
Günde bir kez 18.00 da çalışarak (Ayni gun içinde 08:00 den 18:00) o güne kadar eklenmiş olan kayıtların Status alanını farklı bir değer olarak güncelleyen bir job ekleyiniz. (işlemlerin sadece o aralıkta geldiğini varsayabiliriz. )

[Odev 4.0..pdf](https://github.com/Semra4141/UcuncuHaftaOdevi/files/7918753/Odev.4.0.pdf)

# Çözüm

Ödev için şuana kadar yaptığımız uygulamanın üzerine Patika.Hangfire isminde bir proje ekledim. İşleri, proje içindeki Jobs klasöründe tanımladım. Jobları oluşturmak için BackgroundJobController'daki InsertionJob ve UpdateJob çalıştırılmalı.

Model olarak Order isminde bir tablo kullandım.

| Column Name | Data Types | Allow Nulls |
| :---: | :---: | :---: |
| Id | int |  |
| InsertionTime | datetime | + |
| Status | nvchar(50) | + |


![patika_hangfire](https://user-images.githubusercontent.com/33669453/151600694-8f353bbb-2bfb-416c-b178-f6e1c964a055.png)


![dashboard](https://user-images.githubusercontent.com/33669453/151600703-720536b3-15a8-4beb-9eea-4fe29c49127f.png)
