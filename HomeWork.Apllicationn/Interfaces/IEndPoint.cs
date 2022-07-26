using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Entities;
using HomeWork.Controller;

namespace HomeWork.Interfaces
{
    public interface IEndPoint
    {
        void create(string serialNumber, EMeterModel MeterModel, int meterNumber, string firmwareVersion, EState state);
        EndPoint search(string serialNumber);
        void delete(string serialNumber);
        List<EndPoint> read(string serialNumber = null);
        void update(string serialNumber, EState state);

    }
}
