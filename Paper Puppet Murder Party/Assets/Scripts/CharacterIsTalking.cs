using UnityEngine;

public class CharacterIsTalking : MonoBehaviour
{
    public bool isTalking_;
    public float bounceSpeed_;
    public float bounceTime_;

    private float bounceUpTimer;
    private float bounceDownTimer;

    private float currentY;

    private void Start()
    {
        bounceUpTimer = bounceTime_;
        bounceDownTimer = 0;
        currentY = transform.position.y;
    }

    private void Update()
    {
        if (isTalking_)
        {
            // bounce character up
            if (bounceUpTimer > 0.0f)
            {
                bounceUpTimer -= Time.deltaTime;
                transform.localPosition = new Vector3(transform.localPosition.x, currentY += bounceSpeed_ * Time.deltaTime, transform.localPosition.z);

                // bounce timer completed this frame
                if (bounceUpTimer <= 0.0f)
                {
                    bounceUpTimer = 0.0f;
                    bounceDownTimer = bounceTime_ + Random.Range(-0.05f, 0.05f);
                }
            }
            else if (bounceDownTimer > 0.0f)
            {
                bounceDownTimer -= Time.deltaTime;
                transform.localPosition = new Vector3(transform.localPosition.x, currentY -= bounceSpeed_ * Time.deltaTime, transform.localPosition.z);

                // bounce timer completed this frame
                if (bounceDownTimer <= 0.0f)
                {
                    bounceDownTimer = 0.0f;
                    bounceUpTimer = bounceTime_;
                }
            }
        }
    }
}
