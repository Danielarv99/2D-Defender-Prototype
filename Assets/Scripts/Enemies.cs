using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float speed;
    public int enemiesKilled = 0;
    public GameManager gameManagerScript;
    public Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MakeDamage();
        DestroyAll();
        transform.Translate(Vector3.up * speed * Time.deltaTime * gameManagerScript.speedMultiplier);

    }

    void OnTriggerEnter2D (Collider2D  other)
    {
        if (other.gameObject.tag == "Bullet")
        {

            Destroy(gameObject);
            Destroy(other.gameObject);
            gameManagerScript.enemiesKilled++;
            enemyAnim.SetBool("isDead", true);
        }         
    }
    void MakeDamage()
    {
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
            gameManagerScript.lifes--;
        }
    }
    public void DestroyAll()
    {
        if (gameManagerScript.gameIsOver == true)
        {
            Destroy(gameObject);
        }
        
    }
}
