using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveData
{
    public float[] playerPosition;
    public float playerHealth;
    public float playerPower;

    public float shipPower;
    public float[] shipPowerPosition;

    public float[] monsterPosition;

    public float tutorial;

    public float ship00;
    public float ship0;
    public float ship1;
    public float ship2;

    public float monsterWall1;
    public float monsterWall2;
    public float monsterWall3;
    public float monsterWall4;

    public float playerWall1;
    public float playerWall2;

    public float decoyPowerUp;


    public float damagedFarm0;
    public float damagedFarm1;
    public float damagedFarm2;
    public float damagedFarm3;
    public float damagedFarm4;
    public float damagedFarm5;

    #region powerorbs
    [Header("powerorbs")]
    public float orb0;
    public float orb1;
    public float orb2;
    public float orb3;
    public float orb4;
    public float orb5;
    public float orb6;
    public float orb7;
    public float orb8;
    public float orb9;
    public float orb10;
    public float orb11;
    public float orb12;
    public float orb13;
    public float orb14;
    public float orb15;
    public float orb16;
    public float orb17;
    public float orb18;
    public float orb19;
    public float orb20;
    public float orb21;
    public float orb22;
    public float orb23;
    public float orb24;
    public float orb25;
    public float orb26;
    public float orb27;
    public float orb28;
    public float orb29;
    #endregion





    public SaveData(SaveDataManager player)
    {

        #region sliders

        playerHealth = player.healthSlider.value;
        playerPower = player.powerSlider.value;

        shipPower = player.shipPowerSlider.value;

        #endregion

        #region positions

        playerPosition = new float[3];
        playerPosition[0] = player.player.transform.position.x;
        playerPosition[1] = player.player.transform.position.y;
        playerPosition[2] = player.player.transform.position.z;

        shipPowerPosition = new float[3];
        shipPowerPosition[0] = player.shipPowerObj.transform.position.x;
        shipPowerPosition[1] = player.shipPowerObj.transform.position.y;
        shipPowerPosition[2] = player.shipPowerObj.transform.position.z;


        monsterPosition = new float[3];
        monsterPosition[0] = player.monster.transform.position.x;
        monsterPosition[1] = player.monster.transform.position.y;
        monsterPosition[2] = player.monster.transform.position.z;

        #endregion

        #region loaded objects

        tutorial = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadTutorial;

        ship00 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadShip00;
        ship0 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadShip0;
        ship1 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadShip1;
        ship2 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadShip2;

        monsterWall1 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadMonsterWall1;
        monsterWall2 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadMonsterWall2;
        monsterWall3 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadMonsterWall3;
        monsterWall4 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadMonsterWall4;

        playerWall1 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadPlayerWall1;
        playerWall2 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadPlayerWall2;

        decoyPowerUp = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDecoyPowerUp;


        damagedFarm0 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm0;
        damagedFarm1 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm1;
        damagedFarm2 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm2;
        damagedFarm3 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm3;
        damagedFarm4 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm4;
        damagedFarm5 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadDamagedFarm5;

        #region powerorbs
        orb0 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb0;
        orb1 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb1;
        orb2 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb2;
        orb3 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb3;
        orb4 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb4;
        orb5 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb5;
        orb6 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb6;
        orb7 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb7;
        orb8 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb8;
        orb9 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb9;
        orb10 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb10;
        orb11 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb11;
        orb12 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb12;
        orb13 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb13;
        orb14 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb14;
        orb15 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb15;
        orb16 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb16;
        orb17 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb17;
        orb18 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb18;
        orb19 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb19;
        orb20 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb20;
        orb21 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb21;
        orb22 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb22;
        orb23 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb23;
        orb24 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb24;
        orb25 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb25;
        orb26 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb26;
        orb27 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb27;
        orb28 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb28;
        orb29 = player.MainGameManager.GetComponent<DestroyedObjectsArray>().loadOrb29;
        #endregion

        #endregion
    }
}
