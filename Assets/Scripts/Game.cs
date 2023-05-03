using System;
using Scripts.States;
using UnityEngine;

namespace Scripts
{
    public class Game : MonoBehaviour
    {
        private StateMachine _stateMachine;

        private void Start()
        {   
            _stateMachine = new StateMachine();
        }
    }
}