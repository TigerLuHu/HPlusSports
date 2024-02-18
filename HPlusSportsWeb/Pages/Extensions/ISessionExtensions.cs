using Newtonsoft.Json;

namespace HPlusSportsWeb.Pages.Extensions
{
    public static class ISessionExtensions
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            var valueString = JsonConvert.SerializeObject(value);
            session.SetString(key, valueString);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var valueString = session.GetString(key);
            if (string.IsNullOrEmpty(valueString))
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(valueString);
        }
    }
}
