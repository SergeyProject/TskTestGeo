
namespace TskTestGeo
{
    public class UserAgent
    {
        string userGC = "User-Agent:Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.198 Safari/537.36";
        string userMF = "User-Agent:Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:83.0) Gecko/20100101 Firefox/83.0";
        string userOp = "User-Agent:Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.43 (KHTML, like Gecko) Chrome/86.0.4240.183 Safari/537.36 OPR/72.0.3815.320";

        public string GetAgent(Agent agent)
        {
            switch (agent)
            {
                case Agent.Chrome:
                    return userGC;

                case Agent.Mozilla:
                    return userMF;

                case Agent.Opera:
                    return userOp;
            }
            return "MyApp";
        }
    }

    public enum Agent
    {
        Chrome,
        Mozilla,
        Opera
    };
}
