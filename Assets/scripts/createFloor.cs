using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createFloor : MonoBehaviour
{
    public GameObject oldFloor;
    private GameObject newFloor;
    public GameObject leftSide, rightSide;
    private GameObject newLeftSide, newRightSide;
    private int randForSides, zeroSidesLeft, zeroSidesRight; 
    private int currentCreateFloor, currentDeleteFloor;
    public static bool upPlayer = false;
    public GameObject crystal;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        currentCreateFloor = 0;
        currentDeleteFloor = 1;
        newFloor = oldFloor;
        for(int i = 0; i < 25; i++)
        {
            CreateSides();
            CreateFloor();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DeleteSides();
            DeleteFloor();
        }
        if (upPlayer)
        {
            upLvlFloor();
            upPlayer = false;
        }
    }

    private void CreateFloor()
    {
        newFloor = Instantiate(oldFloor, newFloor.transform.GetChild(0).position, Quaternion.identity);
        currentCreateFloor++;
        newFloor.name = currentCreateFloor.ToString();

        //crystals
        randForSides = Random.RandomRange(0, 101);
        if (randForSides < 30)
        {
            GameObject newCrys = Instantiate(crystal, new Vector3(Random.RandomRange(-2.3f, 2.3f), newFloor.transform.position.y - 0.3f, 0), Quaternion.identity);
        }

        //enemy
        if (player.countJump > 30)
        {
            if (randForSides > 80)
            {
                GameObject newEnemy = Instantiate(enemy, new Vector3(newFloor.transform.position.x, newFloor.transform.position.y + 0.3f, 0), Quaternion.identity);
            }
        }
    }

    private void DeleteFloor()
    {
        GameObject deletedObj = GameObject.Find(currentDeleteFloor.ToString());
        Destroy(deletedObj);
        currentDeleteFloor++;
    }

    private void CreateSides()
    {
        //left
        randForSides = Random.RandomRange(0, 2);
        if (randForSides == 1)
        {
            newLeftSide = Instantiate(leftSide, newFloor.transform.GetChild(1).position, Quaternion.identity);
            newLeftSide.name = ("Left" + currentCreateFloor.ToString());
        } else
        {
            zeroSidesLeft++;
        }
        if (zeroSidesLeft >= 8)
        {
            newLeftSide = Instantiate(leftSide, newFloor.transform.GetChild(1).position, Quaternion.identity);
            newLeftSide.name = ("Left" + currentCreateFloor.ToString());
            zeroSidesLeft = 0;
        }
        //right
        randForSides = Random.RandomRange(0, 2);
        if (randForSides == 1)
        {
            newRightSide = Instantiate(rightSide, newFloor.transform.GetChild(2).position, Quaternion.identity);
            newRightSide.name = ("Right" + currentCreateFloor.ToString());
        }
        else
        {
            zeroSidesRight++;
        }
        if (zeroSidesRight >= 8)
        {
            newRightSide = Instantiate(rightSide, newFloor.transform.GetChild(2).position, Quaternion.identity);
            newRightSide.name = ("Right" + currentCreateFloor.ToString());
            zeroSidesRight = 0;
        }
    }

    private void DeleteSides()
    {
        GameObject deleteObj = GameObject.Find("Left" + currentDeleteFloor.ToString());
        Destroy(deleteObj);
        deleteObj = GameObject.Find("Right" + currentDeleteFloor.ToString());
        Destroy(deleteObj);
    }

    private void upLvlFloor()
    {
        DeleteSides();
        DeleteFloor();
        CreateSides();
        CreateFloor();
    }
}
