using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BossEnemy : MonoBehaviour
{
    //public GameManager gm;
    //public ScriptPlayer player;

    public Canvas canvasJuego;
    public Image bossHealthBar;
    public TextMeshProUGUI textoBossFight;
    public string textoFinal;
    public Sprite[] bossState;

    public Transform bossEnemy;
    public Transform spawnEnemies;
    //public int spawnIndex;
    public GameObject enemyToSpawn;
    public float lifeMax, life;
    public bool isProtected;
    public float damage;


    IEnumerator BossDeath()
    {
        Debug.Log("Boss muriendo epicamente");
        yield return new WaitForSeconds(3);
        BossDie();
    }

    void Health()
    {
        if (life > lifeMax)
        {
            life = lifeMax;
        }
        else if (life <= 0)
        {
            StartCoroutine(BossDeath());
        }
    }

    void UpdateHealth()
    {
        bossHealthBar.fillAmount = life / lifeMax;
    }

    void HealPlayerUponSpawn()
    {

    }

    public void TakeDamage(float dmg)
    {
        if (dmg == 0)
        {
            return;
        }

        if (!isProtected)
        {
            life -= dmg;
        }
        Health();
        UpdateHealth();
    }

    void BossDie()
    {
        this.gameObject.SetActive(!gameObject.activeSelf);

        canvasJuego.gameObject.SetActive(!gameObject.activeSelf);
        textoBossFight.text = textoFinal;
    }

    public void ActivateShield()
    {
        isProtected = true;
        SpriteRenderer bossMode = GetComponent<SpriteRenderer>();
        bossMode.sprite = bossState[1];
    }

    public void DeactivateShield()
    {
        isProtected = false;
        SpriteRenderer bossMode = GetComponent<SpriteRenderer>();
        bossMode.sprite = bossState[0];
    }

    void SpawnEnemy()
    {
        Instantiate(enemyToSpawn, spawnEnemies.position, transform.rotation);
    }

    void Attack()
    {
        
    }

    void ChargeAttack(bool isAttacking, float bulletPow, float bulletPowTarget)
    {
        if (isAttacking)
        {
            bulletPow += Time.deltaTime;
            if (bulletPow >= bulletPowTarget)
            {
                Attack();
                bulletPow = 0;
                isAttacking = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        life = lifeMax;

        HealPlayerUponSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
