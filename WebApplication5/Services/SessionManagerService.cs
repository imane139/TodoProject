using System.Collections.Generic;
using System.Text.Json;
using WebApplication5.Models;

namespace WebApplication5.Services
{
    public class SessionManagerService : ISessionManagerService
    {
        public void Add(string key, object list , HttpContext context)
        {
            string chaine = JsonSerializer.Serialize(list);
            context.Session.SetString(key, chaine);

        }

        public T Get<T>(string key, HttpContext context)
        {

            var json = context.Session.GetString(key);
            if (string.IsNullOrEmpty(json))
            {
                return default(T); // retourne null pour les classes, 0 pour les types valeur
            }
            return JsonSerializer.Deserialize<T>(json);

        }
    }
}
