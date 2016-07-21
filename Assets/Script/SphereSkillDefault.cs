using System;
using UnityEngine;
using UnityEngine.Networking;

public class SphereSkillDefault : NetworkBehaviour, ISkill {

    // 케릭터 정보 갖고와서 스킬데미지에 반영.
    // PlayerController가 갖고있는 값과 동기화됨
    PlayerController character;

    public GameObject _skill_Default_Level1;
    public GameObject _skill_Default_Cannon;

    //생성자에서 넣어주려고 했는데 GetComponent로 생성자를 불러올수는 없음..
    //찾아보니 public변수에 유니티에서 객체를 넣어줄때부터 객체 생성이 되는듯..?
    public void initiate(PlayerController _character) {
        this.character = _character;
    }

    //void Update() {
    //    Debug.Log("123");
    //    CmdAttack();
    //}

    [SyncVar]
    bool isShoot = false;
    void Update() {
        if (isShoot) {
            Debug.Log("before2");
            CmdAttack();
        }
    }
    
    //기본 공격 함수
    [Command]
    public void CmdAttack() {
        Debug.Log("Server " + NetworkServer.active);
        Debug.Log("Client " + NetworkClient.active);
        GameObject bullet = (GameObject)Instantiate(_skill_Default_Level1, character._skill_Default_Spawn.position, character._skill_Default_Spawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6.0f;
        //ClientScene.RegisterPrefab(bullet);
        NetworkServer.Spawn(bullet);
        Destroy(bullet, 2);
    }

    //모션
    public bool CmdMotion() {
        return true;
    }
}
