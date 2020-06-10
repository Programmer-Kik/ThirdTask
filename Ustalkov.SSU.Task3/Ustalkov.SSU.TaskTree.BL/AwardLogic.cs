using System.Collections.Generic;
using Ustalkov.SSU.Task3.Entity;
using Ustalkov.SSU.Task3.DAO;

namespace Ustalkov.SSU.Task3.BL
{
    public class AwardLogic : IAwardLogic
    {
        private IAwardBase awardBase;

        public AwardLogic(IAwardBase awardBase)
        {
            this.awardBase = awardBase;
        }
        public AwardLogic()
        {
            awardBase = new AwardBase();
        }

        public string DeleteAward(int awardId)
        {
            return awardBase.DeleteAward(awardId);
        }

        public string InsertIntoAward(string awardTitle)
        {
            return awardBase.InsertIntoAward(awardTitle);
        }

        public List<Award> SelectAward()
        {
            return awardBase.SelectAward();
        }
    }
}
