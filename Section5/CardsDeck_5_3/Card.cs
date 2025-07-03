namespace CardsDeck_5_3
{
    internal class Card
    {
        private string _suitmark;
        private string _value;

        public Card(string type, string value)
        {
            _suitmark = type;
            _value = value;
        }

        public string GetCardInfo()
        {
            return $"{_value} - {_suitmark}";
        }
    }
}
