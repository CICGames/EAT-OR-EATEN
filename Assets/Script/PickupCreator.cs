using UnityEngine;
using System.Collections;

public class PickupCreator : MonoBehaviour {
    int pickup_count = 0;

    public Rigidbody pickup1;
    public int NumberOfPickup1;


    float x_range;
    float z_range;
    float x_axis;
    float y_axis;
    float z_axis;
    Terrain terrain;
    GameObject[] n_pickup1;

    // Use this for initialization
    void Start () {
        //get terrain size;
        terrain = GetComponent<Terrain>();
        x_range = terrain.terrainData.size.x;
        z_range = terrain.terrainData.size.z;
	}
	
	// Update is called once per frame
	void Update () {
        
        //get random position
        x_axis = Random.Range(1, x_range);
        z_axis = Random.Range(1, z_range);
        y_axis = terrain.terrainData.GetHeight((int)x_axis, (int)z_axis);
        Debug.Log(terrain.terrainData.GetHeight(69,72));
        // get the number of object on the field
        n_pickup1 = GameObject.FindGameObjectsWithTag("Pickup1");
        if (n_pickup1.Length < NumberOfPickup1) {
            var position = new Vector3(x_axis, 10, z_axis);
            Instantiate(pickup1, position, Quaternion.identity); // generate pickup at random position
        }


    }


}
