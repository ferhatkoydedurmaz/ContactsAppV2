# ContactsApp

Bu proje, Rehber işlevini yerine getirmek için .NET Core kullanarak geliştirilmiş bir uygulamayı içerir.
Microservis mimarisi ile oluşturulmuştur.
2 adet API web servisi, 1 adet .NET Core MVC ve 1 adet Azure Function kullanılarak ServiceBus ile QueueTriger oluşmaktadır. 


ContactsAPI: .NET Core Web API Micro Service Mimari kullanılarak EntityFrameworkCore ORM ile kişi kayıt eder, listeler, siler ve günceller.
ContactsReportAPI: .NET Core Web API Micro Service Mimari kullanılarak kayıt edilen kişiye EntityFrameworkCore ORM ile telefon, e-post adresi ve konum gibi verileri eklemeye ve güncelleme işlemi yapar. 
Azure Function: ServiceBus Queuetrigger ile oluşturulması istenen raporu Dapper Micro ORM kullanılarak raporu oluşturur ve ilgili API ile iletişim kurar.
WebUI: ASP.Net CORE MVC kullanılarak kullanıcının kayıt listeleme, ekleme, güncelleme ve silme gibi işlemları yapabileceği arayüzdür. 

WebUI web request ile ContactsAPI ve ContactsReportAPI bağlantıya geçerek API tarafında gelen istekleri EntityFrameworkCore aracılığıyla Postgresql database ile bağlantı kurarak ilgili işlemleri yapar ve gereken sonucu WebUI'a döner.

# Kurulum

WebUI başlatıldığında database otomatik olarak migrate edilir.
