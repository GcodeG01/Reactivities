namespace Application.Core
{
    public class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static Result<T> Success(T value) => new Result<T> {IsSuccess = true, Value = value};
        public static Result<T> Failure(string error) => new Result<T> {IsSuccess = false, Error = error};
    }
}

// const IsSuccess: bool;
// const Value: T;
// const Error: string;

// export const Success = (value: T) => {
//     return {IsSucess = true, Value = value}
// }

// export const Failure = (error: string) => {
//     return {IsSuccess = false, Error = error}
// }