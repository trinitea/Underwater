using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataManager : MonoBehaviour
{
    //public static SaveDataManager Instance;


   // public CanvasGroup fadeCG;

    public GameObject player;

    public Slider healthSlider;
    public GameObject health;
    public float playerHealth;

    public Slider powerSlider;
    public GameObject power;
    public float playerPower;

    public Slider shipPowerSlider;
    
    public GameObject shipPowerObj;
    public float shipPower;

    public GameObject monster;

    public GameObject eye;
    public GameObject eyePositionShip0;
    public GameObject eyePositionShip01;
    public GameObject eyePositionShip02;

    public float loadTutorial;
    public GameObject tutorial;


    public float loadShip00;
    public GameObject ship00;

    public float loadShip0;
    public GameObject ship0;

    public float loadShip1;
    public GameObject ship1;

    public float loadShip2;
    public GameObject ship2;

    public GameObject descenderTrigger0;
    public GameObject descenderTrigger01;
    public GameObject descenderTrigger;
    public GameObject demoEndTrigger;

    public float loadMonsterWall1;
    public GameObject monsterWall1;

    public float loadMonsterWall2;
    public GameObject monsterWall2;

    public float loadMonsterWall3;
    public GameObject monsterWall3;

    public float loadMonsterWall4;
    public GameObject monsterWall4;


    public float loadPlayerWall1;
    public GameObject playerWall1;

    public float loadPlayerWall2;
    public GameObject playerWall2;

    public float loadDecoyPowerUp;
    public GameObject decoyPowerUp;




    #region powerorbs
    [Header("regular powerOrb floats")]
    public float loadOrb0;
    public float loadOrb1;
    public float loadOrb2;
    public float loadOrb3;
    public float loadOrb4;
    public float loadOrb5;
    public float loadOrb6;
    public float loadOrb7;
    public float loadOrb8;
    public float loadOrb9;
    public float loadOrb10;
    public float loadOrb11;
    public float loadOrb12;
    public float loadOrb13;
    public float loadOrb14;
    public float loadOrb15;
    public float loadOrb16;
    public float loadOrb17;
    public float loadOrb18;
    public float loadOrb19;
    public float loadOrb20;
    public float loadOrb21;
    public float loadOrb22;
    public float loadOrb23;
    public float loadOrb24;
    public float loadOrb25;
    public float loadOrb26;
    public float loadOrb27;
    public float loadOrb28;
    public float loadOrb29;
    #endregion
    public GameObject[] allOrbs;

    public float loadDamagedFarm0;
    public GameObject[] damagedFarms;

    

    public GameObject GameManager;
    public GameObject MainGameManager;


    public void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("gameManager");

        if (GameManager.GetComponent<MainMenu>().loadData == true)
        {
            Invoke("LoadPlayer", 001f);
        }

    }

    public void Start()
    {
        healthSlider = health.GetComponent<Slider>();
        powerSlider = power.GetComponent<Slider>();

        shipPowerSlider = shipPowerObj.GetComponent<Slider>();

        allOrbs = MainGameManager.GetComponent<DestroyedObjectsArray>().allOrbs;

        damagedFarms = GameObject.FindGameObjectsWithTag("DamagedFarm");



    }

    public void SavePlayer()
    {
        

       
        
            SaveSystem.SavePlayer(this);
        
       
      
    }

    public void LoadPlayer()
    {
        //fadeCG.alpha += Mathf.SmoothStep(0, 5f, Time.deltaTime);

        //if (fadeCG.alpha == 1)
        //{
            SaveData data = SaveSystem.LoadPlayer();
       // }
            


        #region sliders
        playerHealth = data.playerHealth;
        healthSlider.value = playerHealth;

        playerPower = data.playerPower;
        powerSlider.value = playerPower;
        #endregion

        #region positions
        Vector3 position;
        position.x = data.playerPosition[0];
        position.y = data.playerPosition[1];
        position.z = data.playerPosition[2];
        player.transform.position = position;

        shipPower = data.shipPower;
        shipPowerSlider.value = shipPower;

        Vector3 shipPos;
        shipPos.x = data.shipPowerPosition[0];
        shipPos.y = data.shipPowerPosition[1];
        shipPos.z = data.shipPowerPosition[2];
        shipPowerObj.transform.position = shipPos;

        Vector3 monsterPos;
        monsterPos.x = data.monsterPosition[0];
        monsterPos.y = data.monsterPosition[1];
        monsterPos.z = data.monsterPosition[2];
        monster.transform.position = monsterPos;
        #endregion

        #region loaded objects

        //loadDecoyPowerUp = MainGameManager.GetComponent<DestroyedObjectsArray>().loadDecoyPowerUp;

        if (MainGameManager.GetComponent<DestroyedObjectsArray>().loadDecoyPowerUp == 1)
        {
            decoyPowerUp.SetActive(true);
            player.GetComponent<Decoy>().enabled = false;

        }
        if (MainGameManager.GetComponent<DestroyedObjectsArray>().loadDecoyPowerUp == 0)
        {
            decoyPowerUp.SetActive(false);
            player.GetComponent<Decoy>().enabled = true;
        }


        loadTutorial = data.tutorial;
        if (loadTutorial == 1)
        {
            tutorial.SetActive(true);
        }
        else
        {
            tutorial.SetActive(false);
        }


        #region ships

        loadShip00 = data.ship00;
        if (loadShip00 == 1)
        {
            ship00.SetActive(true);
        }
        else
        {
            ship00.SetActive(false);
        }


        loadShip0 = data.ship0;
        if (loadShip0 == 1)
        {
            ship00.SetActive(false);
            ship0.SetActive(true);
            descenderTrigger0.SetActive(false);
            eye.transform.position = eyePositionShip0.transform.position;
        }
        else
        {
            ship0.SetActive(false);
        }

       /* if (ship1.activeSelf == true)
        {
            ship0.SetActive(false);
        }*/


        loadShip1 = data.ship1;
        if (loadShip1 == 1)
        {
            ship0.SetActive(false);
            ship1.SetActive(true);
            descenderTrigger01.SetActive(false);
            eye.transform.position = eyePositionShip01.transform.position;
        }
        else
        {
            ship1.SetActive(false);
        }

        loadShip2 = data.ship2;
        if (loadShip2 == 1)
        {
            ship1.SetActive(false);
            ship2.SetActive(true);
            eye.transform.position = eyePositionShip02.transform.position;
            descenderTrigger.SetActive(false);
            demoEndTrigger.SetActive(true);
            //ship1.SetActive(false);
        }
        else
        {
            ship2.SetActive(false);
        }
        #endregion


        #region walls
        loadMonsterWall1 = data.monsterWall1;

        if (loadMonsterWall1 == 1)
        {
            monsterWall1.SetActive(true);
            
        }
        else
        {
            monsterWall1.SetActive(false);
        }


        loadMonsterWall2 = data.monsterWall2;

        if (loadMonsterWall2 == 1)
        {
            monsterWall2.SetActive(true);

        }
        else
        {
            monsterWall2.SetActive(false);
        }


        loadMonsterWall3 = data.monsterWall3;

        if (loadMonsterWall3 == 1)
        {
            monsterWall3.SetActive(true);

        }
        else
        {
            monsterWall3.SetActive(false);
        }


        loadMonsterWall4 = data.monsterWall4;

        if (loadMonsterWall4 == 1)
        {
            monsterWall4.SetActive(true);

        }
        else
        {
            monsterWall4.SetActive(false);
        }


        loadPlayerWall1 = data.playerWall1;

        if (loadPlayerWall1 == 1)
        {
            playerWall1.SetActive(true);

        }
        else
        {
            playerWall1.SetActive(false);
        }

        loadPlayerWall2 = data.playerWall2;

        if (loadPlayerWall2 == 1)
        {
            playerWall2.SetActive(true);

        }
        else
        {
            playerWall2.SetActive(false);
        }
        #endregion 

        loadDamagedFarm0 = data.damagedFarm0;

        if (loadDamagedFarm0 == 1)
        {
           damagedFarms[0].SetActive(true);

        }
        else
        {
           damagedFarms[0].SetActive(false);
        }



        #region orbs
        #region load orb data

        loadOrb0 = data.orb0;
        loadOrb1 = data.orb1;
        loadOrb2 = data.orb2;
        loadOrb3 = data.orb3;
        loadOrb4 = data.orb4;
        loadOrb5 = data.orb5;
        loadOrb6 = data.orb6;
        loadOrb7 = data.orb7;
        loadOrb8 = data.orb8;
        loadOrb9 = data.orb9;
        loadOrb10 = data.orb10;
        loadOrb11 = data.orb11;
        loadOrb12 = data.orb12;
        loadOrb13 = data.orb13;
        loadOrb14 = data.orb14;
        loadOrb15 = data.orb15;
        loadOrb16 = data.orb16;
        loadOrb17 = data.orb17;
        loadOrb18 = data.orb18;
        loadOrb19 = data.orb19;
        loadOrb20 = data.orb20;
        loadOrb21 = data.orb21;
        loadOrb22 = data.orb22;
        loadOrb23 = data.orb23;
        loadOrb24 = data.orb24;
        loadOrb25 = data.orb25;
        loadOrb26 = data.orb26;
        loadOrb27 = data.orb27;
        loadOrb27 = data.orb28;
        loadOrb27 = data.orb29;

        #endregion

        #region  orb array check

        if (loadOrb0 == 1)
        {
            allOrbs[0].SetActive(true);
        }
        else
        {
            allOrbs[0].SetActive(false);
        }

        if (loadOrb1 ==1)
        {
            allOrbs[1].SetActive(true);
        }
        else
        {
            allOrbs[1].SetActive(false);
        }

        if (loadOrb2 ==1)
        {
            allOrbs[2].SetActive(true);
        }
        else
        {
            allOrbs[2].SetActive(false);
        }

        if (loadOrb3 ==1)
        {
            allOrbs[3].SetActive(true);
        }
        else
        {
            allOrbs[3].SetActive(false);
        }

        if (loadOrb4 ==1)
        {
            allOrbs[4].SetActive(true);
        }
        else
        {
            allOrbs[4].SetActive(false);
        }

        if (loadOrb5 ==1)
        {
            allOrbs[5].SetActive(true);
        }
        else
        {
            allOrbs[5].SetActive(false);
        }

        if (loadOrb6 ==1)
        {
            allOrbs[6].SetActive(true);
        }
        else
        {
            allOrbs[6].SetActive(false);
        }

        if (loadOrb7 ==1)
        {
            allOrbs[7].SetActive(true);
        }
        else
        {
            allOrbs[7].SetActive(false);
        }

        if (loadOrb8 ==1)
        {
            allOrbs[8].SetActive(true);
        }
        else
        {
            allOrbs[8].SetActive(false);
        }

        if (loadOrb9 ==1)
        {
            allOrbs[9].SetActive(true);
        }
        else
        {
            allOrbs[9].SetActive(false);
        }

        if (loadOrb10 ==1)
        {
            allOrbs[10].SetActive(true);
        }
        else
        {
            allOrbs[10].SetActive(false);
        }

        if (loadOrb11 ==1)
        {
            allOrbs[11].SetActive(true);
        }
        else
        {
            allOrbs[11].SetActive(false);
        }

        if (loadOrb12 ==1)
        {
            allOrbs[12].SetActive(true);
        }
        else
        {
            allOrbs[12].SetActive(false);
        }

        if (loadOrb13 ==1)
        {
            allOrbs[13].SetActive(true);
        }
        else
        {
            allOrbs[13].SetActive(false);
        }

        if (loadOrb14 ==1)
        {
            allOrbs[14].SetActive(true);
        }
        else
        {
            allOrbs[14].SetActive(false);
        }

        if (loadOrb15 ==1)
        {
            allOrbs[15].SetActive(true);
        }
        else
        {
            allOrbs[15].SetActive(false);
        }

        if (loadOrb16 == 1)
             {
                 allOrbs[16].SetActive(true);
             }
        if (loadOrb16 == 0)
        {
            allOrbs[16].SetActive(false);
        }

        if (loadOrb17 == 1)
        {
            allOrbs[17].SetActive(true);
        }
        else
        {
            allOrbs[17].SetActive(false);
        }

        if (loadOrb18 == 1)
        {
            allOrbs[18].SetActive(true);
        }
        else
        {
            allOrbs[18].SetActive(false);
        }

        if (loadOrb19 == 1)
        {
            allOrbs[19].SetActive(true);
        }
        else
        {
            allOrbs[19].SetActive(false);
        }

        if (loadOrb20 == 1)
        {
            allOrbs[20].SetActive(true);
        }
        else
        {
            allOrbs[20].SetActive(false);
        }


        if (loadOrb21 == 1)
        {
            allOrbs[21].SetActive(true);
        }
        else
        {
            allOrbs[21].SetActive(false);
        }


        if (loadOrb22 == 1)
        {
            allOrbs[22].SetActive(true);
        }
        else
        {
            allOrbs[22].SetActive(false);
        }

        if (loadOrb23 == 1)
        {
            allOrbs[23].SetActive(true);
        }
        else
        {
            allOrbs[23].SetActive(false);
        }

        if (loadOrb24 == 1)
        {
            allOrbs[24].SetActive(true);

        }
        else
        {
            allOrbs[24].SetActive(false);
        }


        if (loadOrb25 == 1)
        {
            allOrbs[25].SetActive(true);
        }
        else
        {
            allOrbs[25].SetActive(false);
        }


        if (loadOrb26 == 1)
        {
            allOrbs[26].SetActive(true);
        }
        else
        {
            allOrbs[26].SetActive(false);
        }


        if (loadOrb27 == 1)
        {
            allOrbs[27].SetActive(true);
        }
        else
        {
            allOrbs[27].SetActive(false);
        }

        if (loadOrb28 == 1)
        {
            allOrbs[28].SetActive(true);
        }
        else
        {
            allOrbs[28].SetActive(false);
        }

        if (loadOrb29 == 1)
        {
            allOrbs[29].SetActive(true);
        }
        else
        {
            allOrbs[29].SetActive(false);
        }




        #endregion
        #endregion
        #endregion




        GameManager.GetComponent<MainMenu>().loadData = false;

    }

}
