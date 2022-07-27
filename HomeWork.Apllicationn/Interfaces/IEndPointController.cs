using HomeWork.Entities;
using System.Collections.Generic;

namespace HomeWork.Interfaces
{
    public interface IEndPointController
    {
        void Create(string serialNumber, EMeterModel MeterModel, int meterNumber, string firmwareVersion, EState state);
        EndPoint Search(string serialNumber);
        void Delete(string serialNumber);
        List<EndPoint> Read(string serialNumber = null);
        void Update(string serialNumber, EState state);
    }
}
