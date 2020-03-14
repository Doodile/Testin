using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolTipText_Nick : MonoBehaviour
{
    GameObject PlayerRef;
    TextMesh text;
    float speed = 2;
    float size = 0.7f;
    Vector3 RaisedPos = Vector3.up;

    void Awake()
    {
        text = GetComponent<TextMesh>();
        PlayerRef = Camera.main.gameObject;
    }

    void Start()
    {
        transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - PlayerRef.transform.position);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(size, size, size), Time.deltaTime * speed);
    }

    public void SetText(string setTo)
    {
        text.text = setTo;
    }

    public void SetScale(float newscale)
    {
        size = newscale;
    }

    public void SetUpPos(Vector3 pos)
    {
        RaisedPos = pos;
    }

}
