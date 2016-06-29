using UnityEngine;
using System.Collections;

public class LoadingEvent : MonoBehaviour {

    public delegate void ProgressEventHanlder();
    public static event ProgressEventHanlder onProgressFill;

    public static void ProgressFill() {
        if (onProgressFill != null)
            onProgressFill();
    }
}
