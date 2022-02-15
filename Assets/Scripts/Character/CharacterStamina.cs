
namespace SnakesNLadders.Assets.Scripts.Character
{
    public class CharacterStamina
    {
        public int Stamina { get; set; }
        public float ChannalR { get; set; } = 1f;
        public float ChannalG { get; set; } = 1f;
        public float ChannalB { get; set; } = 1f;

        public void StaminaIncrease()
        {
            Stamina--;
        }
        
        public void StaminaDecrease()
        {
            Stamina--;
        }
    }
}