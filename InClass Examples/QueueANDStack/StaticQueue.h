#ifndef STATICQUEUE_H_
#define STATICQUEUE_H_

class StaticQueue {

private:
	int* queueArray;
	int queueSize;
	int front;
	int rear;
	int numItems;

public:
	StaticQueue(int);
	~StaticQueue(void);
	void enqueue(int);
	int dequeue(void);
	bool isEmpty(void);
	bool isFull(void);
	void clear(void);
	void PrintQueueItem(int);
};

#endif