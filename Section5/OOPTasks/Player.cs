using System;

namespace OOPTasks
{
    internal class Player
    {
        private string _name;
        private int _damage;
        private int _health;

        public Player(string name, int damage, int health)
        {
            _name = name;
            _damage = damage;
            _health = health;
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Player name - {_name}");
            Console.WriteLine($"Player damage - {_damage}");
            Console.WriteLine($"Player health - {_health}");
        }
    }
}
