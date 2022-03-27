using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Progress")]
    public int ballonsPopped, coins, weaponsHeld;
    public WeaponVariables currentWeapon;

    [Header("Upgradables")]
    public float health, maxHealth, energy, maxEnergy;

    [Header("Players to Search For")]
    public GameObject thePlane, thePlayer, currentPlayer;
    
    [SerializeField]
    public PlaystyleEnum currentPlaystyle;
    // Start is called before the first frame update
    void Awake()
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
        if (currentPlaystyle == PlaystyleEnum.PILOT)
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
        if (currentPlaystyle == PlaystyleEnum.SOLDIER)
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
        if (currentPlaystyle == PlaystyleEnum.PILOT)
        {
            currentPlaystyle = PlaystyleEnum.SOLDIER;
            currentPlayer = thePlayer;
        }else if (currentPlaystyle == PlaystyleEnum.SOLDIER) 
        {
            currentPlaystyle = PlaystyleEnum.PILOT;
            currentPlayer = thePlane;
        }
    }

    public void ChangeWeapon(WeaponTypes newWeapon)
    {
        // Find weapon by enum
        //weaponsHeld = 
    }
}
