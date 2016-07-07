using UnityEngine;
using UnityEngine.Networking;



public interface ISkill {
    void initiate(Character _charatcter);
    void CmdAttack();
    bool CmdMotion();
}
