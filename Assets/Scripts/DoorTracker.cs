using UnityEngine;

public class DoorTracker : MonoBehaviour
{
    public GameObject DoorTwo;
    public GameObject DoorThree;

    LevelTracker LT;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        DoorTwo.gameObject.SetActive(false);
        DoorThree.gameObject.SetActive(false);
        LT = FindFirstObjectByType<LevelTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if(LT.LevelOneCompleted)
        {
        DoorTwo.gameObject.SetActive(true);
        }
        if(LT.LevelTwoCompleted)
        {
        DoorThree.gameObject.SetActive(true);
        }
    }
}
