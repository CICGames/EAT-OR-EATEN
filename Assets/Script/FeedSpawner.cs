using UnityEngine;
using UnityEngine.Networking;

public class FeedSpawner : NetworkBehaviour {
    public GameObject _feedPrefab;
    public int _numberOfPickup1;
    public Terrain _terrain;
    public GameObject _parent;

    float _x_range;
    float _z_range;

    GameObject[] _newFeeds;

    // Use this for initialization
    void Start () {
        //get terrain size;
        _x_range = _terrain.terrainData.size.x;
        _z_range = _terrain.terrainData.size.z;
	}
	
	// Update is called once per frame
	void Update () {
        if (NetworkServer.active) { 
            CreatePickup();
        }
    }

    void CreatePickup() {
        // get the number of object on the field
        _newFeeds = GameObject.FindGameObjectsWithTag("Feed_Square");

        if (_newFeeds.Length < _numberOfPickup1) {
            Vector3 _spawnPosition = new Vector3(Random.Range(1, _x_range), 10, Random.Range(1, _z_range));
            GameObject _pickup = (GameObject)Instantiate(_feedPrefab, _spawnPosition, Quaternion.identity);
            _pickup.transform.parent = _parent.transform;
            NetworkServer.Spawn(_pickup);// generate pickup at random position
        }
    }
    
}
