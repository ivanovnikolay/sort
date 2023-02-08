import sys
import random
import resource
import bubble, insertion, quick, merge, heap
from timeit import timeit

if len(sys.argv) < 2:
    print('Enter the array size as the first command line argument')
    sys.exit(1)

N = int(sys.argv[1])
print('Array size is %s' % N)
array = random.sample(range(0, N), N)


def print_test(sort):
    array = [0, 1, 2, 3, 4, 5]
    copy = array.copy()
    print(array, ' -> ', sort(copy))

    array = [5, 4, 3, 2, 1, 0]
    copy = array.copy()
    print(array, ' -> ', sort(copy))

    array = [0, 4, 3, 5, 2, 1]
    copy = array.copy()
    print(array, ' -> ', sort(copy))


time = timeit(lambda: bubble.sort(array.copy()), number=1)
print('Bubble sort time: %.10f' % time)

time = timeit(lambda: insertion.sort(array.copy()), number=1)
print('Insertion sort time: %.10f' % time)

time = timeit(lambda: quick.sort(array.copy()), number=1)
print('Quick sort time: %.10f' % time)

time = timeit(lambda: merge.sort(array.copy()), number=1)
print('Merge sort time: %.10f' % time)

time = timeit(lambda: heap.sort(array.copy()), number=1)
print('Heap sort time: %.10f' % time)

rusage = resource.getrusage(resource.RUSAGE_SELF)
max_memory = rusage.ru_maxrss
print('Max memory usage: %.1f Mb' % (max_memory / (1024*1024)))
