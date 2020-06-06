using UnityEngine;

public class TutorialTransistorController : MonoBehaviour
{
    public enum Type { NPN, PNP }
    public Type type;

    public Animator transistorAnimator;
    public Animator wireAnimator;
    public TutorialButton topButton;
    public TutorialButton leftButton;
    public TutorialLight bottomLight;

    void Start()
    {

    }

    void Update()
    {
        if (type == Type.NPN) bottomLight.state = topButton.state && leftButton.state;
        if (type == Type.PNP) bottomLight.state = topButton.state && !leftButton.state;

        wireAnimator.SetBool("TopOn", topButton.state);
        wireAnimator.SetBool("LeftOn", leftButton.state);
        wireAnimator.SetBool("BottomOn", bottomLight.state);
    }

    public void FadeCasing(bool x)
    {
        transistorAnimator.SetBool("isFaded", x);
    }
}
