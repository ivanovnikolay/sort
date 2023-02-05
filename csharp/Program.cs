
Console.WriteLine("Bubble sort:");
int[] array = {0, 4, 3, 5, 2, 1};
Console.WriteLine("[{0}]", string.Join(", ", BubbleSort(array)));


int [] BubbleSort(int[] a) {
    var N = a.Length;
    var swapped = true;
    while (swapped) {
        N--;
        swapped = false;
        for (var i = 0; i < N; i++) {
            if (a[i] > a[i + 1]) {
                var temp = a[i];
                a[i] = a[i + 1];
                a[i + 1] = temp;
                swapped = true;
            }
        }
    }
    return a;
}
