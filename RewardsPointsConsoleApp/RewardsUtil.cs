using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RewardsPointsConsoleApp
{
    public class RewardsUtil
    {
        public static List<RewardPoints> CalculateRewardPoints(List<Transaction> transactions)
        {
            return transactions
                .GroupBy(t => new { t.CustomerName, Month = t.TransactionDate.Month })
                .Select(g => new RewardPoints
                {
                    CustomerName = g.Key.CustomerName,
                    Month = g.Key.Month,
                    Points = g.Sum(t => CalculatePoints(t.Amount))
                }).ToList();
        }

        public static int CalculatePoints(decimal amount)
        {
            int points = 0;
            if (amount > 100)
            {
                points += (int)((amount - 100) * 2);
                amount = 100; 
            }
            if (amount > 50)
            {
                points += (int)(amount - 50);
            }
            return points;
        }
    }
}
