using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 10)]
public class GetData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;
    public CardData[] CardData => _cardData;
}
