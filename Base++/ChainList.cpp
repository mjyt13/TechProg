#include "pch.h"
class ChainList : public BaseList {
private:
	class Node {
	public:
		int Data;
		Node* Next;

		Node(int data, Node* next) {
			Data = data;
			Next = next;
		}

	};
	Node* head;

	Node* find(int position) {
		if (position >= count || position < 0) {
			return nullptr;
		}
		int i = 0;
		Node* pointer = head;
		while (pointer != nullptr && i < position) {
			pointer = pointer->Next;
			i++;
		}
		if (i == position) {
			return pointer;
		}
		else {
			return nullptr;
		}
	}

	BaseList* EmptyClone() override {
		return new ChainList();
	}
public:

	ChainList() {
		head = nullptr;
		count = 0;
	}

	~ChainList() {
		Node* temp;
		while (head != nullptr) {
			temp = head;
			head = head->Next;
			delete temp;
		}
	}

	virtual void Add(int number) override {
		Node* node = new Node(number, nullptr);
		if (count == 0) {
			head = node;
		}
		else {
			find(count - 1)->Next = node;
		}
		count++;
	}

	void Insert(int number, int index) override {
		if (index<0 || index >count) {
			std::cout << "CHAIN CHLENIX" << '\t';
			std::cout << "count = " << count << " index = " << index << "\n";
		}
		else {
			/*if (index == count) {
				Add(number);
			}
			else*/ {
				Node* node = new Node(number, nullptr);
				node->Next = find(index);
				if (index == 0) {
					head = node;
				}
				else {
					find(index - 1)->Next = node;
				}
				count++;
			}
		}
	}

	void Delete(int index) override {
		if (index >= count || index < 0) { std::cout << "YA ROSTIIIIC " << '\n'; }
		else {
			if (index == 0) {
				Node* WRY = head;
				head = head->Next;
				delete WRY;
			}
			else {
				Node* preNode = find(index - 1);
				Node* WRY = find(index);
				preNode->Next = WRY->Next;
				delete WRY;
			}
			count--;
		}
	}

	/*void Print() override {
		for (int i = 0; i < count; i++) {
			std::cout << find(i)->Data << '\t';
		}
		std::cout << "GOVESHKA LEPESHKA" << '\n';
	}*/

	void Clear() override {
		Node* current = head;
		Node* next;
		while (current != nullptr) {
			next = current->Next;
			delete current;
			current = next;
		}
		head = nullptr;
		count = 0;
	}

	int& operator[](int i) override {
		static int mock = 0;
		if (i < 0 || i >= count)  return mock;
		else return find(i)->Data;
	}

	void Sort() override {
		Node* present;
		int temp;
		for (int i = 0; i < Count(); i++) {
			present = head;
			while (present != nullptr && present->Next != nullptr) {
				if (present->Data > (present->Next)->Data) {
					temp = present->Data;
					present->Data = (present->Next)->Data;
					(present->Next)->Data = temp;
				}
				present = present->Next;
			}
		}
	}
};