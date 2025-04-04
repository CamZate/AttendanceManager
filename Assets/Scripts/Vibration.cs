using UnityEngine;

public class Vibration : MonoBehaviour {
    
    public void Vibrate(int x) {
        Vibrator.Vibrate(x);
        print("Vibrated for" + x);
    }
}