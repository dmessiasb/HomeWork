using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork.Entities;
using HomeWork.Interfaces;

namespace HomeWork.Controller
{

    public class EndPointController : IEndPoint
    {
        internal static List<EndPoint> listEndPoint = new List<EndPoint>();

        public void create(string serialNumber, EMeterModel meterModel, int meterNumber, string firmwareVersion, EState state)
        {

            EndPoint newEndPoint = new EndPoint();
            newEndPoint.serialNumber = serialNumber;
            newEndPoint.meterModel = meterModel;
            newEndPoint.meterNumber = Convert.ToInt32(meterNumber);
            newEndPoint.firmwareVersion = firmwareVersion;
            newEndPoint.State = state;

            listEndPoint.Add(newEndPoint);


        }
        public List<EndPoint> read(string serialNumber = null)
        {
            List<EndPoint> _listEndPoint = listEndPoint.Where(x => x.serialNumber == serialNumber || serialNumber == null).ToList();

            return _listEndPoint;
        }
        public void delete(string serialNumber)
        {
            listEndPoint.RemoveAll(x => x.serialNumber == serialNumber);
        }
        public void update(string serialNumber, EState state)
        {
            foreach (var item in listEndPoint.Where(x => x.serialNumber == serialNumber))
            {
                item.State = state;
            }
        }
        public EndPoint search(string serialNumber)
        {
            EndPoint endPoint = read(serialNumber).FirstOrDefault();

            return endPoint;
        }
    }
}
