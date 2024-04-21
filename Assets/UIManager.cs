using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Color winColor;
    [SerializeField] private Color loseColor;
    [SerializeField] private GameObject finalUI;

    [SerializeField] private TextMeshProUGUI stateText;

    private void Start()
    {
        finalUI.SetActive(false);
    }

    public void FinalState(bool isWin)
    {
        if(isWin)
        {
            stateText.text = "WELL DONE!";
            stateText.color = winColor;
        }
        else
        {
            stateText.text = "YOU LOSE!";
            stateText.color = loseColor;
        }

        finalUI.SetActive(true);
    }
}
