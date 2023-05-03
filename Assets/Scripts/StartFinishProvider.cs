using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class StartFinishProvider
    {
        private readonly PlayerFinishFactory _factory;
        public Dictionary<Unit, Finish> PlayerFinishDictionary = new Dictionary<Unit, Finish>();

        public StartFinishProvider(PlayerFinishFactory factory)
        {
            _factory = factory;
            Init();
        }

        private void Init()
        {
            PlayerFinishDictionary.Add(_factory.GetPlayer(0, Color.cyan), _factory.GetFinish(0, Color.blue));
            PlayerFinishDictionary.Add(_factory.GetPlayer(1, Color.magenta), _factory.GetFinish(1, Color.red));
        }
    }
}