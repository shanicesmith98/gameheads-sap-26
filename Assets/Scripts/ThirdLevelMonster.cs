using UnityEngine;

public class ThirdLevelMonster : MonoBehaviour
{
    public bool startMoving = false;
    public float Speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(startMoving)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime);
        }
    }
    //test
}
