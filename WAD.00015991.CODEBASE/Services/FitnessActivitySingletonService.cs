using WAD._00015991.CODEBASE.Models;

namespace WAD._00015991.CODEBASE.Services
{
    // 00015991
    public class FitnessActivitySingletonService
    {
        private static FitnessActivitySingletonService? _instance;
        private readonly List<FitnessActivity> _activities;

        // Private constructor to prevent direct instantiation
        private FitnessActivitySingletonService()
        {
            _activities = new List<FitnessActivity>();
        }

        // Public method to get the single instance
        public static FitnessActivitySingletonService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FitnessActivitySingletonService();
                }
                return _instance;
            }
        }

        // Methods to manage fitness activities
        public IEnumerable<FitnessActivity> GetAllActivities() => _activities;

        public void AddActivity(FitnessActivity activity) => _activities.Add(activity);

        public void RemoveActivity(int id)
        {
            var activity = _activities.FirstOrDefault(a => a.Id == id);
            if (activity != null)
            {
                _activities.Remove(activity);
            }
        }
    }
}
