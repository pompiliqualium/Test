using NaughtyAttributes;
using UnityEngine;

public class PlayerPerspective : MonoBehaviour
{
    private Vector2 velocity;
    public float smoothTimeX;
    public float smoothTimeY;

    public GameObject character;

    public bool hasBounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;
      

    void Start() {
        character = GameObject.FindGameObjectWithTag("Character");
    }

    private void FixedUpdate() {
        FollowPlayer();
        
    }

    private void FollowPlayer() {
        float posX = Mathf.SmoothDamp(transform.position.x,character.transform.position.x,ref velocity.x,smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y,character.transform.position.y,ref velocity.y,smoothTimeY);

        transform.position = new Vector3(posX,posY,transform.position.z);

        if(hasBounds) {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x,minCameraPos.x,maxCameraPos.x),
                Mathf.Clamp(transform.position.y,minCameraPos.y,maxCameraPos.y),
                Mathf.Clamp(transform.position.z,minCameraPos.z,maxCameraPos.z));
        }
    }

    [Button("Set min Camera Position")]
    public void SetMinCamPosition() {
        minCameraPos = gameObject.transform.position;
    }

    [Button]
    public void SetMaxCamPosition() {
        maxCameraPos = gameObject.transform.position;
    }



}
