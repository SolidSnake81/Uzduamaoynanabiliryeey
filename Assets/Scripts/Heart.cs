using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{






    // Its working but i dont want to make a hearth by hearth system i want a slider system 


    public int numberOfHearts; 

    public Image[] hearts; 

    public Sprite fullHeart; 

    public Sprite damagedHeart;

    Player player; 

    // Start is called before the first frame update
    void Start()
    {

         player=FindObjectOfType< Player>(); 



    }

    // Update is called once per frame
    void Update()
    {



        if (player.health >  numberOfHearts)

        {
            player.health = numberOfHearts; 
        }


                for (int i = 0; i<hearts.Length; i++)

               {

            if(i <numberOfHearts )
            {
                hearts[i].enabled = true; 
            }
             else
            {
                hearts[i].enabled = false; 
            }
            if (i < player.health)
            {
                hearts[i].sprite = fullHeart;
            }

             else
            {

                hearts[i].sprite = damagedHeart;

            }

        }

    }


}
