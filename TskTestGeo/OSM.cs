
namespace TskTestGeo
{
   public class OSM
    {
        public string GetUrl(string address)
        {
            return $"https://nominatim.openstreetmap.org/search?q={address}&format=json&polygon_geojson=1";
        }
    }
}
