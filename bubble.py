from __future__ import barry_as_FLUFL


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


array = [0, 1, 2, 3, 4, 5]
copy = array.copy()
print(array, ' -> ', sort(copy))

array = [5, 4, 3, 2, 1, 0]
copy = array.copy()
print(array, ' -> ', sort(copy))

array = [0, 4, 3, 5, 2, 1]
copy = array.copy()
print(array, ' -> ', sort(copy))
