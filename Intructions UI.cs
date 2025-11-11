using UnityEngine;

public class InstructionsUI : MonoBehaviour
{
    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject characterSelectionPanel;

    void Start()
    {
        // Show instructions at the start
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
        }

        // Hide character selection initially
        if (characterSelectionPanel != null)
        {
            characterSelectionPanel.SetActive(false);
        }

        Invoke("PauseGame", 0.1f);
    }
    void PauseGame()
    {
        Time.timeScale = 0; // Pause the game
    }

    public void ShowCharacterSelection()
    {
        // Hide instructions
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }

        // Show character selection
        if (characterSelectionPanel != null)
        {
            characterSelectionPanel.SetActive(true);
        }
    }
}