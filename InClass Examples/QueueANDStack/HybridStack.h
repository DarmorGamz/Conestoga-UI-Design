#ifndef HYBRIDSTACK_H_
#define HYBRIDSTACK_H_

class HybridStack {
	struct node {
		int array[4];
		int arraySize = 4;
		int arrayTop;
		node* next;
	}*top;

public:
	HybridStack(void);
	~HybridStack(void);
	void Push(int);
	int Pop(void);
	bool isEmpty(void);
};
#endif