#include "DynamicQueue.h"
#include <iostream>

DynamicQueue::DynamicQueue(void) {
	front = NULL;
	rear = NULL;
	numItems = 0;
}

DynamicQueue::~DynamicQueue(void) {
	makeNull();
}

void DynamicQueue::enqueue(int num) {
	QueueNode* newNode;

	newNode = new QueueNode;
	newNode->value = num;
	newNode->next = NULL;
	if (isEmpty()) {
		front = newNode;
		rear = newNode;
	} else {
		rear->next = newNode;
		rear = newNode;
	}
	numItems++;
}

int DynamicQueue::dequeue(void) {
	QueueNode* temp;

	int num;
	num = front->value;
	temp = front->next;
	delete front;
	front = temp;
	numItems--;

	return num;
 }

bool DynamicQueue::isEmpty(void) {
	if (numItems) {
		return false; 
	} else {
		return true;
	}
}

void DynamicQueue::makeNull(void) {
	while (!isEmpty()) {
		dequeue();
	}
}