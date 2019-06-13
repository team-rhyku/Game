using System.Collections;

using UnityEngine;

public class Sprites : MonoBehaviour
{
    private Player player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)

    {
        if(col.CompareTag("Player"))
        {
            player.Damage(100);
        }
        
    }
}
