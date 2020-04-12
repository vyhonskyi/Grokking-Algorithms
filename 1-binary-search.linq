<Query Kind="Program" />

void Main()
{
	var list = new int[10];
	var rand = new Random();

	for (var i = 0; i < list.Length; i++)
	{
		list[i] = rand.Next(10);
	}

	Array.Sort(list);

	var searchedNumber = rand.Next(10);
	var resultNumber = BinarySearch(list, searchedNumber);

	searchedNumber.Dump("Seach number");
	list.Dump("List");
	resultNumber.Dump("Index of seach number");
}

int? BinarySearch(int[] list, int item)
{
	var low = 0;
	var high = list.Length - 1;
	while (low <= high)
	{
		var mid = (low + high) / 2;
		var guess = list[mid];

		if (guess == item)
		{
			return mid;
		}

		if (guess > item)
		{
			high = mid - 1;
		}
		else
		{
			low = mid + 1;
		}
	}

	return null;
}

// Define other methods and classes here
