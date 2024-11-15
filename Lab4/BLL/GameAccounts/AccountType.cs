using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4.BLL.GameAccounts
{
    public enum AccountType
    {
        [TypeAttribute<StandardAccount>]
        Standard,
        [TypeAttribute<HalfLossPointsAccount>]
        HalfLossPoints,
        [TypeAttribute<BonusWinStreakAccount>]
        BonusWinStreak,
    }
}
