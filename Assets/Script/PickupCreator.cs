using UnityEngine;
using System.Collections;

public class PickupCreator : MonoBehaviour {
    int pickup_count = 0;

    public Rigidbody pickup1;
    public int NumberOfPickup1;


    float x_axis;
    float z_axis;
    
    GameObject[] n_pickup1;

    // Use this for initialization
    void Start () {
        //get terrain size;
        Terrain t = GetComponent<Terrain>();
        x_axis = t.terrainData.size.x;
        z_axis = t.terrainData.size.z;
	}
	
	// Update is called once per frame
	void Update () {
        //check the number of pickup1
        n_pickup1 = GameObject.FindGameObjectsWithTag("Pickup1");
        if (n_pickup1.Length < NumberOfPickup1) {
            var position = new Vector3(Random.Range(1, x_axis), 10 , Random.Range(1, z_axis));
            Instantiate(pickup1, position, Quaternion.identity); // generate pickup at random position
        }


    }


}
