using UnityEngine;

namespace Scripts.States
{
    public class DrawingState : IState
    {
        public void Enter()
        {
            Debug.Log("Я вошел в DrawingState ");
        }

        public void Exit()
        {
            Debug.Log("Я вышел из DrawingState ");
        }
    }
}