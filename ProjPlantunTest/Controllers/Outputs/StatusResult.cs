using System.Net;

namespace ProjPlantunTest.Controllers.Outputs
{
    public class StatusResult
    {
        public StatusResult()
        {
        }

        public StatusResult(bool statusOk, List<string> errorMessages)
        {
            StatusOk = statusOk;
            ErrorMessages = errorMessages;
        }

        public bool StatusOk { get; set; }

        public string ErrorCode { get; set; }

        public List<string> ErrorMessages { get; set; } = new List<string>();

        public HttpStatusCode HttpStatusCode { get; set; }

        public string StackTraceError { get; set; }
    }
}
