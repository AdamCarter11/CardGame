using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CardEffectData;

public class CardController : MonoBehaviour
{
    public BaseCard cardData; // Assign the "MyCard" asset in the Inspector.

    void Start()
    {
        // Play the card when the game starts
        CardController cardController = GetComponent<CardController>();
        cardController.PlayCard();
    }

    public void PlayCard()
    {
        Debug.Log("Playing card: " + cardData.cardName);

        foreach (var effectData in cardData.cardEffects)
        {
            switch (effectData.effectType)
            {
                case CardEffectType.Damage:
                    int damageAmount = effectData.damageValue;
                    Debug.Log("Dealing " + damageAmount + " damage.");
                    // Implement damage logic here
                    break;
                case CardEffectType.DrawCards:
                    int drawCount = effectData.drawCardsValue;
                    Debug.Log("Drawing " + drawCount + " cards.");
                    // Implement draw cards logic here
                    break;
                case CardEffectType.Destroy:
                    int destroyCount = effectData.destroyValue;
                    Debug.Log("Destroy " + destroyCount + " cards.");
                    // Implement draw cards logic here
                    break;
                case CardEffectType.Healing:
                    int HealCount = effectData.healingValue;
                    Debug.Log("Heal " + HealCount + " cards.");
                    // Implement draw cards logic here
                    break;
                    // Add cases for other effect types
            }
        }
    }
}
