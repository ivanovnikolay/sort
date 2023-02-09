using System.Diagnostics;


var argv = Environment.GetCommandLineArgs();
if (argv.Length < 2) {
    Console.WriteLine("Enter the array size as the first command line argument");
    Environment.Exit(1);
}

var N = int.Parse(argv[1]);
Console.WriteLine("Array size is {0}", N);

var random = new Random();
var array = new int[N];
for (var i = 0; i < array.Length; i++) {
    array[i] = random.Next();
}
var time = 0.0;

time = TimeIt(() => BubbleSort(array.ToArray()));
Console.WriteLine("Bubble sort time: {0}", time);

time = TimeIt(() => InsertionSort(array.ToArray()));
Console.WriteLine("Insertion sort time: {0}", time);

time = TimeIt(() => QuickSort(array.ToArray()));
Console.WriteLine("Quick sort time: {0}", time);

time = TimeIt(() => MergeSort(array.ToArray()));
Console.WriteLine("Merge sort time: {0}", time);

time = TimeIt(() => HeapSort(array.ToArray()));
Console.WriteLine("Heap sort time: {0}", time);

var proc = Process.GetCurrentProcess();
Console.WriteLine("Max memory usage: {0:0.0}", proc.PrivateMemorySize64 / (1024.0*1024));


int[] BubbleSort(int[] arr) {
    var N = arr.Length;
    var swapped = true;
    while (swapped) {
        N--;
        swapped = false;
        for (var i = 0; i < N; i++) {
            if (arr[i] > arr[i + 1]) {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                swapped = true;
            }
        }
    }
    return arr;
}


int[] HeapSort(int[] arr) {
    if (arr.Length <= 1) {
        return arr;
    }
    for (var i = arr.Length / 2 - 1; i >= 0; i--) {
        Heapify(arr, arr.Length, i);
    }
    for (var i = arr.Length - 1; i >= 0; i--) {
        var temp = arr[0];
        arr[0] = arr[i];
        arr[i] = temp;
        Heapify(arr, i, 0);
    }
    return arr;
}


void Heapify(int[] arr, int size, int index)
{
    var largest = index;
    var left = 2 * index + 1;
    var right = 2 * index + 2;
    if (left < size && arr[left] > arr[largest]) {
        largest = left;
    }
    if (right < size && arr[right] > arr[largest]) {
        largest = right;
    }
    if (largest != index) {
        var temp = arr[index];
        arr[index] = arr[largest];
        arr[largest] = temp;
        Heapify(arr, size, largest);
    }
}


int[] InsertionSort(int[] arr) {
    for (int i = 1; i < arr.Length; i++) {
        var key = arr[i];
        var flag = false;
        for (int j = i - 1; j >= 0 && !flag;) {
            if (key < arr[j]) {
                arr[j + 1] = arr[j];
                j--;
                arr[j + 1] = key;
            }
            else {
                flag = true;
            }
        }
    }
    return arr;
}


int[] MergeSort(int[] arr)
{
    int[] result = new int[arr.Length];
    if (arr.Length <= 1)
        return arr;

    int[] left;
    int[] right;
    int mid = arr.Length / 2;
    left = new int[mid];
    right = arr.Length % 2 == 0 ? new int[mid] : new int[mid + 1];
    for (int i = 0; i < mid; i++) {
        left[i] = arr[i];
    }
    for (int i = mid; i < arr.Length; i++) {
        right[i - mid] = arr[i];
    }
    left = MergeSort(left);
    right = MergeSort(right);
    result = Merge(left, right);
    return result;
}


int[] Merge(int[] left, int[] right)
{
    int[] result = new int[right.Length + left.Length];
    int indexLeft = 0, indexRight = 0, indexResult = 0;
    while (indexLeft < left.Length || indexRight < right.Length) {
        if (indexLeft < left.Length && indexRight < right.Length) {
            if (left[indexLeft] <= right[indexRight]) {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }
        else if (indexLeft < left.Length) {
            result[indexResult] = left[indexLeft];
            indexLeft++;
            indexResult++;
        }
        else if (indexRight < right.Length) {
            result[indexResult] = right[indexRight];
            indexRight++;
            indexResult++;
        }
    }
    return result;
}


int[] QuickSort(int[] arr) {
    return QuickSortArray(arr, 0, arr.Length - 1);
}


int[] QuickSortArray(int[] arr, int leftIndex, int rightIndex) {
    var i = leftIndex;
    var j = rightIndex;
    var pivot = arr[leftIndex];
    while (i <= j) {
        while (arr[i] < pivot) {
            i++;
        }
        while (arr[j] > pivot) {
            j--;
        }
        if (i <= j) {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
            i++;
            j--;
        }
    }
    if (leftIndex < j)
        QuickSortArray(arr, leftIndex, j);
    if (i < rightIndex)
        QuickSortArray(arr, i, rightIndex);
    return arr;
}


double TimeIt(Action func) {
    var stopwatch = Stopwatch.StartNew();
    func();
    stopwatch.Stop();
    return stopwatch.ElapsedTicks / 1000000000.0;
}


void TestSorts() {
    int[] array = new int []{0, 4, 3, 5, 2, 1};
    Console.WriteLine("Bubble sort: {0}", ArrayToStr(BubbleSort(array.ToArray())));

    array = new int []{0, 4, 3, 5, 2, 1};
    Console.WriteLine("Heap sort: {0}", ArrayToStr(HeapSort(array.ToArray())));

    array = new int []{0, 4, 3, 5, 2, 1};
    Console.WriteLine("Insertion sort: {0}", ArrayToStr(InsertionSort(array.ToArray())));

    array = new int []{0, 4, 3, 5, 2, 1};
    Console.WriteLine("Merge sort: {0}", ArrayToStr(MergeSort(array.ToArray())));

    array = new int []{0, 4, 3, 5, 2, 1};
    Console.WriteLine("Quick sort: {0}", ArrayToStr(QuickSort(array.ToArray())));
}


string ArrayToStr(int[] a) {
    return string.Join(", ", a);
}
