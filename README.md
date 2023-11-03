# Rehber Kaydı ve Raporlama
* Rehbere isim, soyisim ve şirket bilgileriyle kişi oluşturup, oluşturduğu kişiye telefon numarası, e-posta adresi ve konum eklenmesini ve bu bilgileri kullanarak konuma göre rehberde kaç kişi kayıtlı ve kayıtlı kişilerin kaç tanesinin telefon numarası var şeklinde raporlanmasını sağlamıştır.
* 2 adet API web servisi, 1 adet .NET Core MVC ve 1 adet Azure Function kullanılarak ServiceBus ile QueueTriger oluşmaktadır. 
* Message Broker ve API aracılığıyla haberleşme sağlanmıştır.

## Kurulum
* Proje ayağa kaldırılırken ContactAPI ve ContactReportAPI ile database otomatik migrate edilir.

`ContactsAPI:` .NET Core Web API Micro Service Mimari kullanılarak EntityFrameworkCore ORM ile kişi kayıt eder, listeler, siler ve günceller.

`ContactsReportAPI:` 
* .NET Core Web API Micro Service Mimari kullanılarak kayıt edilen kişiye EntityFrameworkCore ORM ile telefon, e-post adresi ve konum gibi verileri eklemeye ve güncelleme işlemi yapar. 
* Azure Function: ServiceBus Queuetrigger ile oluşturulması istenen raporu Dapper Micro ORM kullanılarak raporu oluşturur ve ilgili API ile iletişim kurar.

`WebUI:` 
* ASP.Net CORE MVC kullanılarak kullanıcının kayıt listeleme, ekleme, güncelleme ve silme gibi işlemları yapabileceği arayüzdür. 
* WebUI web request ile ContactsAPI ve ContactsReportAPI bağlantıya geçerek API tarafında gelen istekleri EntityFrameworkCore aracılığıyla Postgresql database ile bağlantı kurarak ilgili işlemleri yapar ve gereken sonucu WebUI'a döner.

### Endpoints
* `WebUI:` https://localhost:6001
* `ContactAPI:` https://localhost:6002
* `ContactReportAPI:` https://localhost:6003