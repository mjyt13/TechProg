#include <cstdlib>
#include <iostream>
#include <ctime>
#include "ChainList.cpp"

int main()
{
	srand(time(nullptr));

	BaseList* ArList = new ArrayList();
	BaseList* ChList = new ChainList();
	
	int operation, j, position;
	
	for (int i = 0; i < 24000; i++) {
		operation = rand() % 5;
		position = rand() % 1500;
		j = rand() % 5300000;
		switch (operation)
		{
		case 0:
			ArList->Add(j);
			ChList->Add(j);
			break;
		case 1:
			ArList->Delete(position);
			ChList->Delete(position);
			break;
		case 2:
			ArList->Insert(j, position);
			ChList->Insert(j, position);
			break;
		case 3:
			(*ArList)[position] = j;
			(*ChList)[position] = j;
			break;
		case 4:
			std::cout << (*ArList)[position] << '\n';
			std::cout << (*ChList)[position] << '\n';
			break;
		}
	}

	ArList->Print();
	ChList->Print();

	std::cout << " kolvo v array " << ArList->Count()<<'\n';
	std::cout << " kolvo v chain " << ChList->Count()<<'\n';

	if (ArList->IsEqual(ChList)) std::cout << " lists are equal \n ";
	else std::cout << " lists are NOT equal \n ";

	ArList->Sort();
	ChList->Sort();

	ArList->Print();
	ChList->Print();

	if (ArList->IsSorted()) std::cout << " array is sorted \n ";
	else std::cout << " array is NOT sorted \n ";
	if(ChList->IsSorted()) std::cout << " chain is sorted \n ";
	else std::cout << " chain is NOT sorted \n ";
}
