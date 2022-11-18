#include "StaticStack.h"
#include <iostream>

StaticStack::StaticStack(int Size) {
	stackArray = new int(Size);
	stackSize = Size;
	top - 1;
}

void StaticStack::push(int num) {
	top++;
	stackArray[top] = num;
}

void StaticStack::pop(int& num) {
	num = stackArray[top];
	top--;
}

bool StaticStack::isFull(void) {
	bool status;
	if (top == stackSize - 1) {
		status = true;
	} else {
		status = false;
	}

	return status;
}

bool StaticStack::isEmpty(void) {
	bool status;
	if (top == - 1) {
		status = true;
	} else {
		status = false;
	}

	return status;
}
