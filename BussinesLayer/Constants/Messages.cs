using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Constants
{
    public class Messages
    {
        public const string Added = "Eklendi";
        public const string Deleten = "Silindi";
        public const string Updated = "Güncellendi";
        public const string Listed = "Listelendi";

        public const string NotListed = "Listelenmedi"; 
        public const string ErrorListed = "Listenirken Hata Oluştu"; 
        public const string UserNotFound = "Kullanıcı Bulunamadı";
        public const string SuccessLogin = "Kullanıcı Başarılı bir şekilde giriş yaptı";
        public const string ErrorLogin = "Kullanıcı Login Yapamadı";
    }
}
