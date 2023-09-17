using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemanager : MonoBehaviour
{
    public GameObject Tiles;
    public int zSpawn = 0;
    public int tileLength = 30;
    private int TileCounter = 0;
    private int Tilenumber = 4;
    private float[] lanepicker = { 2.5f, 0.0f, -2.5f };
    public GameObject[] obstcales;
    public GameObject[] orbs;
    public GameObject[] coins;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    private List<GameObject> activeObj = new List<GameObject>();
    private Quaternion Obsquat= new Quaternion(-89.98f,0,0,0);
    private float laneOrb = 2.5f;
    private float laneObs = -2.5f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Tilenumber; i++)
        {
            SpawnTile();
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z -35 > zSpawn - (Tilenumber * tileLength)){
            SpawnTile();
            DeleteTile();
           
        }
        if (playerTransform.position.z - 35 > zSpawn - (Tilenumber * tileLength))
        {

            DeleteStuff();
        }
    }
    public void SpawnTile()
    {
        if (TileCounter < 2)
        {
            GameObject go= Instantiate(Tiles, transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go);
            zSpawn += tileLength;
            TileCounter++;
        }
        else
        {
            GameObject go = Instantiate(Tiles, transform.forward * zSpawn, transform.rotation); 
            //Instantiate(Tiles, transform.forward * zSpawn, transform.rotation);
            activeTiles.Add(go);
            zSpawn += tileLength;
            TileCounter++;
            while (true)
            {
                laneObs = PickLane(lanepicker);
                laneOrb = PickLane(lanepicker);
                if (laneObs != laneOrb)
                {
                    break;
                }
            }
            GameObject gi=Instantiate(PickObj(obstcales), GenerateRand(laneObs), Quaternion.identity);
            activeObj.Add(gi);
            for (int j = 0; j < (Random.Range(1, 3)); j++) {
                GameObject gd=Instantiate(PickObj(orbs), GenerateRand(laneOrb), Quaternion.identity);
                activeObj.Add(gd);
            }
            }

        }
    
    Vector3 GenerateRand(float lane)
    {
        float x, z;
        x = lane;
        // y = Random.Range(-10,10);
        z = Random.Range(zSpawn + 2, zSpawn + 28);
        return new Vector3(x, 0.5f, z);
    }
    float PickLane(float[] options)
    {
            int randomIndex =(int) Random.Range(0, options.Length); 
            float lane =options[randomIndex];
        return lane;
        }
    GameObject PickObj(GameObject[] options)
    {
        int randomIndex = (int)Random.Range(0, options.Length);
        GameObject Obj = options[randomIndex];
        return Obj;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private void DeleteStuff()
    {
        for (int i = 0; i < 8; i++)
        {
            Destroy(activeObj[i]);
            activeObj.RemoveAt(i);
        }
    }

}
