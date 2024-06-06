using System.Text;
using System.Threading.Tasks;
namespace BrawlHelper.Models
{
    public class PostStas
    {
        public class Player1
        {
            public string Name { get; set; }
            public string Tag { get; set; }
            public int Trophies { get; set; }
            public int ExpLevel { get; set; }
            public int ExpPoints { get; set; }
            public int HighestTrophies { get; set; }
            public int PowerPlayPoints { get; set; }
            public int HighestPowerPlayPoints { get; set; }
            public int SoloVictories { get; set; }
            public int DuoVictories { get; set; }
            public int BestRoboRumbleTime { get; set; }
            public int BestTimeAsBigBrawler { get; set; }
        }
    }
}
