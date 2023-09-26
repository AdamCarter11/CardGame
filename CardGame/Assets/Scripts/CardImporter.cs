using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class CardImporter : EditorWindow
{
    //private string csvFilePath = "Cards/CardData";

    [MenuItem("Custom/Open Card Importer")]
    public static void ShowWindow()
    {
        GetWindow<ImporterWindow>("Card Importer");
    }

    public static void ImportCardsFromCSV(string csvFilePath)
    {
        TextAsset csvFile = Resources.Load<TextAsset>(csvFilePath);

        if (csvFile == null)
        {
            Debug.LogError("CSV file not found in Resources folder: " + csvFilePath);
            return;
        }

        string[] csvLines = csvFile.text.Split('\n');

        foreach (string csvLine in csvLines)
        {
            string[] csvValues = csvLine.Split(',');

            if (csvValues.Length >= 4) // Ensure there are at least 4 columns: Name, Cost, EffectType1, EffectValue1, EffectType2, EffectValue2, ...
            {
                string cardName = csvValues[0];
                int cost = int.Parse(csvValues[1]);

                // Create a new scriptable object for each card
                BaseCard card = ScriptableObject.CreateInstance<BaseCard>();
                card.cardName = cardName;
                card.cost = cost;

                // Start parsing effect data from index 2
                Debug.Log("csv len: " + csvValues.Length);
                for (int i = 2; i < csvValues.Length; i += 2)
                {
                    if (csvValues[i] != "")
                    {
                        string effectType = csvValues[i];
                        Debug.Log(csvValues[i + 1] + " i: " + i);
                        int effectValue = int.Parse(csvValues[i + 1]);

                        // Create and set up card effects based on the effect type and value
                        CardEffectData effectData = new CardEffectData(
                            (CardEffectData.CardEffectType)System.Enum.Parse(typeof(CardEffectData.CardEffectType), effectType),
                            effectValue
                        );
                        // Set other effect properties as needed

                        card.cardEffects.Add(effectData);
                    }
                    
                }

                // Save the scriptable object as an asset
                UnityEditor.AssetDatabase.CreateAsset(card, "Assets/ScriptableObj/" + cardName + ".asset");
            }
        }

        // Refresh the Asset Database
        UnityEditor.AssetDatabase.Refresh();
    }
}
