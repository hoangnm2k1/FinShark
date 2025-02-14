using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Bogus;

namespace seeder
{
    public static class StockSeeder
    {
        public static List<Stock> GenerateStock(int count)
        {
            var faker = new Faker<Stock>()
                .RuleFor(s => s.Symbol, f => GenerateStockSymbol(f)) 
                .RuleFor(s => s.CompanyName, f => f.Company.CompanyName())                 
                .RuleFor(s => s.Purchase, f => f.Finance.Amount(10, 500)) 
                .RuleFor(s => s.LastDiv, f => f.Finance.Amount(0, 10)) 
                .RuleFor(s => s.Industry, f => f.Commerce.Categories(1)[0]) 
                .RuleFor(s => s.MarketCap, f => f.Random.Long(1_000_000, 100_000_000_000)) 
                .RuleFor(s => s.Comments, f => new List<Comment>()) 
                .RuleFor(s => s.Portfolios, f => new List<Portfolio>()); 

            return faker.Generate(count);    

        }

        private static string GenerateStockSymbol(Faker faker)
        {
            return faker.Random.String2(faker.Random.Int(3,5), "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        }
    }
}