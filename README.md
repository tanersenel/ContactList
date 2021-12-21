# Mikroservice mimarisi ile Telefon Rehberi Uygulaması

Proje Çoklu Mikroservice mimarısi ile telefon rehberi oluşturulmasını ve raporlanmasını sağlamaktadır. 
Proje tüm katmanları dockerize edilmiş ve docker-compose dosyaları eklenmiştir. 
RabbitMQ, MongoDB ve diğer tüm servisler docker üzerinde çalışmaktadır.

Projeyi docker üzerinde ayağa kaldırmak için aşağıdaki komut kullanılır. 

    docker-compose  -f "docker-compose.yml" -f "docker-compose.override.yml" up -d

Projede Kullanılan kütüphane ve paketler

 - MongoDB 
 - RabbitMQ 
 - AutoMapper 
 - SignalR
 - Ocelot

# Servisler

Projede 4 farklı mikroservis kullanılmıştır. 

	Contactlist.Contacts
	Contactlist.Reporting
	Contactlist.WebApp
	Contactlist.ApiGateway


## Contactlist.Contacts
.NetCore web api 
Rehbere ekleme düzenleme ve silme işlemlerinin yapıldığı servistir.
Bu kaymanda yapılan kayırlar  MongoDB üzerinde turulmaktadır.
http://localhost:8000/swagger/index.html   adresinden erişilmektedir.


## Contactlist.Reporting

.NetCore WebApi
İstenen konum bazlı raporun oluşturularak kuyrupa alınması ve RabbitMq yardımıyla WebApp'e iletilmesi işlemi yapılmaktadır.
Bu serviste ayrıca SignalR ile WebApp e anlık datanın gönderilerek ön yüzde gösterilmesi sağlanmıştır. 
http://localhost:8001/swagger/index.html   adresinden erişilmektedir.

## Contactlist.ApiGateway

.NetCore blank proje olarak oluşturulmuştur. Ocelot Kütüphanesi ile diğer tüm web api projelerinin tek bir url üzerinden erişilebilir olması amaçlanmıştır. Bu sayede geliştirme yapacak geliştiriciye tek bir url iletilmesi yeterlidir. 
Proje içerisinde yer alan ocelot.js de tüm maplemeler görülebilir.
http://localhost:5000 adresinden erişilmektedir.


## Contactlist.WebApp

AspNetCore web projesidir. 
Raporların oluşturulması ve anlık olarak durumlarının görüntülenmesi bu uygulama üzerinden yapılabilir.
Servisler tarafından RabbitMQ ile produce edilen mesajlar bu katmanda comsume edilerek okunabilir. 
Ayrıca Reporting servisinde oluşturulan ve tamanlanan rapor bilgisi bu uygulamaya SignalR ile anlık olarak gönderilerek anasayfada listelenmesi sağlanmıştır.
http://localhost:8001/ adresinden erişilmektedir.

