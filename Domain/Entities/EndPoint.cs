using System;

namespace HomeWork.Entities
{
    public class EndPoint

    {
        protected EMeterModel metermodel;
        protected int meternumber;
        protected EState state;
        protected string serialnumber;
        protected string firmwareversion;

        public string serialNumber
        {
            get
            {
                return serialnumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                serialnumber = value;
            }
        }
        public EMeterModel meterModel
        {
            get
            {
                return metermodel;
            }
            set
            {
                if (!EMeterModel.IsDefined(typeof(EMeterModel), value))
                    throw new ArgumentOutOfRangeException();
                metermodel = value;
            }
        }
        public int meterNumber
        {
            get
            {
                return meternumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                meternumber = value;
            }


        }
        public string firmwareVersion
        {
            get
            {
                return firmwareversion;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                firmwareversion = value;
            }
        }
        public EState State
        {
            get
            {
                return state;
            }
            set
            {
                if (!EState.IsDefined(typeof(EState), value))
                    throw new ArgumentOutOfRangeException();
                state = value;
            }
        }


    }
}
