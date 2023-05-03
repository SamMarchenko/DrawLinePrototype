using UnityEngine;

namespace Scripts.States
{
    public class MovingState : IState
    {
        public void Enter()
        {
            Debug.Log("Я вошел в MovingState ");
        }

        public void Exit()
        {
            Debug.Log("Я вышел из MovingState ");
        }
    }
}