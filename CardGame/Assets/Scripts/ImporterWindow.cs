using UnityEditor;
using UnityEngine;
public class ImporterWindow : EditorWindow
{
    private string csvFilePath = "Cards/CardData";

    [MenuItem("Custom/Open Card Importer")]
    public static void ShowWindow()
    {
        GetWindow<ImporterWindow>("Card Importer");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Import Cards"))
        {
            // Call the CardImporter function to import cards
            CardImporter.ImportCardsFromCSV(csvFilePath);
        }
    }
}
