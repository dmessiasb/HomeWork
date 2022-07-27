using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Entities;
using HomeWork.Interfaces;

namespace HomeWork.Application
{

    public class EndPointController : IEndPointController
    {
        internal static List<EndPoint> listEndPoint = new List<EndPoint>();

        public void Create(string serialNumber, EMeterModel meterModel, int meterNumber, string firmwareVersion, EState state)
        {
            EndPoint newEndPoint = new EndPoint();
            newEndPoint.serialNumber = serialNumber;
            newEndPoint.meterModel = meterModel;
            newEndPoint.meterNumber = Convert.ToInt32(meterNumber);
            newEndPoint.firmwareVersion = firmwareVersion;
            newEndPoint.State = state;

            listEndPoint.Add(newEndPoint);
        }
        public List<EndPoint> Read(string serialNumber = null)
        {
            List<EndPoint> _listEndPoint = listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null).ToList();

            return _listEndPoint;
        }
        public void Delete(string serialNumber)
        {
            listEndPoint.RemoveAll(x => x.serialNumber == serialNumber);
        }
        public void Update(string serialNumber, EState state)
        {
            foreach (var endPoint in listEndPoint.Where(x => x.serialNumber == serialNumber))
            {
                endPoint.State = state;
            }
        }
        public EndPoint Search(string serialNumber)
        {
            EndPoint endPoint = Read(serialNumber).FirstOrDefault();

            return endPoint;
        }
    }
}
