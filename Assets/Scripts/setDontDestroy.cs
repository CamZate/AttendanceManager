using UnityEngine;

public class setDontDestroy : MonoBehaviour
{
    public static setDontDestroy instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}