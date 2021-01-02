using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;



public class DestroyedObjectsArray : MonoBehaviour
{

    public GameObject tutorial;
    public float loadTutorial;

    public GameObject shipGrp00;
    public float loadShip00;

    public GameObject shipGrp0;
    public float loadShip0;

    public GameObject shipGrp1;
    public float loadShip1;

    public GameObject shipGrp2;
    public float loadShip2;

    public GameObject monsterWall1;
    public float loadMonsterWall1;

    public GameObject monsterWall2;
    public float loadMonsterWall2;

    public GameObject monsterWall3;
    public float loadMonsterWall3;

    public GameObject monsterWall4;
    public float loadMonsterWall4;

    public GameObject playerWall1;
    public float loadPlayerWall1;

    public GameObject playerWall2;
    public float loadPlayerWall2;

    public GameObject decoyPowerUp;
    public float loadDecoyPowerUp;

    public GameObject[] damagedFarms;
    public float loadDamagedFarm0;
    public float loadDamagedFarm1;
    public float loadDamagedFarm2;
    public float loadDamagedFarm3;
    public float loadDamagedFarm4;
    public float loadDamagedFarm5;

    #region powerorb stuff
    [Header("powerorbs")]
    public GameObject[] powerOrbs;
    public GameObject[] noChasePowerOrbs;
    public GameObject[] yesChasePowerOrbs;
    public GameObject[] allOrbs;
    public GameObject[] twoOrbs;

    //public byte[] loadOrbs;
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



    // Start is called before the first frame update
    void Start()
    {
        powerOrbs = GameObject.FindGameObjectsWithTag("PowerOrb");
        noChasePowerOrbs = GameObject.FindGameObjectsWithTag("NoChase");
        yesChasePowerOrbs = GameObject.FindGameObjectsWithTag("YesChase");

        twoOrbs = powerOrbs.Concat(noChasePowerOrbs).ToArray();
        allOrbs = twoOrbs.Concat(yesChasePowerOrbs).ToArray();

        damagedFarms = GameObject.FindGameObjectsWithTag("DamagedFarm");
    }

    public void destroyedObjectCheck()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (tutorial.activeSelf == true)
        {
            loadTutorial = 1;
        }
        if (tutorial.activeSelf == false)
        {
            loadTutorial = 0;
        }


        if (decoyPowerUp.activeSelf)
        {
            loadDecoyPowerUp = 1;
        }
        else
        {
            loadDecoyPowerUp = 0;
        }

        #region walls active check
        if (monsterWall1.activeSelf == true)
        {
            loadMonsterWall1 = 1;
        }
        if (monsterWall1.activeSelf == false)
        {
            loadMonsterWall1 = 0;
        }

        if (monsterWall2.activeSelf == true)
        {
            loadMonsterWall2 = 1;
        }
        if (monsterWall2.activeSelf == false)
        {
            loadMonsterWall2 = 0;
        }

        if (monsterWall3.activeSelf == true)
        {
            loadMonsterWall3 = 1;
        }
        if (monsterWall3.activeSelf == false)
        {
            loadMonsterWall3 = 0;
        }


        if (monsterWall4.activeSelf == true)
        {
            loadMonsterWall4 = 1;
        }
        if (monsterWall4.activeSelf == false)
        {
            loadMonsterWall4 = 0;
        }


        if (playerWall1.activeSelf == true)
        {
            loadPlayerWall1 = 1;
        }
        if (playerWall1.activeSelf == false)
        {
            loadPlayerWall1 = 0;
        }

        if (playerWall2.activeSelf == true)
        {
            loadPlayerWall2 = 1;
        }
        if (playerWall2.activeSelf == false)
        {
            loadPlayerWall2 = 0;
        }
        #endregion walls

        #region ships active check

        if (shipGrp00.activeSelf == true)
        {
            loadShip00 = 1;
        }
        if (shipGrp00.activeSelf == false)
        {
            loadShip00 = 0;
        }

        if (shipGrp0.activeSelf == true)
        {
            loadShip0 = 1;
        }
        if (shipGrp0.activeSelf == false)
        {
            loadShip0 = 0;
        }


        if (shipGrp1.activeSelf == true)
        {
            loadShip1 = 1;
        }
        if (shipGrp1.activeSelf == false)
        {
            loadShip1 = 0;
        }


        if (shipGrp2.activeSelf == true)
        {
            loadShip2 = 1;
        }
        if (shipGrp2.activeSelf == false)
        {
            loadShip2 = 0;
        }
        #endregion


        #region damaged farms active check
        if (damagedFarms[0] == null)
        {
            loadDamagedFarm0 = 0;
        }
        else
        {
            loadDamagedFarm0 = 1;
        }


        if (damagedFarms[1] == null)
        {
            loadDamagedFarm1 = 0;
        }
        else
        {
            loadDamagedFarm1 = 1;
        }


        if (damagedFarms[2] == null)
        {
            loadDamagedFarm2 = 0;
        }
        else
        {
            loadDamagedFarm2 = 1;
        }


        if (damagedFarms[3] == null)
        {
            loadDamagedFarm3 = 0;
        }
        else
        {
            loadDamagedFarm3 = 1;
        }


        if (damagedFarms[4] == null)
        {
            loadDamagedFarm4 = 0;
        }
        else
        {
            loadDamagedFarm4 = 1;
        }


        if (damagedFarms[5] == null)
        {
            loadDamagedFarm5 = 0;
        }
        else
        {
            loadDamagedFarm5 = 1;
        }
        #endregion

        #region powerorb active check

        /*
        for (int i = 0; i < allOrbs.Length; i ++)
        {
            loadOrbs[i] = allOrbs[i].activeSelf ? 1 : 0;
        }

        int i = 0;
        foreach (GameObject orb in allOrbs)
        {
            // Save
            loadOrbs[i] = orb.activeSelf ? 1 : 0;
            
            // Load
            allOrbs[i].SetActive(loadOrbs[i] == 1);
            
            i ++;
        }

        */

        if (allOrbs[0].activeSelf == true)
        {
            loadOrb0 = 1;
        }
        if (allOrbs[0].activeSelf == false)
        {
            loadOrb0 = 0;
        }


        if (allOrbs[1].activeSelf == true)
        {
            loadOrb1 = 1;
        }
        if (allOrbs[1].activeSelf == false)
        {
            loadOrb1 = 0;
        }


        if (allOrbs[2].activeSelf == true)
        {
            loadOrb2 = 1;
        }
        if (allOrbs[2].activeSelf == false)
        {
            loadOrb2 = 0;
        }

        if (allOrbs[3].activeSelf == true)
        {
            loadOrb3 = 1;
        }
        if (allOrbs[3].activeSelf == false)
        {
            loadOrb3 = 0;
        }


        if (allOrbs[4].activeSelf == true) 
        {
            loadOrb4 = 1;
        }
        if (allOrbs[4].activeSelf == false)
        {
            loadOrb4 = 0;
        }


        if (allOrbs[5].activeSelf == true)
        {
            loadOrb5 = 1;
        }
        if (allOrbs[5].activeSelf == false)
        {
            loadOrb5 = 0;
        }


        if (allOrbs[6].activeSelf == true)
        {
            loadOrb6 = 1;
        }
        if (allOrbs[6].activeSelf == false)
        {
            loadOrb6 = 0;
        }


        if (allOrbs[7].activeSelf == true)
        {
            loadOrb7 = 1;
        }
        if (allOrbs[7].activeSelf == false)
        {
            loadOrb7 = 0;
        }


        if (allOrbs[8].activeSelf == true)
        {
            loadOrb8 = 1;
        }
        if (allOrbs[8].activeSelf == false)
        {
            loadOrb8 = 0;
        }


        if (allOrbs[9].activeSelf == true)
        {
            loadOrb9 = 1;
        }
        if (allOrbs[9].activeSelf == false)
        {
            loadOrb9 = 0;
        }


        if (allOrbs[10].activeSelf == true)
        {
            loadOrb10 = 1;
        }
        if (allOrbs[10].activeSelf == false)
        {
            loadOrb10 = 0;
        }


        if (allOrbs[11].activeSelf == true)
        {
            loadOrb11 = 1;
        }
        if (allOrbs[11].activeSelf == false)
        {
            loadOrb11 = 0;
        }


        if (allOrbs[12].activeSelf == true)
        {
            loadOrb12 = 1;
        }
        if (allOrbs[12].activeSelf == false)
        {
            loadOrb12 = 0;
        }


        if (allOrbs[13].activeSelf == true)
        {
            loadOrb13 = 1;
        }
        if (allOrbs[13].activeSelf == false)
        {
            loadOrb13 = 0;
        }


        if (allOrbs[14].activeSelf == true)
        {
            loadOrb14 = 1;
        }
        if (allOrbs[14].activeSelf == false)
        {
            loadOrb14 = 0;
        }


        if (allOrbs[15].activeSelf == true)
        {
            loadOrb15 = 1;
        }
        if (allOrbs[15].activeSelf == false)
        {
            loadOrb15 = 0;
        }



        if (allOrbs[16].activeSelf == true)
        {
            loadOrb16 = 1;
        }
        if (allOrbs[16].activeSelf == false)
        {
            loadOrb16 = 0;
        }

        if (allOrbs[17].activeSelf == true)
        {
            loadOrb17 = 1;
        }
        if (allOrbs[17].activeSelf == false)
        {
            loadOrb17 = 0;
        }

        if (allOrbs[18].activeSelf == true)
        {
            loadOrb18 = 1;
        }
        if (allOrbs[18].activeSelf == false)
        {
            loadOrb18 = 0;
        }

        if (allOrbs[19].activeSelf == true)
        {
            loadOrb19 = 1;
        }
        if (allOrbs[19].activeSelf == false)
        {
            loadOrb19 = 0;
        }

        if (allOrbs[20].activeSelf == true)
        {
            loadOrb20 = 1;
        }
        if (allOrbs[20].activeSelf == false)
        {
            loadOrb20 = 0;
        }


        if (allOrbs[21].activeSelf == true)
        {
            loadOrb21 = 1;
        }
        if (allOrbs[21].activeSelf == false)
        {
            loadOrb21 = 0;
        }


        if (allOrbs[22].activeSelf == true)
        {
            loadOrb22 = 1;
        }
        if (allOrbs[22].activeSelf == false)
        {
            loadOrb22 = 0;
        }


        if (allOrbs[23].activeSelf == true)
        {
            loadOrb23 = 1;
        }
        if (allOrbs[23].activeSelf == false)
        {
            loadOrb23 = 0;
        }


        if (allOrbs[24].activeSelf == true)
        {
            loadOrb24 = 1;
        }
        if (allOrbs[24].activeSelf == false)
        {
            loadOrb24 = 0;
        }


        if (allOrbs[25].activeSelf == true)
        {
            loadOrb25 = 1;
        }
        if (allOrbs[25].activeSelf == false)
        {
            loadOrb25 = 0;
        }


        if (allOrbs[26].activeSelf == true)
        {
            loadOrb26 = 1;
        }
        if (allOrbs[26].activeSelf == false)
        {
            loadOrb26 = 0;
        }


        if (allOrbs[27].activeSelf == true)
        {
            loadOrb27 = 1;
        }
        if (allOrbs[27].activeSelf == false)
        {
            loadOrb27 = 0;
        }

        if (allOrbs[28].activeSelf == true)
        {
            loadOrb28 = 1;
        }
        if (allOrbs[28].activeSelf == false)
        {
            loadOrb28 = 0;
        }

        if (allOrbs[29].activeSelf == true)
        {
            loadOrb29 = 1;
        }
        if (allOrbs[29].activeSelf == false)
        {
            loadOrb29 = 0;
        }

        #endregion
    }
}
