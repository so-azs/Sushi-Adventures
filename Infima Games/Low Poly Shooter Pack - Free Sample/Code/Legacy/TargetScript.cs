using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class TargetScript : MonoBehaviour {  // Script Enemy + animation + Health Enemy

    [Header("Health Enemy")]
	public int health;
	public int maxHealth = 100;
	
	//Used to check if the target has been hit
	public bool isHit = false; // boollin Enemy true vs false
	[Header("Enemy AI")]
	public GameObject player;
	NavMeshAgent enemy;
	Animator anim; 


	private void Start() {

		health = maxHealth; 
        anim = GetComponent<Animator>(); // animator enemy
		enemy = GetComponent<NavMeshAgent>(); // Enemy AI
		player = GameObject.FindWithTag("Player");
	}

	


	private void Update () {

		enemy.SetDestination(player.transform.position);
		
		//If the target is hit
		if (isHit == true) 
		{
			healthDamage(1);
			isHit = false;
			
			//Debug.Log("oooooo!");
		}
	}
	public void healthDamage(int h) // fonction health Damage Enemy
	{
		health = health - h;

		if(health <=0)
			{
				anim.SetTrigger("Dead"); // animation Dead 
				StartCoroutine(TimeOverEnemt()); // Active Time Enemy over
                //Destroy(gameObject);
			}
	}

	IEnumerator TimeOverEnemt() // Time Enemy over
	{
		yield return new WaitForSeconds(3);
		Destroy(gameObject); // Destroy Enemy
		enemy.speed = 0f;
	}

}