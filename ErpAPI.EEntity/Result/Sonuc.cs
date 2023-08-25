using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace ErpAPI.EEntity.Result
{
    public class Sonuc<T>
    {
        public Sonuc(T _data, string _mesaj, int _statusCode, HataBilgisi _hataBilgisi)
        {
            Data = _data;
            Mesaj = _mesaj;
            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }

        public Sonuc(string _mesaj, int _statusCode, HataBilgisi _hataBilgisi)
        {

            Mesaj = _mesaj;
            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }
        public Sonuc(int _statusCode, HataBilgisi _hataBilgisi)
        {


            StatusCode = _statusCode;
            HataBilgisi = _hataBilgisi;
        }

        public T Data { get; set; }
        public string Mesaj { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }
        public HataBilgisi HataBilgisi { get; set; }

        public static Sonuc<T> SuccesWithData(T data, string message = "İşlem Başarılı",
            int statusCode = (int)HttpStatusCode.OK)
        {
            return new Sonuc<T>(data, message, statusCode, null);
        }
        public static Sonuc<T> SuccesWithoutData(string message = "İşlem Başarılı",
            int statusCode = (int)HttpStatusCode.OK)
        {
             return new Sonuc<T>(message, statusCode, null);
            
        }

        public static Sonuc<T> SuccesNoDataFound(int statusCode = (int)HttpStatusCode.NotFound)
        {
            return new Sonuc<T>("Sonuç Bulunamadı", statusCode, HataBilgisi.NotFound());
        }

        public static Sonuc<T> FieldValidationError(HataBilgisi hataBilgisi, int statusCode = (int)HttpStatusCode.BadRequest)
        {
            return new Sonuc<T>("Hata Oluştutu", statusCode, HataBilgisi.NotFound());
        }

        public static Sonuc<T> TokenNotFound()
        {
            return new Sonuc<T>("Hata Oluştu", (int)HttpStatusCode.Unauthorized, HataBilgisi.TokenNotFoundError());
        }

        public static object TokenValidationError()
        {
            throw new NotImplementedException();
        }

        public static object Error()
        {
            throw new NotImplementedException();
        }
    }
}
