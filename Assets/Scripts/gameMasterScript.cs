using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(guiMasterScript))]
[RequireComponent(typeof(mapMasterScript))]
public class gameMasterScript : MonoBehaviour
{
    public static gameMasterScript master;
    private guiMasterScript gui;
    private mapMasterScript map;

    public float fCurrentSeasonTime { get; private set; } = 0.0f;
    public float fSeasonDuration { get; private set; } = 60.0f;

    public long lCurrentSeason { get; private set; } = 0;
    public long lSeasonsLimit { get; private set; } = 60;

    public bool bGamePaused { get; private set; } = false;

    private void Awake()
    {
        master = this;
        gui = GetComponent<guiMasterScript>();
        map = GetComponent<mapMasterScript>();
    }

    private void Start()
    {
        gui.Initialize();
        map.InitializeMap();
    }

    private void Update()
    {
        if (bGamePaused)
            return;

        UpdateSeasons();
    }

    private void UpdateSeasons()
    {
        fCurrentSeasonTime += Time.deltaTime;
        if (fCurrentSeasonTime > fSeasonDuration)
        {
            fCurrentSeasonTime = 0f;
            lCurrentSeason++;
        }
    }
    public void SetPause(bool bNPause)
    {
        bGamePaused = bNPause;
    }
}
