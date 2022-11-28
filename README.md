# RiseTech.PhoneBook

Kullanılan Teknolojiler
- .NetCore 3.1 WebApi & Class Library
- .Net7 (Console App)
- PostgreSql(Npgsql) kurulu olmalıdır.
- RabbitMQ kurulu olmalıdır.
- Entity Framework Core

Nasıl Çalışır?
- RiseTech.Services projesinde appsettings.json dosyasında 'ContactDb' connection bilgisini düzenleyin.
- RiseTech.Consumer projesinde Program.cs dosyasında bulunan connection bilgisini düzenleyin.
- Bu 2 projeyi Debug>Start New Instance seçeneği ile ayağa kaldırın.
- RiseTech.Services projesi swagger arayüzü ile servislere çağrı yapmanızı kolaylaştıracaktır.
- RiseTech.Consumer projesi ile RabbitMQ kuyruğuna gelen ve cevaplanan bilgileri görebilirsiniz.

