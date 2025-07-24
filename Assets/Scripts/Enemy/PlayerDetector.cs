using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;


namespace EnemyExperimentation
{
    using Utilities;

    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] float detectionAngle = 60f; // Cone in front of enemy
        [SerializeField] float detectionRadius = 10f; // Large Circle around enemy
        [SerializeField] float innerDetectionRadius = 5f; // small circle around enemy
        [SerializeField] float detectionCooldown = 1f; // Time between detections
        [SerializeField] float attackRange = 2f; // Time between detections
         


        public Transform Player { get; private set; }
        CountDownTimer detectionTimer;

        IDetectionStrategy detectionStratergy;
        
      
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            detectionTimer = new CountDownTimer(detectionCooldown);
            Player = GameObject.FindWithTag("Player").transform;
            detectionStratergy = new ConeDetectionStrategy(detectionAngle, detectionRadius, innerDetectionRadius);
        }

        // Update is called once per frame
        void Update() => detectionTimer.Tick(Time.deltaTime);
        public bool CanAttackPlayer()
        {
            var directionToPlayer = Player.position - transform.position;
            return directionToPlayer.magnitude <= attackRange;
        }
        //public bool CanDetectPlayer()
        //{
        //    bool detected = detectionStratergy.Execute(Player, transform, detectionTimer);

        //    if (detected && !detectionTimer.IsRunning)
        //    {
        //        detectionTimer.Start();
        //        // Optional: Play sound, trigger animation, etc.
        //    }

        //    return detected;
        //}

        public bool CanDetectPlayer()
        {
            return detectionTimer.IsRunning || detectionStratergy.Execute(Player, transform, detectionTimer);
        }

        public void SetDetectionStrategy(IDetectionStrategy detectionStrategy) => this.detectionStratergy = detectionStratergy;
    }


}

