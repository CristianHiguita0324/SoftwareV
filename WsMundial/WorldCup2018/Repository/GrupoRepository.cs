using Newtonsoft.Json;
using Org.Apache.Http.Protocol;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorldCup2018.Model;

namespace WorldCup2018.Repository
{
    class GrupoRepository
    {
        public async Task<string> AddGroupAsync(string url, Grupo grupo)
        {
            //Serializar el Grupo en Json
            string GrupoJson = JsonConvert.SerializeObject(grupo);
            HttpContent content = new StringContent(GrupoJson, Encoding.UTF8, "application/json");
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage rta = await cliente.PostAsync(url, content);
                // HttpResponseMessage rta1 = await cliente.GetAsync(url);
                if (rta.IsSuccessStatusCode)
                {
                    string rtaMessage = await rta.Content.ReadAsStringAsync();
                    return "Se guardo correctamente"+ rtaMessage;
                }
                else
                    return "Error al guardar";
               
            }
        }
    }
}