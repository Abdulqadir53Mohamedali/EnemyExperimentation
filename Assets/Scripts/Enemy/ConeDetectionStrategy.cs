using UnityEngine;

namespace EnemyExperimentation
{
    using Utilities;

    public class ConeDetectionStrategy : IDetectionStrategy
    {

        readonly float detectionAngle;
        readonly float detectionRadius;
        readonly float innerDetectionRadius;
        public ConeDetectionStrategy(float detectionAngle, float detectionRadius, float innerDetectionRadius)
        {
            this.detectionAngle = detectionAngle;
            this.detectionRadius = detectionRadius;
            this.innerDetectionRadius = innerDetectionRadius;

        }
        //public bool Execute(Transform player, Transform detector, CountDownTimer timer)
        //{
        //    var directionToPlayer = player.position - detector.position;
        //    var angleToPlayer = Vector3.Angle(directionToPlayer, detector.forward);

        //    if (!(angleToPlayer < detectionAngle / 2f) ||
        //        !(directionToPlayer.magnitude < detectionRadius) ||
        //        (directionToPlayer.magnitude < innerDetectionRadius))
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        public bool Execute(Transform player, Transform detector, CountDownTimer timer)
        {
            if (timer.IsRunning)
            {
                return false;
            }

            var directionToPlayer = player.position - detector.position;
            var angleToPlayer = Vector3.Angle(directionToPlayer, detector.forward);

            //IF the player is not within the detector angle + outer radius (aka the cone in front of the enemy)
            // or is within the inner radius , return false

            if (!(angleToPlayer < detectionAngle / 2f) || !(directionToPlayer.magnitude < detectionRadius) && !(directionToPlayer.magnitude < innerDetectionRadius))
            {
                return false;
            }

            timer.Start();
            return true;
        }

    }

}
