namespace Assets.Scripts.Actors.Weapons
{
    public interface IDamageable
    {
        void TakeDamageFrom(IDamager damager);
    }
}
