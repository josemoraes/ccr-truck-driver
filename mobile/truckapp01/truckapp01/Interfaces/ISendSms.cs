using System;
namespace truckapp01.Interfaces
{
    public interface ISendSms
    {
        void SendSms(string number, string message);
    }
}
