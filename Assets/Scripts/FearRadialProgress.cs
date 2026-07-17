using UnityEngine;

public class FearRadialProgress : MonoBehaviour
{
     public int maxHealth = 100;
    public int currentHealth;

    public Transform fearDial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

   
    }
}




/*
list of things to code for ts shit

Have a bool to determine whether it increases automatically, or by how much damage a hazard has done (grab variables from game manager)
have the total health (100) be related to 180 degress (100 = 180°)(0 = 0°)
If the pointer rotates a full 180 degrees, then that means it has reached max fear, so like game over
I should also convert damage to degrees, so like 1 damage would equal 1.8° degress added
Also the point should start at 0 degrees after each level restart.

this may depend, but i should see if there is a way to make the pointer rotate smoothly, 
rather than just going from one point to another automatically cuz thats gonna look ugly

the end 

*/
