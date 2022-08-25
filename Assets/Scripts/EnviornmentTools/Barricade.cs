using UnityEngine;

public class Barricade : MonoBehaviour
{
    // Based on a total number of set triggers. 
    // If Total triggers == current triggers then the door is open.
    public float totalNumberOfTriggers = 0;
    private float currentNumberOfTriggers = 0;
    private void OpenBarricade()
    {
        this.gameObject.SetActive(false);
    }

    private void CloseBarricade()
    {
        this.gameObject.SetActive(true);
    }

    private void CheckBarricadeTriggers()
    {
        if (currentNumberOfTriggers >= totalNumberOfTriggers)
        {
            OpenBarricade();
        }
        else
        {
            CloseBarricade();
        }
    }

    public void TriggerLink()
    {
        currentNumberOfTriggers++;
        CheckBarricadeTriggers();
    }

    public void UnLinkTrigger()
    {
        currentNumberOfTriggers--;
        CheckBarricadeTriggers();
    }
}
