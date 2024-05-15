#include "pch.h"

class BaseList {
protected:
	int count;
	virtual BaseList* EmptyClone() = 0;
public:
	int Count() {
		return count;
	}
	virtual void Add(int number) = 0;
	virtual void Insert(int number, int index) = 0;
	virtual void Delete(int index) = 0;
	void Print() {
		for (int i = 0; i < count; i++) {
			std::cout << (*this)[i] << '\t';
		}
		std::cout << '\n';
	};
	virtual void Clear() = 0;
	virtual int& operator [](int i) = 0;

	void Assign(BaseList* source) {
		Clear();
		for (int i = 0; i < source->Count(); i++) {
			this->Add((*source)[i]);
		}
	}
	void AssignTo(BaseList* destination) {
		destination->Clear();
		for (int i = 0; i < this->Count(); i++) {
			destination->Add((*this)[i]);
		}
	}
	BaseList* Clone() {
		BaseList* baselist = EmptyClone();
		baselist->Assign(this);
		return baselist;
	}

	bool IsEqual(BaseList* other) {
		if (other->Count() != this->Count()) return false;
		else {
			for (int i = 0; i < this->Count(); i++) {
				if ((*other)[i] != (*this)[i]) return false;
			}
			return true;
		}
	}

	virtual void Sort() {
		int k, j;
		for (int i = 1; i < this->Count(); i++) {
			k = (*this)[i];
			j = i - 1;
			while (j >= 0 && (*this)[j] > k) {
				(*this)[j + 1] = (*this)[j];
				j--;
			}
			(*this)[j + 1] = k;
		}
	}
	//optional methods
	bool IsSorted() {
		for (int i = 1; i < Count(); i++) {
			if ((*this)[i] < (*this)[i - 1]) return false;
		}
		return true;
	}
};