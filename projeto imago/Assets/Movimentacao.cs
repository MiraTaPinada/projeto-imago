using UnityEngine;

namespace projeto_imago
{
    public class Movimentacao : MonoBehaviour
    {
        public float pulo = 6f;
        public float speed = 6f;
        private Rigidbody2D rb;
        private bool canJump = true;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            MoveWithKeys();
        }
        
        void MoveWithKeys()
        {
            var left = Input.GetKey(KeyCode.A);
            var right = Input.GetKey(KeyCode.D);

            var horizontal = left ? -1 : right ? 1 : 0;

            transform.position += new Vector3(horizontal, 0, 0).normalized * speed * Time.deltaTime;


            var jump = Input.GetKey(KeyCode.Space);
            if (jump&&canJump)
            {
                rb.AddForce(Vector2.up *pulo , ForceMode2D.Impulse);
                canJump = false;
            }

        }
        void OnCollisionEnter(Collision other)
        {
            Debug.Log("s");
            canJump = true;
        }
    }
}