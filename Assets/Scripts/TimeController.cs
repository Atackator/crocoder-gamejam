// using UnityEngine;
// using System.Collections.Generic;
// using UnityEngine;

// public class TimeController : MonoBehaviour
// {
//     // // Start is called once before the first execution of Update after the MonoBehaviour is created
//     // void Start()
//     // {
        
//     // }

//     // // Update is called once per frame
//     // void Update()
//     // {
        
//     // }

//     public Vector2 velocity;
//     public AnimationClip currentAnimation;
//     public float animationTime;


//     public virtual void TimeUpdate() {
//         if (currentAnimation != null) {
//             animationTime += Time.deltaTime * currentAnimation.length;
//             if (animationTime >= currentAnimation.length) {
//                 animationTime = animationTime - currentAnimation.length;
//             }
//         }
//     }

//     public void UpdateAnimation() {
//         if (currentAnimation != null) {
//             currentAnimation.SampleAnimation(gameObject, animationTime);
//         }
//     }
// }


using UnityEngine;
using System.Collections.Generic;

public class TimeController : MonoBehaviour
{
    public Vector2 velocity;
    public AnimationClip currentAnimation;
    public float animationTime;

    public bool isRewinding = false;
    private float recordDuration = 5f; // how many seconds to remember
    private float timePerRecord = 0.02f; // how often to record (every 20ms)

    private float recordTimer = 0f;

    private struct TimeSnapshot
    {
        public Vector3 position;
        public Vector2 velocity;
        public float animationTime;
    }

    private List<TimeSnapshot> history = new List<TimeSnapshot>();

    public virtual void TimeUpdate()
    {
        if (isRewinding)
        {
            RewindTime();
        }
        else
        {
            RecordTime();

            if (currentAnimation != null)
            {
                animationTime += Time.deltaTime * currentAnimation.length;
                if (animationTime >= currentAnimation.length)
                {
                    animationTime -= currentAnimation.length;
                }
            }
        }
    }

    void RecordTime()
    {
        recordTimer += Time.deltaTime;
        if (recordTimer >= timePerRecord)
        {
            recordTimer = 0f;

            history.Insert(0, new TimeSnapshot
            {
                position = transform.position,
                velocity = velocity,
                animationTime = animationTime
            });

            // Trim history
            int maxRecords = Mathf.RoundToInt(recordDuration / timePerRecord);
            if (history.Count > maxRecords)
            {
                history.RemoveAt(history.Count - 1);
            }
        }
    }

    void RewindTime()
    {
        if (history.Count > 0)
        {
            TimeSnapshot snapshot = history[0];
            history.RemoveAt(0);

            transform.position = snapshot.position;
            velocity = snapshot.velocity;
            animationTime = snapshot.animationTime;
        }
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }

    public void UpdateAnimation()
    {
        if (currentAnimation != null)
        {
            currentAnimation.SampleAnimation(gameObject, animationTime);
        }
    }
}
