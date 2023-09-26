using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardEffectData
{
    public enum CardEffectType
    {
        Damage,
        Healing,
        Destroy,
        DrawCards,
        // Add other effect types as needed
    }

    // Effect values specific to different effect types
    public int damageValue; // For damage effect
    public int healingValue; // For healing effect
    public int destroyValue; // For destroy effect
    public int drawCardsValue; // For draw cards effect
    // Add more fields as needed

    public CardEffectType effectType;

    // Constructors to initialize effect values
    public CardEffectData(CardEffectType type, int value)
    {
        effectType = type;
        SetEffectValue(value);
    }

    // Method to set effect value based on effect type
    public void SetEffectValue(int value)
    {
        switch (effectType)
        {
            case CardEffectType.Damage:
                damageValue = value;
                break;
            case CardEffectType.Healing:
                healingValue = value;
                break;
            case CardEffectType.Destroy:
                destroyValue = value;
                break;
            case CardEffectType.DrawCards:
                drawCardsValue = value;
                break;
                // Add cases for other effect types
        }
    }
}

