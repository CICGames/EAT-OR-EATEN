using UnityEngine;
using UnityEngine.Networking;



public interface ISkill {
    void initiate(PlayerController _charatcter);
    [Command]
    void CmdAttack();

    [Command]
    bool CmdMotion();

    GameObject CmdtestClient();
    void Cmdtest();
}
