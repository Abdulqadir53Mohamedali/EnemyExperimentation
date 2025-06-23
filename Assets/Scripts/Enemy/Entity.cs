using UnityEngine;




namespace EnemyExperimentation
{
    public abstract class Entity : MonoBehaviour
    {

        //[SerializeField] EnemyStats stats;


        protected float currentHealth;


        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected virtual void Start()
        {
            Debug.Log("Health is zero");

            //currentHealth = stats.maxHealth;
        }

        public virtual void TakeDamage(float amount )
        {
            currentHealth -= amount;
            if(currentHealth < 0 )
            {
                Debug.Log("Health is zero");
                //Die();
            }
        }

        //protected abstract void Die();

        // Update is called once per frame
        void Update()
        {

        }
    }
}

