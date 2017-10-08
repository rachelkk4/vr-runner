using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuHover : MonoBehaviour {

    private void OnMouseEnter()
    {
        GameObject text = this.gameObject;
        text.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
    }

    private void OnMouseExit()
    {
        GameObject text = this.gameObject;
        text.transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
