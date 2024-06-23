namespace pdksApi.Core.Utilities.Messages
{
    public class Message
    {
        public static string IsOk = "İşlem başarılı";
        public const string Added = "Kayıt işlemi basarılı bir sekilde gercekleşti";
        public const string Updated = "Güncelleme işlemi basarılı bir sekilde gercekleşti";
        public const string Deleted = "Silme işlemi basarılı bir sekilde gercekleşti";
        public const string NotFoundSystem = "Sistemde aradıgınız data bulunamadı";
        public const string Error = "Sistemde hata oluştu!";
        public const string SelectRecord = "Lütfen değer şeçiniz!";
        public const string SameRecord = "Bu kayıt sistemde mevcuttur. Farklı data giriniz";
        public const string CancelledCard = "Bu isimde kart daha önce sistemden iptal edilmiştir. Farklı bir isim giriniz";
        
        public const string SameVisitRecord = "Bu kişiye ait sistemde aktif kayıt mevcuttur. Farklı kimlik bilgisi giriniz";
        public const string EmailError = "Email adresi dogrulanamadı";
        public const string UserNotFound = "Kullanıcı adı yada Şifre bilgisi doğrulanamadı!";
        public const string NullData = "Lütfen eksik bilgi girişi bırakmayınız!";
       
    }
}
