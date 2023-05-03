namespace Scripts.States
{
    public class StateMachine
    {
        public IState CurrentState { get; set; }
        

        public void EnterState(IState newState)
        {
            CurrentState?.Exit();
            CurrentState = newState;
            CurrentState.Enter();
        }
    }
}