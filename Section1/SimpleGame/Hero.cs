using System;

namespace SimpleGame
{
    internal class Hero
    {
        private float _maxHealth;
        private float _maxMana;

        private float _mana;
        private float _damage;

        private float _fireBallStrength = 2.3f;
        private float _manaForFireBall = 14;
        private float _explosionStrength = 1.2f;

        private int _propertiesRestoreCount = 4;

        private bool _fireBallUsed = false;
        private bool _explosionUsed = false;

        public Hero(float health, float mana, float damage)
        {
            Health = health;
            _mana = mana;
            _damage = damage;

            _maxHealth = Health;
            _maxMana = _mana;

            IsAlive = true;
        }

        public bool IsAlive { get; private set; }
        public float Health { get; private set; }

        public void ApplyDamage(float damage)
        {
            Health -= damage;

            if (Health < 0) 
            { 
                Console.WriteLine("VSE CONETS GEROU");
                IsAlive = false;
            }
        }

        public void Attack(Boss boss)
        {
            boss.ApplyDamage(_damage);
        }

        public void FireBallAttack(Boss boss)
        {
            if(_manaForFireBall > _mana)
            {
                Console.WriteLine("NO MANA FOR THIS ACTION");
                return;
            }
                
            boss.ApplyDamage(_damage * _fireBallStrength);
            _mana -= _manaForFireBall;
            _fireBallUsed = true;
        }

        public void Explode(Boss boss)
        {
            if (_fireBallUsed == false || _explosionUsed)
            {
                _explosionUsed = false;
                Console.WriteLine("YOU CAN'T USE THIS ACTION WITHOUT THE FIREBALL");
                return;
            }
               
            _explosionUsed = true;
            _fireBallUsed = false;

            boss.ApplyDamage(_damage * _explosionStrength);
        }

        public void RestoreProperties(Boss boss)
        {
            if (_propertiesRestoreCount <= 0)
            {
                Console.WriteLine("YOU HAVE NO CHANCES TO USE THIS ACTION");
                return;
            }

            Health = _maxHealth;
            _mana = _maxMana;
            _propertiesRestoreCount--;
        }
    }
}