using UnityEngine;
using System.Collections;

public class GlobalData {

    //서버 아이피
    public const string SERVER_IP = "192.168.0.2";

    //접속 포트
    public const int PORT = 7777;

    //마우스 클릭 포인트 지정
    public const float MOUSE_POSITION_Z = 4f;

    //먹이 먹었을때 커지는 비율
    public const float EXPEND_RATE = 0.1f;
    
    //케릭터 크기에 따른 카메라 거리
    public const float DISTANCE_RATE = 4.3f;

    // 씬 정보
    public const string INTRO_SCENE = "Intro";
    public const string MAIN_SCENE = "Main";

}
