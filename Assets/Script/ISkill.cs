using UnityEngine;
using UnityEngine.Networking;



public interface ISkill {
    void initiate(PlayerController _charatcter);
    [Command]
    void CmdAttack(Vector3 _spawnPosition, Quaternion _spawnRotation);

    [Command]
    bool CmdMotion();
}
