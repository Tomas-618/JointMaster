namespace Pools.Interfaces
{
    public interface IPoolReleaser<T> where T : class
    {
        void Release(T element);
    }
}