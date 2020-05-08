using System;

namespace Hepsiburada.MarsRover.Core.CustomException
{
    public abstract class BaseException : Exception
    {
        public BaseException()
        {

        }

        public BaseException(string message) : base(message)
        {

        }

        public BaseException(int errorCode) : base(errorCode.ToString())
        {

        }
    }
}
