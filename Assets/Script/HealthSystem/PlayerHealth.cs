using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Doit rajouter l'animation de prise de dégats 

    //Variable Life
    public float PlayerLife;
    public int maxPlayerLife = 100;
    public PlayerController controller;
    public YT_PCAnimationHandler animHandler;
    public PlayerShoot pcShoot;
    public bool isHurt;
    private Rigidbody2D playerBody;
    public bool isDead;

    //Life display
    public Sprite emptyHearth;
    public Sprite halfHearth;
    public Sprite fullHearth;
    public Sprite emptyCase;
    public Image[] coeurs;

    public GameObject MenuPause;

    private void Start()
    {
        isDead = false;
        isHurt = false;
        InstantiateScript();
    }

    private void FixedUpdate()
    {
        ShowHealth();

        checkMaxLife();

        animHandler.animator.SetInteger("Health", (int)PlayerLife);

        if (PlayerLife <= 0)
        {
            GetDeath();
        }
    }
    void InstantiateScript()
    {
        controller = GetComponent<PlayerController>();
        animHandler = GetComponent<YT_PCAnimationHandler>();
        pcShoot = GetComponent<PlayerShoot>();
    }

    private void GetDamage(float damage)
    {
        PlayerLife -= damage;
        print(PlayerLife);

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("EnnemyAttack") ^ col.gameObject.CompareTag("Ennemy"))
        {
            GetDamage(col.gameObject.GetComponent<Damager>().Damage());
            StartCoroutine(nameof(CheckDamages));
        }
    }

    // A finir (Rajout de l'animation de mort
    private void GetDeath()
    {
        isDead = true;
        controller.moveSpeed = 0f;

    }

    private void Health(Image coeur, float maxvalue, float midvalue, float minimumvalue)
    {
        if (maxvalue > maxPlayerLife)
        {
            coeur.sprite = emptyCase;
        }

        else if (PlayerLife >= maxvalue && PlayerLife >= midvalue)
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
        Health(coeurs[11], 300f, 287.5f, 275f);
        Health(coeurs[10], 275f, 262.5f, 250f);
        Health(coeurs[9], 250f, 237.5f, 225f);
        Health(coeurs[8], 225f, 212.5f, 200f);
        Health(coeurs[7], 200f, 187.5f, 175f);
        Health(coeurs[6], 175f, 162.5f, 150f);
        Health(coeurs[5], 150f, 137.5f, 125f);
        Health(coeurs[4], 125f, 112.5f, 100f);
        Health(coeurs[3], 100f, 87.5f, 75f);
        Health(coeurs[2], 75f, 62.5f, 50f);
        Health(coeurs[1], 50f, 37.5f, 25f);
        Health(coeurs[0], 25f, 12.5f, 0f);
    }

    private void checkMaxLife()
    {
        if (PlayerLife > maxPlayerLife)
        {
            PlayerLife = maxPlayerLife;
        }
    }

    IEnumerator CheckDamages()
    {
        isHurt = true;

        yield return new WaitForSeconds(0.1f);

        isHurt = false;
    }
}
