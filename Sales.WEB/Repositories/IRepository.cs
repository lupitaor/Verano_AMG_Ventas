namespace Sales.WEB.Repositories
{
    public interface IRepository
    {
        //Método Get
        Task<HttpResponseWrapper<T>> Get<T>(string url);

        //Método Post
        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);
        //Método Post que devuelve respuesta
        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);

        //Método Delete
        Task<HttpResponseWrapper<Object>> Delete(string url);


        //Método Put
        Task<HttpResponseWrapper<Object>> Put<T>(string url, T model);
        //Método Put que devuelve respuesta
        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);

    }
}
