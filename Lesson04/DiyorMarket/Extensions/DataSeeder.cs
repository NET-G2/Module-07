using Bogus;
using DiyorMarket.Domain.Entities;
using DiyorMarket.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiyorMarket.Extensions
{
    public static class DataSeeder 
    {
        private static Faker _faker = new Faker(); 
    }
}
