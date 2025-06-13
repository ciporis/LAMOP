using System;
using System.Collections.Generic;

namespace DataBase_5_2
{
    internal class UsersDataBase
    {
        private int _idColumn = 0;
        private int _nickNameColumn = 1;
        private int _levelColumn = 2;
        private int _banFlagColumn = 3;

        private int _columnsCount = 4;

        private List<object[]> _table = new List<object[]>();

        public void AddUser(string nickName, int level, bool banFlag)
        {
            object[] playerRow = new object[_columnsCount];

            if (_table.Count == 0)
                playerRow[_idColumn] = 0;
            else
                playerRow[_idColumn] = _table.Count;

            playerRow[_nickNameColumn] = nickName;
            playerRow[_levelColumn] = level;
            playerRow[_banFlagColumn] = banFlag;

            _table.Add(playerRow);
        }

        public void RemoveUser(int id)
        {
            _table.RemoveAt(id);
        }

        public object[] GetUser(int id)
        {
            return _table[id];
        }

        public void EditUser(int id, string nickName, int level, bool banFlag)
        {
            _table[id][_nickNameColumn] = nickName;
            _table[id][_levelColumn] = level;
            _table[id][_banFlagColumn] = banFlag;
        }

        public void BanUserById(int id)
        {
            _table[id][_banFlagColumn] = true;
        }

        public void UnbanUserById(int id)
        {
            _table[id][_banFlagColumn] = false;
        }
    }
}
