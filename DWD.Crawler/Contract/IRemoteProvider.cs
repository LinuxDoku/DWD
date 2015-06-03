namespace DWD.Crawler.Contract {
    public interface IRemoteProvider<T> : IProvider<T> {
        IParser<T> GetParser();
    }
}