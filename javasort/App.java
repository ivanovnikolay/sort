package javasort;
import java.util.Arrays;
import java.util.Random;


public class App {
    interface Sort {
        void sort();
    }


    public static void main(String[] args) {
        if (args.length < 1) {
            System.out.println("Enter the array size as the first command line argument");
            System.exit(1);
        }

        var N = Integer.parseInt(args[0]);
        System.out.println("Array size is " + N);
        
        var random = new Random();
        var array = new int[N];
        for (var i = 0; i < array.length; i++) {
            array[i] = random.nextInt();
        }
        double time = 0;
        
        time = TimeIt(() -> BubbleSort(array.clone()));
        System.out.println("Bubble sort time: " + time);
        
        time = TimeIt(() -> InsertionSort(array.clone()));
        System.out.println("Insertion sort time: " + time);
        
        time = TimeIt(() -> QuickSort(array.clone()));
        System.out.println("Quick sort time: " + time);
        
        time = TimeIt(() -> MergeSort(array.clone()));
        System.out.println("Merge sort time: " + time);
        
        time = TimeIt(() -> HeapSort(array.clone()));
        System.out.println("Heap sort time: " + time);
    }


    static int[] BubbleSort(int[] arr) {
        var N = arr.length;
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


    static int[] HeapSort(int[] arr) {
        if (arr.length <= 1) {
            return arr;
        }
        for (var i = arr.length / 2 - 1; i >= 0; i--) {
            Heapify(arr, arr.length, i);
        }
        for (var i = arr.length - 1; i >= 0; i--) {
            var temp = arr[0];
            arr[0] = arr[i];
            arr[i] = temp;
            Heapify(arr, i, 0);
        }
        return arr;
    }


    static void Heapify(int[] arr, int size, int index)
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


    static int[] InsertionSort(int[] arr) {
        for (int i = 1; i < arr.length; i++) {
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


    static int[] MergeSort(int[] arr)
    {
        int[] result = new int[arr.length];
        if (arr.length <= 1)
            return arr;
    
        int[] left;
        int[] right;
        int mid = arr.length / 2;
        left = new int[mid];
        right = arr.length % 2 == 0 ? new int[mid] : new int[mid + 1];
        for (int i = 0; i < mid; i++) {
            left[i] = arr[i];
        }
        for (int i = mid; i < arr.length; i++) {
            right[i - mid] = arr[i];
        }
        left = MergeSort(left);
        right = MergeSort(right);
        result = Merge(left, right);
        return result;
    }


    static int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[right.length + left.length];
        int indexLeft = 0, indexRight = 0, indexResult = 0;
        while (indexLeft < left.length || indexRight < right.length) {
            if (indexLeft < left.length && indexRight < right.length) {
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
            else if (indexLeft < left.length) {
                result[indexResult] = left[indexLeft];
                indexLeft++;
                indexResult++;
            }
            else if (indexRight < right.length) {
                result[indexResult] = right[indexRight];
                indexRight++;
                indexResult++;
            }
        }
        return result;
    }


    static int[] QuickSort(int[] arr) {
        return QuickSortArray(arr, 0, arr.length - 1);
    }


    static int[] QuickSortArray(int[] arr, int leftIndex, int rightIndex) {
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


    static double TimeIt(Sort func) {
        var start = System.nanoTime();
        func.sort();
        var end = System.nanoTime();
        return (end - start) / 1000000000d;
    }


    static void TestSorts() {
        int[] array = new int []{0, 4, 3, 5, 2, 1};

        System.out.println("Bubble sort: " + Arrays.toString(BubbleSort(array.clone())));
    
        array = new int []{0, 4, 3, 5, 2, 1};
        System.out.println("Heap sort: " + Arrays.toString(HeapSort(array.clone())));
    
        array = new int []{0, 4, 3, 5, 2, 1};
        System.out.println("Insertion sort: " + Arrays.toString(InsertionSort(array.clone())));
    
        array = new int []{0, 4, 3, 5, 2, 1};
        System.out.println("Merge sort: " + Arrays.toString(MergeSort(array.clone())));
    
        array = new int []{0, 4, 3, 5, 2, 1};
        System.out.println("Quick sort: " + Arrays.toString(QuickSort(array.clone())));
    }
}
