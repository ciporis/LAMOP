using System;

namespace SimpleGame
{
    internal class Boss
    {
        private float _damage;
        private float _fireAttackMultiplier = 1.4f;
        private float _iceBurpMultiplier = 1.3f;

        private Action<Hero>[] _bossAttacks;

        public Boss(float health, float damage)
        {
            _bossAttacks = new Action<Hero>[]
            {
                PawStrike,
                FireAttack,
                IceBurp,
            };

            //_bossAttacks = [PawStrike, FireAttack, IceBurp]; - ГРУСТНО ЕМАЕ

            Health = health;   
            _damage = damage;
            IsAlive = true;
        }

        public float Health;
        public bool IsAlive;

        public void ApplyDamage(float damage)
        {
            Health -= damage;

            if (Health < 0) 
            { 
                Console.WriteLine("VSE CONETS BOSSU");
                IsAlive = false;
            }
        }

        private void PawStrike(Hero hero)
        {
            hero.ApplyDamage(_damage);
        }

        private void FireAttack(Hero hero)
        {
            hero.ApplyDamage(_damage * _fireAttackMultiplier);
        }

        private void IceBurp(Hero hero)
        {
            hero.ApplyDamage(_damage * _iceBurpMultiplier);
        }

        public void UseRandomAttack(Hero hero)
        {
            int minAttackIndex = 0;
            int maxAttackIndex = _bossAttacks.Length - 1;
            int randomMethodIndex = Services.InclusiveRandom.InclusiveNext(minAttackIndex, maxAttackIndex);

            _bossAttacks[randomMethodIndex].Invoke(hero);
        }
    }
}
