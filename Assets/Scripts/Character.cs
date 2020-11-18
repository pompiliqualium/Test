using UnityEngine;




public class Character : MonoBehaviour
{
    public float Speed = 50f;
    public bool isGrounded = false;
    public float jumpPower = 150f;
    private bool isFacingRight = true;
    private bool HasJumpedTwice = false;
    public float MaxHP = 100f;
    public float currentHP;

    private Rigidbody2D rigidbody2D;

    private BoxCollider2D boxCollider2D;
    private Vector2 defaultColliderSize;
    private Vector2 currentPosition;
    public HPBar hpBar;
    private int boi =10;

    float colliderOffsetY;


    private void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        defaultColliderSize = boxCollider2D.size;
        currentPosition = rigidbody2D.position;
        currentHP = MaxHP;
        hpBar.SetMaxHP(MaxHP);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            HasJumpedTwice = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Ground")) {
            isGrounded = false;
            
        }
    }


    public void Initialize(float speed,float jumpPower) {
        Speed = speed;
        this.jumpPower = jumpPower;
    }

    public void Move(Vector2 direction) {
        rigidbody2D.AddForce(direction * Speed);
        if(direction.x > 0 && !isFacingRight) {
            Flip();
        } else if(direction.x < 0 && isFacingRight) {
            Flip();
        }
    }

    public void Jump() {
        if(isGrounded || !HasJumpedTwice)
            rigidbody2D.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);

        if(!isGrounded ) {
            HasJumpedTwice = true;
        }
    }

    public void Duck() {



        boxCollider2D.size = new Vector2(defaultColliderSize.x,defaultColliderSize.y / 2);
        colliderOffsetY = defaultColliderSize.y / 2 / 2;
        boxCollider2D.offset = new Vector2(boxCollider2D.offset.x,boxCollider2D.offset.y - colliderOffsetY);


    }

    public void GetUp() {
        boxCollider2D.size = defaultColliderSize;
        boxCollider2D.offset = new Vector2(boxCollider2D.offset.x,boxCollider2D.offset.y + colliderOffsetY);
    }


    private void Flip() {
        transform.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
    }

    public void TakeDamage(float damage) {
        currentHP -= damage;
        hpBar.SetHealth(currentHP);
    }

}
