using UnityEngine;



public class PlayerController : MonoBehaviour
{
    [Header("ĳ���� ����")]
    public string playerName = "�÷��̾�";
    public float moveSpeed = 5.0f;
    // Animator ������Ʈ ���� (private - Inspector�� �� ����)
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // ���� ���� �� �� ���� - Animator ������Ʈ ã�Ƽ� ����
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log("�ȳ��ϼ���, " + playerName + "��!");
        Debug.Log("�̵� �ӵ�: " + moveSpeed);

        // �����: ����� ã�Ҵ��� Ȯ��
        if (animator != null)
        {
            Debug.Log("Animator ������Ʈ�� ã�ҽ��ϴ�!");
        }
        else
        {
            Debug.LogError("Animator ������Ʈ�� �����ϴ�!");
        }
    }

    void Update()
    {
        // �̵� ���� ���
        Vector3 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1); // X�� ������
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            transform.localScale = new Vector3(1, 1, 1); // ���� ũ��
        }


        // ���� �̵� ����
        if (movement != Vector3.zero)
        {
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }


        // �ӵ� ���: �̵� ���̸� moveSpeed, �ƴϸ� 0
        float currentSpeed = movement != Vector3.zero ? moveSpeed : 0f;

        // �޸��� �ӵ� ���
        float currentMoveSpeed = moveSpeed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentMoveSpeed = moveSpeed * 2f;
            Debug.Log("�޸��� ��� Ȱ��ȭ!");
        }
        // ���� �Է� (�� ���� ����Ǿ�� �ϹǷ� GetKeyDown!)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetBool("Jump", true);
                Debug.Log("����!");
            }
        }

        // �̵��� �� ���� �ӵ� ���
        transform.Translate(movement * currentMoveSpeed * Time.deltaTime);

        // Animator�� �ӵ� ����
        if (animator != null)
        {
            animator.SetFloat("speed", currentSpeed);
            Debug.Log("Current Speed: " + currentSpeed);
        }
    }
}