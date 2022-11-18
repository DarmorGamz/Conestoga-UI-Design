#ifndef DYNAMICSTACK_H_
#define DYNAMICSTACK_H_

class DynamicStack {

private:
	struct node {
		int dataItem;
		node* next;
	} *top;

public:
	void Push(int);
	int Pop(void);
	bool IsEmpty(void);

};

#endif