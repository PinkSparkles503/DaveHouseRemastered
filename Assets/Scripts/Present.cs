using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Present : MonoBehaviour
{
    public Transform player;
    public float collectDistance;
    public GameManager gameManager;

    public Shader HSVShader;
    public Material presentMaterial;
    void Start()
    {
        Material colorFunny = new Material(presentMaterial);
        colorFunny.shader = HSVShader;
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();
        sprite.material = colorFunny;
        sprite.material.SetVector("_HSVAAdjust", new Vector4(Random.Range(0f, 1f), 0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && Time.timeScale != 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if(Physics.Raycast(ray, out raycastHit) && (raycastHit.transform.tag == "Present" & Vector3.Distance(player.position, transform.position) < collectDistance))
            {
                transform.position = new Vector3(transform.position.x, -20, transform.position.z);
                gameManager.CollectPresent();
            }
        }
    }
}
