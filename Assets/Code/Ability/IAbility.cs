namespace MyRaces
{
    public interface IAbility
    {
        public AbilityItemConfig AbilityItemConfig { get; }
        void Apply();
    }
}