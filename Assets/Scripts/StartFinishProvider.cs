using System;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class StartFinishProvider: MonoBehaviour
    {
        [SerializeField] private Unit _player1;
        [SerializeField] private Finish _finish1;
        [SerializeField] private Unit _player2;
        [SerializeField] private Finish _finish2;
        public Dictionary<Unit, Finish> PlayerFinishDictionary = new Dictionary<Unit, Finish>();
        

        private void Start()
        {
            PlayerFinishDictionary.Add(_player1, _finish1);
            PlayerFinishDictionary.Add(_player2, _finish2);
        }
    }
}