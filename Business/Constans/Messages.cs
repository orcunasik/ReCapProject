using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarListed = "Araçlar Listelendi";
        public static string CarUnitPriceInValid = "Fiyat 0 dan büyük olmaldır";
        public static string CarDeleted = "Araç tablodan kaldırıldı";
        public static string CarUpdated = "Araç bilgisi güncellendi";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandInValid = "Marka bilgisi Eklenemedi, Lütfen en az 2 karakter giriniz";
        public static string BrandDeleted = "Marka bilgisi silindi";
        public static string BrandUpdated = "Marka bilgisi güncellendi";
        public static string BrandLİsted = "Marka bilgileri listelendi";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorInValid = "Renk bilgisi Eklenemedi";
        public static string ColorDeleted = "Renk bilgisi silindi";
        public static string ColorUpdated = "Renk bilgisi güncellendi";
        public static string ColorLİsted = "Renk bilgileri listelendi";

        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserLİsted = "Kullanıcı bilgileri listelendi";
        public static string UserDeleted = "Kullanıcı bilgisi silindi";
        public static string UserUpdated = "Kullanıcı bilgisi güncellendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerListed = "Müşteri bilgileri listelendi";
        public static string CustomerDeleted = "Müşteri bilgisi silindi";
        public static string CustomerUpdated = "Müşteri bilgisi güncellendi";

        public static string RentalAdded = "Araç kiralandı";
        public static string RentalLİsted = "Kiralanan Araçlar listelendi";
        public static string RentalInValid = "Araç kiralanamaz, teslim edilmesi bekleniyor";
        public static string RentalDeleted = "Araca ait kiralama düşüldü";
        public static string RentalUpdated = "Araç kiralama bilgisi güncellendi";
        public static string RentalUpdatedReturnDate = "Arac teslim alındı";
        public static string RentalReturnDateError = "Aracın daha önce teslim alınmış";

        public static string MaintenanceTime = "Sistem Bakımdadır";
        public static string FailAddedImageLimit = "Bir araca ait resim sayısı aşıldı";
        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImageUpdated = "Araç Resmi Güncellendi";
    }
}
