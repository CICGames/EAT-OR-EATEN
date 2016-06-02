using UnityEngine;
using UnityEngine.Networking;

public class PickupSpawner : NetworkBehaviour {
    public GameObject pickupPrefab;
    public int NumberOfPickup1;
    public Terrain terrain;
    public GameObject parent;

    float x_range;
    float z_range;

    GameObject[] n_pickup1;

    // Use this for initialization
    void Start () {
        //get terrain size;
        x_range = terrain.terrainData.size.x;
        z_range = terrain.terrainData.size.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (NetworkServer.active) { 
            CreatePickup();
        }
    }

    void CreatePickup() {
        // get the number of object on the field
        n_pickup1 = GameObject.FindGameObjectsWithTag("Pickup1");

        if (n_pickup1.Length < NumberOfPickup1) {
            Vector3 spawnPosition = new Vector3(Random.Range(1, x_range), 10, Random.Range(1, z_range));
            GameObject pickup = (GameObject)Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
            pickup.transform.parent = parent.transform;
            NetworkServer.Spawn(pickup);// generate pickup at random position
        }
    }
    
}
