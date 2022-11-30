#include <stdio.h>
#include <malloc.h>
typedef struct _SNode
{
	int data;
	struct _SNode* pNext;
} SNode;

// SLL�� �������� ������ ����
void Add(SNode** _pHead, int _data);

//���� 1. ���ϴ� �ε����� ������ ����
void Insert(SNode** _pHead, const int const _idx, const int const _data);
// ���� 2.���ϴ� �ε����� �����͸� ����
void RemoveAt(SNode** _pHead, int _idx);
// ���� 3. ���̱��ϴ��Լ�
int Count(SNode* _pHead);

void PrintAll(const SNode* const _pHead);
void DestroyAll(SNode** _pHead);

int main()
{
	SNode* pHead = NULL;
	Add(&pHead, 1);
	Add(&pHead, 2);
	Add(&pHead, 3);
	Add(&pHead, 77);
	Add(&pHead, 3);
	PrintAll(pHead);
	printf("SLL Count : %d,\n", Count(pHead));
	Insert(&pHead, 0, 0000);
	Insert(&pHead, 1, 1111);
	Insert(&pHead, 2, 2222);
	Insert(&pHead, 3, 3333);

	//DestroyAll(&pHead);
	//PrintAll("%p\n",pHead);
	return 0;
}

void Add(SNode** _pHead, int _data)
{
	if (_pHead == NULL) return;
	SNode* pNewNode = (SNode*)malloc(sizeof(SNode));
	pNewNode->data = _data;
	pNewNode->pNext = NULL;

	if (*_pHead == NULL)
	{
		*_pHead = pNewNode;
		return;
	}
	else
	{
		SNode* pCurNode = *_pHead;
		while (pCurNode->pNext != NULL)
		{
			pCurNode = pCurNode->pNext;
		}
		pCurNode->pNext = pNewNode;
	}
}

void Insert(SNode** _pHead, const int const _idx, const int const _data)
{
	// ���ϴ� �ε���(����)�� ��� �����ϴ� �Լ�
	// idx��ŭ ��� �ǳʶپ ��������
	int idx = 0;
	SNode* pTemp = *_pHead;
	if (_pHead == NULL) return;
	if (*_pHead == NULL)
	{
		idx = 0;
		printf("_pHead is empty");
		// *_pHead�� ������� ���⼭���� ������ 0�ְ� idx��ŭ next�ؼ� ������ ������ ��
		// _idx == 0�� ���� �ƴѰ�� ������ 
		if (_idx == 0)
		{
			pTemp->data = _data;
		}
		else {
			for (int i = 0; i < idx; i++)
			{
				pTemp->data = 0;
				pTemp = pTemp->pNext;
				pTemp = _data;
				pTemp->pNext = NULL;
			}
		}


	}
	else {

	}




}
int Count(SNode* _pHead)
{
	int cnt = 0;
	if (_pHead == NULL)
	{
		printf("_pHead is empty!\n");
		cnt = 0;
	}
	else
	{
		SNode* pTemp = _pHead;
		while (pTemp != NULL)
		{
			++cnt;
			pTemp = pTemp->pNext;
		}
	}
	//printf("SLL cnt: %d\n", cnt);
	return cnt;
}
void PrintAll(SNode* _pHead)
{
	if (_pHead == NULL)
	{
		printf("_pHead is empty!\n");
		return;
	}
	SNode* pCurNode = _pHead;
	int cnt = 0;
	while (pCurNode != NULL)
	{
		printf("%d - ", pCurNode->data);
		pCurNode = pCurNode->pNext;
		++cnt;
	}
	printf("(%d)\n", cnt);
}

void DestroyAll(SNode** _pHead)
{
	SNode* pCurNode = *_pHead;
	while (pCurNode != NULL)
	{
		SNode* pDestroyNode = pCurNode;
		pCurNode = pCurNode->pNext;
		printf("DestroyNode: %d (%p)\n", pDestroyNode->data, pDestroyNode);
		if (pDestroyNode != NULL)
		{
			free(pDestroyNode);
			pDestroyNode = NULL;
		}
	}

	*_pHead = NULL;
}
