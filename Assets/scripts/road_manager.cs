using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class road_manager : MonoBehaviour {

    public GameObject[] roadPrefabs;
    public GameObject[] collectibles;
    private Transform playerTransform;

    private float spawnRoadZ = -4f;
    private float roadLength = 8f;
    private int maxRoadsOnScreen = 20;
    private List<GameObject> activeRoads;
    private int lastRoadIndex;
    private int DISTANCE_BETWEEN_COLOR_CHANGE_AREAS = 10;

    private float spawnColZ = 20f;
    private float CollectibleSpacing = 10f;
    private float maxCollectibleRowsOnScreen;
    private List<GameObject> activeCollectibles;
    private List<int> collectible_row_size;
 

    private int colorCangeCoolDown_Current;
    

	// Use this for initialization
	void Start () {

        maxCollectibleRowsOnScreen = 10*(roadLength/CollectibleSpacing);

        colorCangeCoolDown_Current = 0;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeRoads = new List<GameObject>();
        activeCollectibles = new List<GameObject>();
        collectible_row_size = new List<int>();
        lastRoadIndex = 0;

        for (int i = 0; i < maxRoadsOnScreen; i++) {
            spawnRoad(0);
        }

        for (int i = 0; i < maxCollectibleRowsOnScreen; i++) {
            int collectible_right = Random.Range(0, 2);
            int collectible_left = Random.Range(0, 2);
            int collectible_mid = Random.Range(0, 2);

            int right_collectible_index = -1;
            int left_collectible_index = -1;
            int mid_collectible_index = -1;

            int sizeof_collectibles = 0;


            if (collectible_right == 1)
            {
                right_collectible_index = Random.Range(0, 3);
                spawnCollectible(1, right_collectible_index);
                sizeof_collectibles += 1;
            }

            if (collectible_left == 1)
            {
                left_collectible_index = Random.Range(0, 3);
                while (left_collectible_index == right_collectible_index)
                {
                    left_collectible_index = Random.Range(0, 3);
                }
                spawnCollectible(-1, left_collectible_index);
                sizeof_collectibles += 1;
            }

            if (collectible_mid == 1)
            {
                mid_collectible_index = Random.Range(0, 3);
                while (mid_collectible_index == right_collectible_index || mid_collectible_index == left_collectible_index)
                {
                    mid_collectible_index = Random.Range(0, 3);
                }
                spawnCollectible(0, mid_collectible_index);
                sizeof_collectibles += 1;
            }


            collectible_row_size.Add(sizeof_collectibles);
            spawnColZ += CollectibleSpacing;
        }
	}
	
	// Update is called once per frame
	void Update () {


        manageCollectibles();

        //Whenever the player crosses a new road segment
        if (playerTransform.position.z - roadLength > (spawnRoadZ - maxRoadsOnScreen * roadLength))
        {
            if (colorCangeCoolDown_Current == 0)
            {
                spawnRoad();
                colorCangeCoolDown_Current = DISTANCE_BETWEEN_COLOR_CHANGE_AREAS;
            }
            else{
                spawnRoad(0);
                colorCangeCoolDown_Current--;
            }
                removeRoad();
        }

	}


    void manageCollectibles() {
        
        

        bool some_condition_that_will_fire_off_every_four_units = (playerTransform.position.z - CollectibleSpacing) > (spawnColZ - maxCollectibleRowsOnScreen*CollectibleSpacing);

        
        if (some_condition_that_will_fire_off_every_four_units)
        {
            
           

            int collectible_right = Random.Range(0, 2);
            int collectible_left = Random.Range(0, 2);
            int collectible_mid = Random.Range(0, 2);

            int right_collectible_index = -1;
            int left_collectible_index = -1;
            int mid_collectible_index = -1;

            int sizeof_collectibles = 0;
            

            if (collectible_right == 1)
            {
                right_collectible_index = Random.Range(0, 3);
                spawnCollectible(1, right_collectible_index);
                sizeof_collectibles += 1;
            }

            if (collectible_left == 1)
            {
                left_collectible_index = Random.Range(0, 3);
                while (left_collectible_index == right_collectible_index)
                {
                    left_collectible_index = Random.Range(0, 3);
                }
                spawnCollectible(-1, left_collectible_index);
                sizeof_collectibles += 1;
            }

            if (collectible_mid == 1)
            {
                mid_collectible_index = Random.Range(0, 3);
                while (mid_collectible_index == right_collectible_index || mid_collectible_index == left_collectible_index)
                {
                    mid_collectible_index = Random.Range(0, 3);
                }
                spawnCollectible(0, mid_collectible_index);
                sizeof_collectibles += 1;
            }


            collectible_row_size.Add(sizeof_collectibles);
            spawnColZ += CollectibleSpacing;
            removeCollectible();
        }
    }

    void spawnCollectible(float position, int prefabIndex) {
        GameObject collectible = Instantiate(collectibles[prefabIndex]);
        collectible.transform.SetParent(transform);
        collectible.transform.Translate(position * 2, 0f, spawnColZ);
        activeCollectibles.Add(collectible);
    }


    void removeCollectible(){
        for (int i = 0; i < collectible_row_size[0]; i++) {
            Destroy(activeCollectibles[0]);
            activeCollectibles.RemoveAt(0);
        }
        collectible_row_size.RemoveAt(0);
    }

    void removeRoad() {
        Destroy(activeRoads[0]);
        activeRoads.RemoveAt(0);
    }

    void spawnRoad(int prefabIndex = -1) {
        GameObject go;
        if (prefabIndex == -1)
        {
            int i = randomRoadIndex();
            go = Instantiate(roadPrefabs[i]) as GameObject;
        }else
            go = Instantiate(roadPrefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnRoadZ;
        spawnRoadZ += roadLength;
        activeRoads.Add(go);
    }

    int randomRoadIndex() { 
    
        int randomIndex = lastRoadIndex;
        while(randomIndex == lastRoadIndex){
            randomIndex = Random.Range(1, roadPrefabs.Length);
        }
        lastRoadIndex = randomIndex;
        return randomIndex;


    }
}
