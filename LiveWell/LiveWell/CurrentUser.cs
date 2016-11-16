using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveWell
{
    class CurrentUser
    {
        private static int userType = 4;
        private static int userID;

        public static int type
        {
            get
            {
                return userType;
            }
            set
            {
                userType = value;
            }
        }

        public static int ID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }
    }
}
