using TMPPP.Domain.Entities;

namespace TMPPP.Flyweight
{
    // Flyweight Factory
    public class ExerciseLibrary
    {
        private Dictionary<string, Exercise> _exercises = new Dictionary<string, Exercise>();

        public Exercise GetExercise(string name, string muscle, string equip)
        {
            string key = name.ToLower();
            if (!_exercises.ContainsKey(key))
            {
                // _exercises[key] = new Exercise { Name = name, MuscleGroup = muscle, Equipment = equip };
            }
            return _exercises[key];
        }
    }
}
