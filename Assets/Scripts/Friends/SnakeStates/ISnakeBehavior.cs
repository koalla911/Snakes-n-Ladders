using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    interface ISnakeBehavior
    {
        void EnterState(Snake snake);
        void ExitState();
    }
}
