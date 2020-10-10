using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Variable Life
    public int PlayerLife = 100;
    public const int maxPlayerLife = 100; 

    //Life display
    public Sprite emptyHearth;
    public Sprite halfHearth;
    public Sprite fullHearth;
    public Sprite emptyCase;
    public Image coeur1;
    public Image coeur2;
    public Image coeur3;
    public Image coeur4;
    public Image coeur5;
    public Image coeur6;

    private void GetDamage(int damage)
    {
        PlayerLife -= damage;
        print(PlayerLife);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnnemyAttack") ^ col.gameObject.CompareTag("Ennemy"))
        {
            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
        }
    }

    private void GetDeath()
    {
        Destroy(gameObject);
    }

    private void Health(Image coeur, float maxvalue, float midvalue, float minimumvalue)
    {
        if (maxvalue > maxPlayerLife)
        {
            coeur.sprite = emptyCase;
        }

        else if (PlayerLife <= maxvalue && PlayerLife > midvalue)
        {
            coeur.sprite = fullHearth;
        }

        else if (PlayerLife <= midvalue && PlayerLife > minimumvalue)
        {
            coeur.sprite = halfHearth;
        }

        else if (PlayerLife <= minimumvalue)
        {
            coeur.sprite = emptyHearth;
        }
    }

    private void ShowHealth()
    {
        Health(coeur6, 150f, 137.5f, 125f);
        Health(coeur5, 125f, 112.5f, 100f);
        Health(coeur4, 100f, 87.5f, 75f);
        Health(coeur3, 75f, 62.5f, 50f);
        Health(coeur2, 50f, 37.5f, 25f);
        Health(coeur1, 25f, 12.5f, 0f);
    }

    private void Update()
    {
        ShowHealth();

        if (PlayerLife <= 0)
        {
            GetDeath();
        }
    }

}
