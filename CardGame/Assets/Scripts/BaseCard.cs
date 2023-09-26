using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Base Card")]
public class BaseCard : ScriptableObject
{
    public string cardName;
    public int cost;

    // Other common properties

    public List<CardEffectData> cardEffects = new List<CardEffectData>();
}
