namespace Hepsiburada.MarsRover.Core.CustomException
{
    public class BusinessException : BaseException
    {
        public BusinessException()
        {

        }

        public BusinessException(int errorCode) : base(errorCode)
        {

        }

        public BusinessException(string message) : base(message)
        {

        }
    }
}
