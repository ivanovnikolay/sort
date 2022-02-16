def sort(array):
    N = len(array)
    while True:
        swapped = False
        for i in range(N - 1):
            if array[i] > array[i + 1]:
                array[i], array[i + 1], swapped = array[i + 1], array[i], True
        if not swapped:
            break
        N -= 1
    return array
