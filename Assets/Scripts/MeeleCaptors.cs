using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeeleCaptors : MonoBehaviour
{
    [Header ("Properties")]
    //Made this into private since once this is initialized it would run the Start function where it assigns the player Object;
    private GameObject player;
    [SerializeField] private float MovementSpeed;


    [Header ("Public Attributes")]
    [SerializeField] private float distanceBetween;
    [SerializeField] private float distanceWonder;
    [SerializeField] private float range;
    [SerializeField] private AnimationClip IdleAnim;
    [SerializeField] private AnimationClip IdleTopAnim;
    [SerializeField] private AnimationClip IdleBottomAnim;

    private Animator anim;
    private string currentAnim;


    private float distance;
    private Vector2 wonder;
    void Start(){
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tracking the player distance against THIS distance
        distance = Vector2.Distance(transform.position, player.transform.position);
        // Approach if the distance is less than what is needed
        if(distance < distanceBetween){
            UpdateFace(this.transform.position, player.transform.position);
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, MovementSpeed*Time.deltaTime);
        } else {
            UpdateFace(this.transform.position, wonder);
            transform.position = Vector2.MoveTowards(this.transform.position, wonder, MovementSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, wonder) < range){
                wonder = new Vector2(Random.Range(-distanceWonder, distanceWonder), Random.Range(-distanceWonder, distanceWonder));
            }
        }
    }

    private void UpdateFace(Vector2 pos, Vector2 tar)
    {
        Vector2 dir = (tar - pos).normalized;
        if (pos.x > tar.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
        if(dir.x > 0 && dir.y > 0)
        {
            changeAnim(IdleAnim.name);

        }else if (dir.x > 0)
        {
            changeAnim(IdleAnim.name);
        }else if (dir.y > 0)
        {
            changeAnim(IdleTopAnim.name);
        }
        else if (dir.x < 0 && dir.y < 0)
        {
            changeAnim(IdleBottomAnim.name);
        } 
        else if (dir.x < 0)
        {
            changeAnim(IdleAnim.name);
        }
        else if (dir.y < 0)
        {
            changeAnim(IdleBottomAnim.name);
        }
        else
        {
            changeAnim(IdleAnim.name);
        }
        
    }

    private void changeAnim(string state)
    {
        if (currentAnim == state)
        {
            return;
        }
        else
        {
            anim.Play(state);
        }
    }
}
