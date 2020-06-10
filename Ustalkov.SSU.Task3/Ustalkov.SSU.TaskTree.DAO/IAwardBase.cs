using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;

namespace Ustalkov.SSU.Task3.DAO
{
    public interface IAwardBase
    {
        string DeleteAward(int awardId);
        string InsertIntoAward(string awardTitle);
        List<Award> SelectAward();
    }
}
