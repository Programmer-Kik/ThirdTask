using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.BL
{
    public interface IAwardLogic
    {
        string DeleteAward(int awardId);
        string InsertIntoAward(string awardTitle);
        List<Award> SelectAward();
    }
}
