using UnityEngine;

namespace EnemyExperimentation
{
    using Utilities;

    public interface IDetectionStrategy
    {
       public bool Execute(Transform player, Transform detector, CountDownTimer timer);
    }

}


