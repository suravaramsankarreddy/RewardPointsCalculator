using System;

namespace RewardsPointsConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            // Sample dataset of transactions
            List<Transaction> transactions = new List<Transaction>
        {
            new Transaction { CustomerName = "Veera", TransactionDate = new DateTime(2024, 10, 5), Amount = 120 },
            new Transaction { CustomerName = "Veera", TransactionDate = new DateTime(2024, 10, 15), Amount = 75 },
            new Transaction { CustomerName = "Syed", TransactionDate = new DateTime(2024, 11, 7), Amount = 200 },
            new Transaction { CustomerName = "Veera", TransactionDate = new DateTime(2024, 11, 22), Amount = 50 },
            new Transaction { CustomerName = "Nagendra", TransactionDate = new DateTime(2024, 12, 10), Amount = 130 },
            new Transaction { CustomerName = "Syed", TransactionDate = new DateTime(2024, 12, 15), Amount = 85 }
        };

            // Calculate reward points
            var rewardPoints = RewardsUtil.CalculateRewardPoints(transactions);

            // Display Points Per Month
            Console.WriteLine("Reward Points Per Month:");
            foreach (var reward in rewardPoints.OrderBy(r => r.CustomerName).ThenBy(r => r.Month))
            {
                Console.WriteLine($"Customer: {reward.CustomerName}, Month: {reward.Month}, Points: {reward.Points}");
            }

            // Calculate and display total points per customer
            var totalPoints = rewardPoints
                .GroupBy(r => r.CustomerName)
                .Select(g => new { CustomerName = g.Key, TotalPoints = g.Sum(r => r.Points) });

            Console.WriteLine("\nTotal Reward Points:");
            foreach (var total in totalPoints)
            {
                Console.WriteLine($"Customer: {total.CustomerName}, Total Points: {total.TotalPoints}");
            }
        }

       
    }

}
