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
    public BossEnemy boss;
    public Transform spawnEnemies;
    public Transform[] enemyGoToPos;
    //public int spawnIndex;
    public GameObject enemyToSpawn;
    public float lifeMax, life;
    public bool isProtected;
    public float timeShield, timeForShield;
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

    void TimeToShield()
    {
        if (!isProtected)
        {
            timeShield += Time.deltaTime;
            if (timeShield >= timeForShield)
            {
                timeShield = 0;
                SpawnEnemy();
                timeForShield = Random.Range(8, 10);
            }
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnEnemies.position, transform.rotation);
        ShieldEnemy enemy = newEnemy.GetComponent<ShieldEnemy>();
        enemy.lifeMax = 4;
        enemy.distanceShield = 5;
        enemy.bigBoss = boss;
        enemy.protectTarget = bossEnemy;
        enemy.enemyGoTo = enemyGoToPos;
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
        timeForShield = 5;

        HealPlayerUponSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        TimeToShield();

    }
}