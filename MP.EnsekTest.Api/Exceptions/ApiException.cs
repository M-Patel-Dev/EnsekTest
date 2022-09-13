namespace MP.EnsekTest.Api.Exceptions
{
    [Serializable]
    public class ApiException : Exception
    {
        private const string ApiExceptionMessage = "An error was encountered whilst initialising the API, check inner exception for details";
        public ApiException() : base(ConstructMessage()) { }
        public ApiException(string message) : base(ConstructMessage(message)) { }
        public ApiException(string message, Exception inner) : base(ConstructMessage(message), inner) { }
        protected ApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        private static string ConstructMessage(string? innerMessage = null)
        {
            return $"{ApiExceptionMessage}, {innerMessage}";
        }
    }
}

