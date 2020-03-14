using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipSpawner_Nick : MonoBehaviour
{
    //The Tooltip to Display
    public string ToolTipText = "Sample Text";
    //Size of Tooltip (Should be positive and less than 1)
    public float tooltipSize = 1;
    //How long before tip should disappear
    public float DisappearDelay = 0.5f;

    //Is the player looking at this object?
    bool lookingAt = false;

    //References
    public GameObject ToolTipFab;
    ToolTipText_Nick ToolTipTextRef;
    GameObject ToolTipObject;
    float disappearTime = 0;
    MeshRenderer renderboi;

    // Start is called before the first frame update
    void Start()
    {
        //ToolTipTextRef = ToolTipFab.GetComponent<ToolTipText_Nick>();
        renderboi = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(lookingAt && Time.time > disappearTime)
        {
            EndLookAt();
        }
    }

    //Call this when player look at this object.
    public virtual void LookAt()
    {
        if (!lookingAt && Time.time > disappearTime)
        {
            DisplayTooltip();
        }
        lookingAt = true;
        disappearTime = Time.time + DisappearDelay;
    }

    //Player stops looking at the Object
    public virtual void EndLookAt()
    {
        lookingAt = false;
        HideToolTip();
    }

    //Change the text to be displayed.
    public void UpdateToolTipText(string newText)
    {
        ToolTipText = newText;
        if(lookingAt)
        {
            HideToolTip();
            DisplayTooltip();
        }
    }

    internal void DisplayTooltip()
    {
        ToolTipObject = Instantiate(ToolTipFab, transform.position, Quaternion.identity);
        ToolTipText_Nick spawned = ToolTipObject.GetComponent<ToolTipText_Nick>();
        spawned.SetText(ToolTipText);
        spawned.SetScale(tooltipSize);
        renderboi.material.EnableKeyword("_EMISSION");
        renderboi.material.SetColor("_EmissionColor", (Color.yellow / 2));
    }

    internal void HideToolTip()
    {
        Destroy(ToolTipObject);
        renderboi.material.DisableKeyword("_EMISSION");
    }

    void OnDestroy()
    {
        Destroy(ToolTipObject);
    }
}
