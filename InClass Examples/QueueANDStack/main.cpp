#include <iostream>
#include "StaticQueue.h"
#include "DynamicQueue.h"
#include "StaticStack.h"
#include "DynamicStack.h"

using namespace std;

int main(void) {
	StaticQueue Queue(5);
	cout << "Enqueuing 5 items...\n";

	// Enqueue 5 items.
	for (int x = 0; x < 5; x++) {
		Queue.enqueue(x);
	}

	// Deqeue and retrieve all items in the queue
	cout << "The values in the queue were:\n";
	while (!Queue.isEmpty()) {
		int value;
		value = Queue.dequeue();
		cout << value << endl;
	}

	DynamicQueue Queue2;
	cout << "Enqueuing 6 items...\n";

	// Enqueue 6 items form console.
	for (int x = 10; x < 16; x++) {
		Queue2.enqueue(x);
	}
	// Deqeue and retrieve all items in the queue
	cout << "The values in the queue were:\n";

	while (!Queue2.isEmpty()) {
		int value;
		value = Queue2.dequeue();
		cout << value << endl;
	}

	StaticStack stack(5);
	int num;
	cout << "Pushing 5\n";
	stack.push(5);
	cout << "Pushing 10\n";
	stack.push(10);
	cout << "Pushing 15\n";
	stack.push(15);
	cout << "Pushing 20\n";
	stack.push(20);
	cout << "Pushing 25\n";
	stack.push(25);
	cout << "Popping...\n";
	stack.pop(num);
	cout << num << endl;
	stack.pop(num);
	cout << num << endl;
	stack.pop(num);
	cout << num << endl;
	stack.pop(num);
	cout << num << endl;
	stack.pop(num);
	cout << num << endl;

	DynamicStack stack2;
	int catchVar;
	cout << "Pushing 5\n";
	stack2.Push(5);
	cout << "Pushing 10\n";
	stack2.Push(10);
	cout << "Pushing 15\n";
	stack2.Push(15);
	cout << "Popping...\n";
	catchVar = stack2.Pop();
	cout << catchVar << endl;
	catchVar = stack2.Pop();
	cout << catchVar << endl;
	catchVar = stack2.Pop();
	cout << catchVar << endl;
	cout << "\nPopping again... ";
	catchVar = stack2.Pop();

	return 0;
}
