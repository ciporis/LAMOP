using System;
using System.Diagnostics;
using System.Threading;

namespace SimpleGame
{
    internal class MiniGame
    {
        private const int _sliderWidth = 50;
        private const int _targetZoneStart = 20;
        private const int _targetZoneWidth = 10;
        private const int _minSpeed = 8;
        private const int _maxSpeed = 16;

        private int _speed;

        private int _sliderPosition = 0;
        private bool _isRunning = true;
        private bool _isIncreasing = true;
        private bool _success = false;

        public MiniGame()
        {
            _speed = Services.InclusiveRandom.InclusiveNext(_minSpeed, _maxSpeed);
        }

        public void StartMiniGame()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("Остановите ползунок в зеленой зоне (между [  ]) " +
                "чтобы ипользовать атаку");
            Console.WriteLine("Нажмите любую клавишу, чтобы остановить...");
            Console.WriteLine();

            DrawSlider();

            Thread sliderThread = new Thread(MoveSlider);
            sliderThread.Start();

            Console.ReadKey(true);
            _isRunning = false;

            if (_sliderPosition >= _targetZoneStart && 
                _sliderPosition <= _targetZoneStart + _targetZoneWidth)
            {
                _success = true;
            }

            Console.Clear();
            Console.WriteLine(_success ? "Атака использована" :
                "Ход противника!!!!");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void MoveSlider()
        {
            while (_isRunning)
            {
                if (_isIncreasing)
                {
                    _sliderPosition++;

                    if (_sliderPosition >= _sliderWidth)
                    {
                        _sliderPosition = _sliderWidth - 2;
                        _isIncreasing = false;
                    }
                }
                else
                {
                    _sliderPosition--;

                    if (_sliderPosition <= 0)
                    {
                        _sliderPosition = 2;
                        _isIncreasing = true;
                    }
                }

                DrawSlider();

                Thread.Sleep(_speed);
            }
        }

        public void DrawSlider()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - _sliderWidth / 2, Console.WindowHeight / 2);

            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(Console.WindowWidth / 2 - _sliderWidth / 2, Console.WindowHeight / 2);

            Console.Write("[");

            for (int i = 0; i < _sliderWidth; i++)
            {
                if (i == _sliderPosition)
                {
                    Console.Write("|");
                }
                else if (i >= _targetZoneStart && i <= _targetZoneStart + _targetZoneWidth)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");
                    Console.ResetColor();
                }
            }

            Console.Write("]");
        }

        public bool GetMiniGameSucces()
        {
            return _success;
        }
    }
}
