<Query Kind="Program" />

void Main()
{
	var list = new int[10];
	var rand = new Random();

	for (var i = 0; i < list.Length; i++)
	{
		list[i] = rand.Next(list.Length);
	}

	list.Dump("List");

	var sortedList = QuickSort(list);
	sortedList.Dump("Sorted list");
}

int[] QuickSort(int[] arr)
{
	if (arr.Length < 2)
	{
		return arr;
	}

	var lesserList = new List<int>();
	var greatherList = new List<int>();
	var bearingList = new List<int>();
	var bearing = arr[new Random().Next(arr.Length)];

	foreach (var item in arr)
	{
		if (item == bearing)
		{
			bearingList.Add(item);
		}

		if (item < bearing)
		{
			lesserList.Add(item);
		}

		if (item > bearing)
		{
			greatherList.Add(item);
		}
	}

	var lesserArrSorted = QuickSort(lesserList.ToArray());
	var greathedArrSorted = QuickSort(greatherList.ToArray());

	return lesserArrSorted.Concat(bearingList).Concat(greathedArrSorted).ToArray();
}