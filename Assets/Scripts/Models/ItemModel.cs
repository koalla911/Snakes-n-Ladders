
namespace SnakesNLadders.Assets.Scripts.Models
{
    public class ItemModel
    {
        public delegate void ChangeItem(int score);
        public event ChangeItem OnChangeItem;

        public int CurrentCoin { get { return _sourceCoin; } }

        private int _sourceCoin = 0;


        public void SetItemValue(int difference)
        {
            _sourceCoin += difference;
            OnChangeItem?.Invoke(_sourceCoin);
        }
    }
}