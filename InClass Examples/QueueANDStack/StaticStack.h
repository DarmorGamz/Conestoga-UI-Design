#ifndef STATICSTACK_H_
#define STATICSTACK_H_

class StaticStack {

private:
	int* stackArray;
	int stackSize;
	int top;

public:
	StaticStack(int);
	void push(int);
	void pop(int&);
	bool isFull(void);
	bool isEmpty(void);
};

#endif