// Don't destroy on load


using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy instance;

    void Awake() {
        if (instance != null) Destroy(this);
        else {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
}
