using System;

namespace SimpleGame
{
    internal class Boss
    {
        private float _health;
        private float _damage;
        private float _fireAttackMultiplier = 1.4f;
        private float _iceBurpMultiplier = 1.3f;

        public Boss(float health, float damage)
        {
            _health = health;   
            _damage = damage;
        }

        public void ApplyDamage(float damage)
        {
            _health -= damage;
            if (_health < 0) { Console.WriteLine("VSE CONETS BOSSU"); };
        }

        public void PawStrike(Hero hero)
        {
            hero.ApplyDamage(_damage);
        }

        public void FireAttack(Hero hero)
        {
            hero.ApplyDamage(_damage * _fireAttackMultiplier);
        }

        public void IceBurp(Hero hero)
        {
            hero.ApplyDamage(_damage * _iceBurpMultiplier);
        }
    }
}
