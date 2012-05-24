using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void AddDirectoryEntry(DirectoryEntry entry);

        [OperationContract]
        List<DirectoryEntry> GetDirectoryEntries();

        [OperationContract]
        DirectoryEntry GetDirectoryEntry(string firstName, string lastName);

        [OperationContract]
        void RemoveDirectoryEntry(string firstName, string lastName);
    }


    [DataContract]
    public class DirectoryEntry
    {
        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName;

        [DataMember]
        public string PhoneNumber;

        [DataMember]
        public string Address;
    }
}
