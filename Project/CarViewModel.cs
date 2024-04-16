using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CarViewModel
    {
        private long _CarNo;

        private string _ModelName;

        private string _Name;

        private double _Price;

        private int _Quantity;

        public long CarNo
        {
            get
            {
                return _CarNo;
            }

            set
            {
                _CarNo = value;
            }
        }

        public string ModelName
        {
            get
            {
                return _ModelName;
            }

            set
            {
                _ModelName = value;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        public double Price
        {
            get
            {
                return _Price;
            }

            set
            {
                _Price = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _Quantity;
            }

            set
            {
                _Quantity = value;
            }
        }
    }
}
