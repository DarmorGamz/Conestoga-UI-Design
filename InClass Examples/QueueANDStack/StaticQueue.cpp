#include "StaticQueue.h"
#include <iostream>

StaticQueue::StaticQueue(int s) {
	queueArray = new int[s];
	queueSize = s;
	front = -1;
	rear = -1;
	numItems = 0;
}

StaticQueue::~StaticQueue(void) {
	delete[] queueArray;
}

void StaticQueue::PrintQueueItem(int num) {
	std::cout << queueArray[num] << std::endl;
}

void StaticQueue::enqueue(int num) {
	if (isFull()) {
		std::cout << "The queue is full.\n";
	} else {
		// Calculate the new rear position
		rear = (rear + 1) % queueSize;
		// Insert new item
		queueArray[rear] = num;
		// Update item count
		numItems++;	
	}
}

int StaticQueue::dequeue(void) {
	// Retrieve the front item
	int num = queueArray[front+1];

	// Move front
	front = (front + 1) % queueSize;	

	// Update item count
	numItems--;	

	return num;
}

bool StaticQueue::isEmpty(void) { 
	if (numItems) {
		return false;
	} else {
		return true;
	}
}

bool StaticQueue::isFull(void) {
	if (numItems < queueSize) {
		return false;
	} else {
		return true;
	}
}

void StaticQueue::clear(void) { 
	front = -1;
	rear = -1;
	numItems = 0; 
}

