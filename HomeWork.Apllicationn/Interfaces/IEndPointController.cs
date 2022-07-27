using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Entities;
using HomeWork.Application;

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
