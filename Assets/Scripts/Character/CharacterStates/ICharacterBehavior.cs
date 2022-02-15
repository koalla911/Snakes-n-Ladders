using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    interface ICharacterBehavior
    {
        void EnterState(CharacterMain character);
        void ExitState();
    }
}
