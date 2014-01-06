using System;
using System.ServiceModel;

namespace WCFStringCompare
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IStringCount
    {
        [OperationContract]
        int GetSubstringCount(string input, string substring);
    }
}
