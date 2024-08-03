namespace DiceRoller.Models
{
    public class ProbabilityObjectModel
    {
        private int currentState = 1;

        public int Id { get; set; }

        public string? ObjectName { get; set; }

        public int NumberOfStates { get; set; } = 6;

        public int CurrentState { get => currentState; set => currentState = value; }
        //  public List<string>? StateLabels { get; set; }

        // public List<double>? StateProbabilities { get; set; }

        // public List<string>? StateViews { get; set; }
    }
}
