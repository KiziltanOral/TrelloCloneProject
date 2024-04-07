namespace TrelloClone.Core.Results.Interfaces
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
