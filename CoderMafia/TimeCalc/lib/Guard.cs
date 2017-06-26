using System;
using System.Diagnostics;

namespace TimeCalc
{
   public  class Guard
    {
        public static void ThrowIfNull(object argumentValue)
        {
            if (argumentValue == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
