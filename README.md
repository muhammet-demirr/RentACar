# Rent A Car
Bu proje de Rent a car yani araba kiralama sitesi geliştirdim. ASP.NET MVC ve ASP.NET Core ile C# kullanarak backend yazdım, veri erişimi için Entity Framework kullandım. Veri tabanı olarak PostgreSQL ve MSSQL tercih ettim. Frontend'de Bootstrap ve jQuery kullandım. Projenin versiyon kontrolünü Git ve GitHub ile sağladım.

## Proje İle İlgili Detaylar

### Giriş Ekranı

Ekranda, şirket logosu ve kullanıcıların rahatlıkla kullanabileceği bir navigasyon menüsü bulunuyor. Bu menüde ana sayfa, hizmetlerimiz, araçlarımız, hakkımızda, referanslarımız ve iletişim gibi başlıklar yer almakta. Ekranın sağ üst köşesinde dil seçeneği mevcut, bu da kullanıcıların farklı dillerde siteyi kullanabilmelerini sağlıyor.

#### Alış ve Bırakış Bilgileri

Giriş ekranının ortasında, kullanıcıların araç kiralama işlemlerini başlatabileceği bir form bulunuyor. Bu formda, aşağıdaki bilgiler isteniyor:

 - Alış Lokasyonu: Kullanıcının aracı alacağı yeri belirtebileceği bir alan.
 - Alış Tarih & Saat: Kullanıcının aracı ne zaman alacağını belirleyebileceği tarih ve saat seçimi.
 - Bırakış Tarih & Saat: Kullanıcının aracı ne zaman geri teslim edeceğini belirleyebileceği tarih ve saat seçimi.
 - Bırakacağım Konum: Kullanıcı isterse aracını farklı bir konumda bırakabileceğini belirtebileceği bir seçenek.
 - Formun altında, kullanıcının araç listesini görüntüleyebilmesi için büyük, turuncu bir "ARAÇ LİSTELE" butonu yer almakta.

#### Arka Plan ve Görsellik

Görsel olarak, ekranda şık bir araba ve iş adamı görselleri bulunuyor, bu da sitenin profesyonel bir hizmet sunduğunu vurguluyor.

![giriş](https://github.com/user-attachments/assets/11ff181c-fb3d-4d74-bcf3-4378a8d71461)

### İletişim Ekranı

Ekranda iletşiim ile ilgili kısmı görmektesiniz.

![İletişim](https://github.com/user-attachments/assets/b8a7bb4c-43bc-47cf-a2ca-a33624352a96)


### Araç Rezervasyon Ekranı

#### Teknik Detaylar:

#### Kullanılan Teknolojiler:

#### ASP.NET:

Framework: ASP.NET Core, yüksek performanslı ve hafif bir framework olup, bulut tabanlı veya on-premises uygulamaları için idealdir.
MVC Pattern: Model-View-Controller (MVC) deseni, uygulamanın geliştirilmesi, test edilmesi ve bakımının yapılmasını kolaylaştırır.
Razor Pages: Sayfaların dinamik olarak oluşturulması için Razor motoru kullanılır, bu da HTML ve C# kodlarının bir arada kullanılabilmesini sağlar.

#### PostgreSQL:

Veritabanı Yönetim Sistemi (DBMS): PostgreSQL, açık kaynaklı ve güçlü bir veritabanı sistemidir. Büyük veri işlemleri ve karmaşık sorgular için idealdir.
Entity Framework Core: ASP.NET Core ile uyumlu olan Entity Framework Core, veritabanı işlemlerini nesne yönelimli bir şekilde yönetmenizi sağlar.

#### Ekran Detayları:

#### Araç Bilgileri:

Araç Modeli ve Yılı: Örneğin, "2020 Renault Symbol 0.9 TCe Joy Symbol".
Vites Türü, Yakıt Türü, Teminat, Toplam KM, Kişi Sayısı, Kapı Sayısı, Bagaj Kapasitesi, Klima: Her araç için detaylı özellikler listelenmiştir.

#### Fiyatlandırma:

Günlük Fiyat: Her araç için günlük kiralama ücreti belirtilmiştir.
Toplam Tutar: Kullanıcıların seçtiği süreye göre toplam tutar hesaplanmaktadır.

#### Kullanıcı İşlemleri:

Dahil Hizmetler Butonu: Kiralamaya dahil olan hizmetlerin detaylarını gösterir.
Hemen Kirala Butonu: Kullanıcıların hızlıca araç kiralama işlemini başlatmalarını sağlar.

![AraçRezervasyon](https://github.com/user-attachments/assets/76d2cdc1-15d0-4242-af45-8773cfcb82ba)

![rezervasyonson](https://github.com/user-attachments/assets/84d7e81c-67cb-44d3-8235-6e34fb9f6281)

#### Sonuç
Bu detaylar, ASP.NET Core ve PostgreSQL kullanarak oluşturduğunuz Araç Rezervasyon ekranının nasıl yapılandırıldığını ve geliştirildiğini açıklar. Bu yapı, kullanıcıların araç kiralama sürecini kolay ve hızlı bir şekilde tamamlamalarını sağlar. Herhangi bir sorunuz olursa veya eklemek istediğiniz başka detaylar varsa, lütfen bildirin.

### Admin Ekranı Ekranı

#### Admin Giriş Ekranı

![admingiriş](https://github.com/user-attachments/assets/90ce20c5-99ae-4c4b-90d6-b99fb99d6992)

#### Admin Ana Ekranı

![AdminAnaekran](https://github.com/user-attachments/assets/d4a8724b-33ec-401c-b5a3-c4d2946559c6)

![Adminlokasyon](https://github.com/user-attachments/assets/3ca5b763-7b54-4156-acb3-a24116379c44)

![Adminrezarvasyon](https://github.com/user-attachments/assets/bf51af10-96dc-43b2-9ddd-167db66d20d1)

### Proje Yapısı ve Katmanlar

![Proje Yapım](https://github.com/user-attachments/assets/9c78aff6-7cb0-4d8b-8ccd-c1076e4a9840)

Projeniz üç ana katmana ayrılmış: Core (Çekirdek), Infrastructure (Altyapı) ve Presentation (Sunum). Bu yapı, kodun modülerliğini, okunabilirliğini ve bakımını kolaylaştırır.

#### 1. Core (Çekirdek)

Bu katman, iş mantığınızı ve domain modellerinizi içerir.

RentACar.Application

- Bağımlılıklar (Dependencies): Bu klasör, uygulama katmanındaki bağımlılıkları yönetmek için kullanılır.
- CustomExceptions (Özel İstisnalar): Uygulama özel istisnalarınızı tanımladığınız klasör.
- DTOs (Data Transfer Objects): Verilerin taşınması için kullanılan nesneler.
- IServices: Hizmet arayüzleri. Uygulama içinde kullanılacak hizmetlerin tanımları burada yer alır.
- ResponseModels (Yanıt Modelleri): API veya servis yanıtları için kullanılan modeller.
- Validators (Doğrulayıcılar): Verilerin doğrulanması için kullanılan sınıflar.
- 
RentACar.Domain

- Bağımlılıklar (Dependencies): Domain katmanındaki bağımlılıkları yönetmek için kullanılır.
- Enums (Sabitler): Projede kullanılan sabit değerler (enum) burada tanımlanır.
- Mappings (Eşlemeler): Veri eşlemeleri için kullanılan sınıflar.
- Models (Modeller): Domain modelleri, iş mantığınızın çekirdeğini oluşturur.

#### 2. Infrastructure (Altyapı)

Bu katman, veritabanı erişimi ve diğer dış bağımlılıkların yönetimini içerir.

- RentACar.Infrastructure: Genel altyapı kodları.
- RentACar.Persistence: Veritabanı işlemleri ve ORM (Object-Relational Mapping) yapılandırmaları.

#### 3. Presentation (Sunum)

Bu katman, kullanıcıya sunulan arayüzler ve API'leri içerir.

- RentACar.Client: Kullanıcı arayüzü ile ilgili kodlar (muhtemelen bir web veya mobil arayüz).
- RentACar.Server: API'lerin ve sunucu tarafı işlemlerinin yönetildiği katman.
