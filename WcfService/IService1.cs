using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // 1- WebService'leri mutlaka bir IIS Server üzerinde host edilmelidir, yoksa çalışmaz.
    // 1-1- WCF servislerinin IIS Server'ındada host edilebilir, bir masaüstü bilgisayarındada host edilebilir ve çalıştırılabilir.

    // 2- WebService'lerinde gidip/gelen (client ile service arasında gidip gelen) bütün nesneler serileştirilebilmelidir.
    // 2-1- WCF Service'lerinde client ile service arasında gidip/gelen nesneler XML nesneleri de olabilir, JSON nesneleri de olabilir, başka herhangi bir nesne tipi de olabilir.

    // 3- WebService'lerini kullanan sistemlerde C# kodu yazmak gerekir.
    // 3-1- Gidip gelen nesnelerin JSON nesnesi olduğu belirtildiği zaman C# kodu yazmadan WCF servisine bağlanılabilir ve JQuery kodları ile servisten veri çekilip gönderilebilir.

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.

    [ServiceContract]
    //IService1'den türeyen Service1.svc servisi IService1 isimli bir sözleşme ile kullanıma açılmıştır.
    //WCF'te bütün servislerin arka planında bir interface vardır ve bütün servis sınıfları interface'den türetilir.
    public interface IService1
    {

        [OperationContract]
        //Üzerinde OperationContract yazmayan methodlar sözleşmeye dahil edilmez, sözleşmeye dahil edilmez ise client tarafından o method'a ulaşılamaz.
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
