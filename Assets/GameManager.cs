using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ballonsPopped;
    public float health, maxHealth, energy, maxEnergy;

    enum playstyle { PILOT, SOLDIER}
    [SerializeField]
    playstyle currentPlaystyle;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool CheckIfPilot()
    {
        if (currentPlaystyle == playstyle.PILOT)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckIfSoldier()
    {
        if (currentPlaystyle == playstyle.SOLDIER)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SwitchPlaystyle()
    {
        if (currentPlaystyle == playstyle.PILOT)
        {
            currentPlaystyle = playstyle.SOLDIER;
        }else if (currentPlaystyle == playstyle.SOLDIER) 
        {
            currentPlaystyle = playstyle.PILOT;
        }
    }
}
