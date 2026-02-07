namespace Homework2.Application
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<TResult>
    {
        TResult Execute();
    }
}