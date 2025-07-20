using UnityEngine;





namespace EnemyExperimentation
{
    public abstract class Timer
    {

        protected float initialTime;
        protected float Time { get; set; }


        public float Progress => Time / initialTime;

        //public Action
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
