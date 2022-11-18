#ifndef DYNAMICQUEUE_H_
#define DYNAMICQUEUE_H_

class DynamicQueue {

private:
	struct QueueNode {
		int value;
		QueueNode* next;
	};

	QueueNode* front;
	QueueNode* rear;
	int numItems;

public:
	DynamicQueue(void);
	~DynamicQueue(void);
	void enqueue(int);
	int dequeue(void);
	bool isEmpty(void);
	void makeNull(void);
};

#endif