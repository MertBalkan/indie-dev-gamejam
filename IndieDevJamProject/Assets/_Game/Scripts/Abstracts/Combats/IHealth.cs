namespace SnaileyGame.Combats
{
    public interface IHealth 
    {
        void TakeDamage(float damageCount);
        float CurrentHealth { get; }
        bool IsDead { get; }
    }
}