using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] private Animator ani;
    public void AnimationTurnOff()
    {
        ani.SetBool("GotHit", false);
        Debug.Log("as;ljkf;alskdf");
    }
}
