using NUnit.Framework.Constraints;
using Unity.VisualScripting;
using UnityEngine;


namespace EnemyExperimentation
{
    public class PlayerDetector : MonoBehaviour
    {
        [SerializeField] float detectionAngle = 60f; // Cone in front of enemy
        [SerializeField] float detectionRadius = 10f; // Large Circle around enemy
        [SerializeField] float innerDetectionRadius = 5f; // small circle around enemy
        [SerializeField] float detectionCooldown = 1f; // Time between detections
         


        public Transform Player { get; private set; }
        //cOUN
      
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

