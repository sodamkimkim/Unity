#include <stdio.h>
#include <malloc.h>
#include <stdlib.h>
#include <time.h>

typedef struct _SNode
{
	int data;
	struct _SNode* pLeft;
	struct _SNode* pRight;
}SNode;

void Add(const SNode** const _pHead, const int const _data);
void PrintAll(const SNode* const _pHead);
void PrintRecursive(const SNode* const _pNode);
void DestroyAll(const SNode** const _pHead);
void DestroyRecursive(const SNode** const _pNode);

// ����0
int CountTotal(SNode* _pHead);
// ����1
int CountLeft(SNode* _pHead);
// ���� 2
int CountRight(SNode* _pHead);
// ���� 3
// Ʈ���� Ư�� ������ ����ϴ� �Լ�
/*
ex)
	 7  -lev1
4        9   -lev2
*/
int PrintLevel(SNode* _pHead, int _level);
int main()
{
	// �������� ���
	// random seed���� ���� �ٸ� ������ �߻��ȴ�.
	// �ð��� seed������ ���� �Ź� �ٸ� ���� ����� �� �ִ�.
	srand(time(NULL));
	// 0~10 ���� ���� ��� ������ ������ ������ �̿��ϸ� �ȴ�.
	// 150 ~160�̸� �� ������ ���ϱ� 150 ���ָ� �ǰ� �Լ��� ������ ���� �ȴ�.
	printf("%d\n", rand() % 10);

	SNode* pHead = NULL;
	for (int i = 0; i < 10; ++i)
		Add(&pHead, rand() % 100);


	PrintAll(pHead);
	DestroyAll(&pHead);
	return 0;
}
void Add(const SNode** const _pHead, const int const _data)
{
	if (_pHead == NULL)return;
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));
	pNewNode->data = _data;
	pNewNode->pLeft = NULL;
	pNewNode->pRight = NULL;
	if (*_pHead == NULL)
	{
		*_pHead = pNewNode;
		printf("Head(%d)\n", _data);
		return;
	}
	SNode* pCurNode = *_pHead;
	printf("(%d) - ", pNewNode->data);
	while (1)
	{
		if (pNewNode->data < pCurNode->data)
		{
			//�������� �̵�
			printf("L - ");
			if (pCurNode->pLeft == NULL)
			{
				printf("LE\n");
				pCurNode->pLeft = pNewNode;
				break;
			}
			else
			{
				pCurNode = pCurNode->pLeft;
				continue;
			}
		}
		else {
			//���������� �̵�
			printf("R - ");
			if (pCurNode->pRight == NULL)
			{
				printf("RE\n");
				pCurNode->pRight = pNewNode;
				break;
			}
			else {
				pCurNode = pCurNode->pRight;
				continue;
			}
		}
	}
}
void PrintAll(const SNode* const _pHead)
{
	if (_pHead == NULL)return;
	PrintRecursive(_pHead);
	printf("\n");
}
void PrintRecursive(const SNode* const _pNode)
{
	if (_pNode == NULL)return;
	PrintRecursive(_pNode->pLeft);
	printf("%d - ", _pNode->data);
	PrintRecursive(_pNode->pRight);

}
void DestroyAll(const SNode** const _pHead) {
	DestroyRecursive(_pHead);
}
void DestroyRecursive(const SNode** const _pNode)
{
	if ((*_pNode) == NULL)return;
	DestroyRecursive(&((*_pNode)->pLeft));
	DestroyRecursive(&((*_pNode)->pRight));

	if ((*_pNode) != NULL)
	{
		printf("Destroy(%d)\n", (*_pNode)->data);
		free((*_pNode));
		(*_pNode) = NULL;
	}
}