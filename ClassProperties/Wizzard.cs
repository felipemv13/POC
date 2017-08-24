using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProperties
{
    class Wizzard
    {
        public int mAge = 0;

        public int GetAge()
        {
            return mAge;
        }

        public void SetAge(int nAge)
        {
            mAge = nAge;
        }

        // outra maneira de fazer
        public int Age
        {
            get
            {
                return mAge;
            }
            set
            {
                if (value > 200)
                    mAge = 200;
                else
                    mAge = value;
            }
        }
    }
}
