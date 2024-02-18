using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI waveText; // —сылка на TextMeshPro дл€ номера волны
    public TextMeshProUGUI victoryText; // —сылка на TextMeshPro дл€ сообщени€ о победе

    public void UpdateWaveNumber(int currentWave, int totalWaves)
    {
        waveText.text = "Wave: " + currentWave.ToString() + "/" + totalWaves.ToString();
    }

    public void DisplayVictoryMessage()
    {
        victoryText.text = "You Win!";
    }
}
