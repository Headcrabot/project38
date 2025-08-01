using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiMasterScript : MonoBehaviour
{
    [SerializeField] private Button buttonPause;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Text textSeason;
    [SerializeField] private GameObject menuPause;

    private gameMasterScript master;

    public bool Initialize()
    {
        master = gameMasterScript.master;


        menuPause.SetActive(false);


        buttonPause.onClick.AddListener(() =>
        {
            if (master.bGamePaused)
                return;
            master.SetPause(true);
            menuPause.SetActive(true);
        });
        buttonContinue.onClick.AddListener(() =>
        {
            if (!master.bGamePaused)
                return;
            master.SetPause(false);
            menuPause.SetActive(false);
        });

        return false;
    }

    private void OnGUI()
    {
        textSeason.text = $"{master.lCurrentSeason}/{master.lSeasonsLimit}\n{(int)master.fCurrentSeasonTime}/{(int)master.fSeasonDuration}";
    }
}
