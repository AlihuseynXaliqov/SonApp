namespace SonMVCApp.Areas.Manage.Helpers.Exception
{
    public class NotFoundException<T>:System.Exception where T:class,new()
    {
        public NotFoundException(string message) : base(message) { }
        public NotFoundException():base(  $"{typeof(T).Name} Tapilmadi") { }
    }
}
