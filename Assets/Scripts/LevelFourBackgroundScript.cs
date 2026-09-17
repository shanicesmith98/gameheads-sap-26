using UnityEngine;

public class LevelFourBackgroundScript : MonoBehaviour
{
    private float startPosX;
    public GameObject camera;
    public float parallaxEffect;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosX = transform.position.x;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceX = camera.transform.position.x * parallaxEffect;


        transform.position = new Vector3(startPosX+distanceX,transform.position.y,transform.position.z); //1 = move with cam .... 0 = wont move
    }
}
