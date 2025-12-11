namespace WebApplication5.Services
{
    public interface ISessionManagerService
    {
        public T Get<T>(string key, HttpContext context);
        public void Add(string key, object list, HttpContext context);
        

    }
}
