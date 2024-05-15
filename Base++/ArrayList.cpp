#include "pch.h"

class ArrayList : public BaseList {
private:
	int* buffer;
	int buffer_length;
	BaseList* EmptyClone() override {
		return new ArrayList();
	}
	void Expand() {
		if (count == buffer_length) {
			if (buffer_length == 0) {
				buffer = new int[1];
				buffer_length = 1;
			}
			else {
				buffer_length = buffer_length * 2;
				int* temp_buffer = new int[buffer_length];
				for (int i = 0; i < count; i++) {
					temp_buffer[i] = buffer[i];
				}
				delete[] buffer;
				buffer = temp_buffer;
			}
		}
	}
public:
	ArrayList() {
		buffer = nullptr;
		buffer_length = 0;
		count = 0;
	}

	~ArrayList() {
		delete[] buffer;
	}

	void Add(int number) override {
		Expand();
		buffer[count] = number;
		count++;
	}

	void Insert(int number, int index) override {
		if (index<0 || index>count) {
			std::cout << "ARRAY CHLENIX" << '\t';
			std::cout << "count = " << count << " index = " << index << '\n';
		}
		else {
			Expand();
			for (int i = count; i > index; i--) {
				buffer[i] = buffer[i - 1];
			}
			buffer[index] = number;
			count++;
		}
	}

	void Delete(int index) override {
		if (index < 0 || index >= count) { std::cout << "NAM PIZDA" << '\n'; }
		else {
			if (count == 1) {
				Clear();
			}
			else {
				for (int i = index; i < count - 1; i++) { buffer[i] = buffer[i + 1]; }
				buffer[count - 1] = 0;
				count--;
			}
		}
	}

	/*void Print() override {
		for (int i = 0; i < Count(); i++) {
			std::cout << buffer[i] << "\t";
		}
		std::cout << "\n";
	}*/

	void Clear() override {
		delete[] buffer;
		count = 0;
		buffer_length = 0;
		buffer = nullptr;
	}

	int& operator[](int i) override {
		static int mock = 0;
		if (i < 0 || i >= count) return mock;
		else return buffer[i];
	}
};