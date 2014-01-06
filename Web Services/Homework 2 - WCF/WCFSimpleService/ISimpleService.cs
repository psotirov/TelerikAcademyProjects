using System;
using System.ServiceModel;

namespace WCFSimpleService
{
    [ServiceContract]
    public interface ISimpleService
    {
        [OperationContract]
        string GetDayOfWeekInBulgarian(DateTime value);
    }
}
