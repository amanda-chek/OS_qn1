using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCanvasOnClick : MonoBehaviour
{
    public List<GameObject> canvases; // List of canvases to switch between
    public Button nextButton; // Reference to the "Next" button
    private int currentCanvasIndex = 0;

    void Start()
    {
        // Ensure only the first canvas is active at the start
        for (int i = 0; i < canvases.Count; i++)
        {
            canvases[i].SetActive(i == 0);
        }

        if (nextButton != null)
        {
            nextButton.onClick.AddListener(OnNextButtonClicked); // Add listener to the button
        }
        else
        {
            Debug.LogError("Next button is not assigned!");
        }
    }

    void OnNextButtonClicked()
    {
        // Deactivate the current canvas
        canvases[currentCanvasIndex].SetActive(false);

        // Increment the index to show the next canvas
        currentCanvasIndex++;

        // If we've reached the end of the list, wrap around to the first canvas
        if (currentCanvasIndex >= canvases.Count)
        {
            currentCanvasIndex = 0; // Optional: wrap around, or you can handle end of sequence differently
            // Optionally, you can disable the button here if it's the end
            // nextButton.gameObject.SetActive(false);
        }

        // Activate the next canvas
        canvases[currentCanvasIndex].SetActive(true);
    }
}
