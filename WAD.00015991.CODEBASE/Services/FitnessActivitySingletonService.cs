using Microsoft.EntityFrameworkCore;
using WAD._00015991.CODEBASE.Data;
using WAD._00015991.CODEBASE.Models;

namespace WAD._00015991.CODEBASE.Services
{
    // 00015991
    public class FitnessActivitySingletonService
    {
        private static FitnessActivitySingletonService? _instance;
        private readonly IServiceProvider _serviceProvider;

        private FitnessActivitySingletonService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static FitnessActivitySingletonService CreateInstance(IServiceProvider serviceProvider)
        {
            if (_instance == null)
            {
                _instance = new FitnessActivitySingletonService(serviceProvider);
            }
            return _instance;
        }

        // Methods to manage fitness activities
        public async Task<IEnumerable<FitnessActivity>> GetAllActivitiesAsync()
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return await context.FitnessActivities.ToListAsync();
        }

        public async Task<FitnessActivity?> GetActivityByIdAsync(int id)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            return await context.FitnessActivities.FindAsync(id);
        }

        public async Task AddActivityAsync(FitnessActivity activity)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.FitnessActivities.Add(activity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateActivityAsync(FitnessActivity activity)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.FitnessActivities.Update(activity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteActivityAsync(int id)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var activity = await context.FitnessActivities.FindAsync(id);
            if (activity != null)
            {
                context.FitnessActivities.Remove(activity);
                await context.SaveChangesAsync();
            }
        }
    }
}
