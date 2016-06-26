using UnityEngine;
using UnityEngine.Networking;

public class Character : NetworkBehaviour {

    protected int _health;

    //Get mouse click point
    protected Vector3 ClickPoint(Vector3 _mousePosition, GameObject _playerCamera) {

        _mousePosition.z = GlobalData.MOUSE_POSITION_Z;

        return _playerCamera.GetComponent<Camera>().ScreenToWorldPoint(_mousePosition);        
    }

}
