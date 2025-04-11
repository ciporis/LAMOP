using System;

namespace SimpleGame
{
    internal class Hero
    {
        private float _maxHealth;
        private float _maxMana;

        private float _health;
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
            _health = health;
            _mana = mana;
            _damage = damage;

            _maxHealth = _health;
            _maxMana = _mana;
        }

        public void ApplyDamage(float damage)
        {
            _health -= damage;
            if (_health < 0) { Console.WriteLine("VSE CONETS GEROU"); };
        }

        public void Attack(Boss boss)
        {
            boss.ApplyDamage(_damage);
        }

        public void FireBallAttack(Boss boss)
        {
            if(_manaForFireBall > _mana)
                return;
            boss.ApplyDamage(_damage * _fireBallStrength);
            _mana -= _manaForFireBall;
            _fireBallUsed = true;
        }

        public void Explode(Boss boss)
        {
            if (_fireBallUsed == false || _explosionUsed)
            {
                _explosionUsed = false;
                return;
            }
               
            _explosionUsed = true;
            _fireBallUsed = false;

            boss.ApplyDamage(_damage * _explosionStrength);
        }

        public void RestoreProperties()
        {
            if (_propertiesRestoreCount <= 0)
                return;

            _health = _maxHealth;
            _mana = _maxMana;
            _propertiesRestoreCount--;
        }
    }
}