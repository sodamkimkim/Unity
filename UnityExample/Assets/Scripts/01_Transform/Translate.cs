
// # Name - Space (���� �����̽�)
// �� using 
using System.Collections;
using System.Collections.Generic;

//using UnityEngine;
// �� ex) ���� UnityEngine.MonoBehaviour �̷��� ��� �ϴµ�, using (name-space)������� MonoBehavior�̷��� �� �� ����.


// # C#�� #include�� ������ϰ����� ��ã�´�. ��� class�� == file�� => fileã�� �� class�� ����ϸ� �ٷ� ã�� �� �ְ� ����Ǿ� �ִ�.
// �� Ŭ������ ��Ȯ�ϰ� �����ϰ�, �ش� ��ü �̿� �ٸ� ����� ������ �ȵȴ�.

// # MonoBehaviour : MonoBehaviour is the base class from which every Unity script derives.
// �� MonoBehaviour�� �־�� component�� ���� �� �ִ�.
public class Translate : UnityEngine.MonoBehaviour
{
    // # Ŭ���� ��� ���� (Class Member Variables)
    // # ��� ���� ���� ������ (Member Access Modifier)
    // �� public, private, protected(��Ӱ���)

    private int value = 10;
    
    // Ŭ���� ��ü(Class-Object)
    private UnityEngine.Transform tr = null; // Transform ������ class���� �� �� �ְ� null�� �ʱ�ȭ.. -> ������ ����� ����ϰ� ���( for �ּ� ����)

    public void Func()
    {
        UnityEngine.Debug.Log("value: " + value);
    }

    // << Unity Script Life-Cycle >> -> MonoBehavior�� ���ǵǾ� �ִ�.

    // # start() 
    // �� ù ��° �������� �׷����� ���� ȣ��ȴ�.
    // Start is called before the first frame update
    // ��� ���� ���� ������ default�� private��. ( void Start() == private void Start() )
    private void Start()
    {
        UnityEngine.Debug.Log("Start");

        // # Template ( Generic type)
        // component �ڷ����� Transform (<Transform> ���׸�). ������ null�� �ʱ�ȭ��. => ����ó�� �ʿ�
        tr = this.GetComponent<UnityEngine.Transform>();
        // �� �� ������Ʈ(�� ��ũ��Ʈ)�� �پ��ִ� ���� ������Ʈ(this, named 'Translate' ť��)���� �� ������Ʈ(<Transform>)�� �ּ���
        if(tr == null)
        {
            UnityEngine.Debug.LogError("tr is null!");
        }

        // # public class Transform : Component , IEnumerable
        // # public Vector3 position { get; set; }
        // �� ��ǻ�� 3���� ���� vector�� ǥ��
        //tr.position = tr.position + (UnityEngine.Vector3.right * 2f); // Vector3.right�� 1,0,0 ���⺤�� => ( 2, 0, 0 )
        //UnityEngine.Vector3.Dot : ����
        //UnityEngine.Vector3.Magnitude : ���� ����
    }

    // # Update()
    // �� Update is called once per frame
    // �� �����Ӹ��� ����. ����Ƽ�� 1�ʿ� 60�� frame�� �׷�����. - > 1�ʿ� 60�� update()ȣ��ȴ�. 
    // ex) Ű�Է� ��� �̺�Ʈ ������ ���� �ۼ��Ѵ�.
    private void Update()
    {
        // # tr.position = tr.position + (UnityEngine.Vector3.right);
        // �� 1�ʴ� (60, 0, 0)
        
        // # tr.position = tr.position + (UnityEngine.Vector3.right * 2f); // 1�ʴ� (120, 0, 0)
        // �� �ӵ� ������ �� �� �� �� ���Ϳ� scalar�� �ϴ� �� �̿��� ����
        
        tr.position = tr.position + (UnityEngine.Vector3.right * 2f * UnityEngine.Time.deltaTime);
        // �� �� õõ�� ���� ��.
        // �ʴ� 60frame  = �ʴ� 60�� �׸�.

        // # deltaTime : �� ������ ó�� �� ���� ������ ó���ϴ� �ð� ( like,, thread.sleep() )
        // �� ������������ ���� 1[sec] / 60[frame] =>  0.01666 [sec/frame]
       
        // # deltaTime �����ִ� ����? -> cpu���� ����ӵ��� �ٸ���.(=> frame �׷��ִ� �ӵ��� �ٸ���. => ������ ���� ������ ��ǻ�� ���ɺ��� ���ӿ��� �̵� �ӵ�(������ �׷��ִ� �ð�) ���̰� ���� �ȴ�.)�ɸ��� �ð��� �ٸ����� ������ �׷��ִ� ����� ���� �������ִ� ����
    }

    // << vector >>
    // v( 2, 3 ) : ���� ~> (2, 3)�� ���ϴ� ����

    // # vector�� ���
    // : ��ġ�� �޶� ũ�Ⱑ ������ ���� �����̴�.

    // < vector ���� >
    //-> �� ���к��� ���ϰ� ���� �ȴ�.
    // �� Scalar�� ( + )( - ) x
    // # (+)
    // �� : va(1, 2) + vb(2, 1) = (3, 3) 

    // # (-) : �� ���Ͱ��� '����'
    // �� : va(1, 2) - vb(2, 2) = (-1, 0) -> vb���� va�� ���ϴ� ���� ���´�. (��ü������ '����'�� ���� �� ( - ) ����.)


    // # Scalar : ���Ͱ����� �ִ� ���Ͱ� �ƴ� �׳� ����
    // �� ( x ) , ( / ) ->���Ϳ� Scalar���� ���� ����. �� ���п� ( x ), ( / )�ϸ� ��
    // ������ �״�� ����, Scalar��ŭ ũ�� ����.

    // < Vector�� ���� >
    // �� ����( dot product ( dot() ), inner product) & ���� ( cross product ( cross() ), outer product)

    // # dot product  
    // �� �� ���Ͱ��� '����'
    // : va(2, 2) �� vb(1, 3) : ��Ŀ�� ���׶�̻��. �� ���к��� ���Ѵ��� ����
    // �� (ax x bx) + (ay x by)
    // va(2, 2) �� vb(1, 3) = 2 + 6 = 8
    // => �� ���͸� �����ϸ� Scalar�� ���´�. ( �� ���Ͱ��� '����')

    // # cross product
    // �� ���� ��� ��ü ���� �����ؼ� ���� ���Ͷ� �������Ͷ� ���� -> ��ü�� �������� ���� ���� => �������κ��� ���� �޴� ��
    // �������� ���� ����
    // �� 3���� ���������� ����
    // (x, y, z) ���Ͱ� ���´�.
    // ��  ���͵��� �̷�� ���� �������� �ϴ� ���� ����
    // ex) va(x, y, z) �� vb(x, y, z) : x ���׶�� ���
    /*
     * 23 - 32, 31 - 13, 12 - 21
     * 23 31 12
     * va(x, y, z) �� vb(x, y, z) = ay*bz - az*by , az*bx - ax*bz , ax*by - ay*bx
     */

    // # ������ ����ȭ(Normalization), # ���� ����(Normal vector)
    // �� 3���� �������� ��ü�� �����̴� ���
    // �� ���� 1 �̸鼭 ������ ������ �ִ� ����
    // �� ������ ��Į��(�ѱ���)�� ����
    // 

}
