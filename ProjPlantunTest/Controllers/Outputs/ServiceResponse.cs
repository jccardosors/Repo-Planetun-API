namespace ProjPlantunTest.Controllers.Outputs
{
    public class ServiceResponse<T> : StatusResult
    {
        public ServiceResponse()
        {
        }

        public T Result { get; set; }

        public ServiceResponse(bool statusOk, List<string> errorMessages) : base(statusOk, errorMessages)
        {
        }

        public static ServiceResponse<T> Success(T result)
        {
            return new ServiceResponse<T>
            {
                StatusOk = true,
                Result = result
            };
        }

        public static ServiceResponse<T> Failure(string error) => Failure(new List<string> { error });

        public static ServiceResponse<T> Failure(List<string> errors) => new ServiceResponse<T>(statusOk: false, errorMessages: errors);
    }
}

