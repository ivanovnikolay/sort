#include <iostream>
#include <time.h>


void PrintArray(int arr[], int N);
int* CopyArray(int arr[], int N);
void BubbleSort(int arr[], int N);
void HeapSort(int arr[], int N);
void InsertionSort(int arr[], int N);
void MergeSort(int arr[], int l, int r);
void QuickSort(int arr[], int N);
double TimeIt(double start);


int main(int argc, char *argv[]) {
    if (argc < 2) {
        std::cout << "Enter the array size as the first command line argument" << std::endl;
        return 1;
    }
    int N = atoi(argv[1]);
    std::cout << "Array size is " << N << std::endl;
    int* array = new int[N];
    for (int i = 0; i < N; i++) {
        array[i] = rand();
    }
    //PrintArray(array, N);

    int* copy = NULL;
    double start = 0.0;

    copy = CopyArray(array, N);
    start = clock();
    BubbleSort(copy, N);
    std::cout << "Bubble sort time: " << TimeIt(start) << std::endl;
    //PrintArray(copy, N);
    delete[] copy;

    copy = CopyArray(array, N);
    start = clock();
    HeapSort(copy, N);
    std::cout << "Heap sort time: " << TimeIt(start) << std::endl;
    //PrintArray(copy, N);
    delete[] copy;

    copy = CopyArray(array, N);
    start = clock();
    InsertionSort(copy, N);
    std::cout << "Insertion sort time: " << TimeIt(start) << std::endl;
    //PrintArray(copy, N);
    delete[] copy;

    copy = CopyArray(array, N);
    start = clock();
    MergeSort(copy, 0, N - 1);
    std::cout << "Merge sort time: " << TimeIt(start) << std::endl;
    //PrintArray(copy, N);
    delete[] copy;

    copy = CopyArray(array, N);
    start = clock();
    QuickSort(copy, N);
    std::cout << "Quick sort time: " << TimeIt(start) << std::endl;
    //PrintArray(copy, N);
    delete[] copy;

    delete[] array;
    return 0;
}


void PrintArray(int arr[], int N) {
    std::cout << "[";
    for (int i = 0; i < N; i++) {
        std::cout << arr[i];
        if (i != N - 1) {
            std::cout << " ";
        }
    }
    std::cout << "]" << std::endl;
}


int* CopyArray(int arr[], int N) {
    int* copy = new int[N];
    for (int i = 0; i < N; i++) {
        copy[i] = arr[i];
    }
    return copy;
}


void BubbleSort(int arr[], int N) {
    bool swapped = true;
    while (swapped) {
        N--;
        swapped = false;
        for (int i = 0; i < N; i++) {
            if (arr[i] > arr[i + 1]) {
                int temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
                swapped = true;
            }
        }
    }
}


void Heapify(int arr[], int size, int index)
{
    int largest = index;
    int left = 2 * index + 1;
    int right = 2 * index + 2;
    if (left < size && arr[left] > arr[largest]) {
        largest = left;
    }
    if (right < size && arr[right] > arr[largest]) {
        largest = right;
    }
    if (largest != index) {
        int temp = arr[index];
        arr[index] = arr[largest];
        arr[largest] = temp;
        Heapify(arr, size, largest);
    }
}


void HeapSort(int arr[], int N) {
    if (N <= 1) {
        return;
    }
    for (int i = N / 2 - 1; i >= 0; i--) {
        Heapify(arr, N, i);
    }
    for (int i = N - 1; i >= 0; i--) {
        int temp = arr[0];
        arr[0] = arr[i];
        arr[i] = temp;
        Heapify(arr, i, 0);
    }
}


void InsertionSort(int arr[], int N) {
    for (int i = 1; i < N; i++) {
        int key = arr[i];
        bool flag = false;
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
}


void Merge(int arr[], int p, int q, int r) {
    int n1 = q - p + 1;
    int n2 = r - q;
    int L[n1], M[n2];
    for (int i = 0; i < n1; i++)
        L[i] = arr[p + i];
    for (int j = 0; j < n2; j++)
        M[j] = arr[q + 1 + j];

    int i = 0, j = 0, k = p;
    while (i < n1 && j < n2) {
        if (L[i] <= M[j]) {
            arr[k] = L[i];
            i++;
        }
        else {
            arr[k] = M[j];
            j++;
        }
        k++;
    }

    while (i < n1) {
        arr[k] = L[i];
        i++;
        k++;
    }
    while (j < n2) {
        arr[k] = M[j];
        j++;
        k++;
    }
}


void MergeSort(int arr[], int l, int r)
{
    if (l < r)
    {
        int m = l + (r - l) / 2;
        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);
        Merge(arr, l, m, r);
    }
}


void QuickSortArray(int arr[], int leftIndex, int rightIndex) {
    int i = leftIndex;
    int j = rightIndex;
    int pivot = arr[leftIndex];
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
}


void QuickSort(int arr[], int N) {
    return QuickSortArray(arr, 0, N - 1);
}


double TimeIt(double start) {
    double end = clock();
    return (end - start)/CLOCKS_PER_SEC;
}
