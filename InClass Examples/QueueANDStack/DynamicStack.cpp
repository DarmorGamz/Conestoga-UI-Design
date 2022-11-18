#include "DynamicStack.h"
#include <iostream>

void DynamicStack::Push(int iNewElement) {
	node* newptr = new node;
	newptr->dataItem = iNewElement;
	newptr->next = top;
	top = newptr;
}

int DynamicStack::Pop(void) {
	// Check if nothing in stack.
	if(IsEmpty()) return false;

	node* tempptr = top;
	int returnValue = top->dataItem;
	top = top->next;
	delete tempptr;
	
	// Set Response.
	return returnValue;
}

bool DynamicStack::IsEmpty() {
	if(top == NULL) return true;
	else return false;
}