using UnityEngine;

public class ScrollingScript : MonoBehaviour
{
    private float camerax;
    private float cameray;

    // Update is called once per frame
    void Update () {
        camerax = Camera.main.transform.position.x;
        cameray = Camera.main.transform.position.y;
        transform.position = new Vector3(camerax * 0.9f , cameray * 0.9f + 1, transform.position.z);
    }
}