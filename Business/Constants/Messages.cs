using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalıd = "Ürün ismi geçersiz";
        public static string ProductsListed = "Ürünler listelendi";
        public static string MaintenanceTime="Bakım zamanı";
        public static string ProductCountOfCategoryError = "Bir kategoriden en fazla 15 adet ürün eklenebilir";
        public static string ProductNameAlreadyExist = "Bu isimde kayıtlı başka bir ürün mevcut";
        public static string CategoryLimitExceded = "Kategori limiti aşıldığı için yeni ürün eklenemiyor";
    }
}
