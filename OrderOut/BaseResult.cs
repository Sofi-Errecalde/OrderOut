namespace OrderOut.BaseResult
{

    public class BaseResult<T>
    {
        public bool Success { get; protected set; }

        public Dictionary<string, string> Errors { get; protected set; }

        public T Content { get; protected set; }

        public BaseResult(T response)
        {
            Success = true;
            Content = response;
        }

        public BaseResult(string error)
        {
            Success = false;
            Errors = new Dictionary<string, string> { { "error", error } };
        }

        public BaseResult(bool succ, T content)
        {
            Success = succ;
            Content = content;
        }

        public BaseResult(Dictionary<string, string> error)
        {
            Success = false;
            Errors = error;
        }
    }
}