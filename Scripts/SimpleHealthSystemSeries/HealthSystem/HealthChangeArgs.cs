namespace Scripts.Systems.HealthSystem
{
    public struct HealthChangeArgs
    {
        public int NewValue;
        public int OldValue;
        public int AttemptedChange;
        public int ActualChange => NewValue - OldValue;
    }
}