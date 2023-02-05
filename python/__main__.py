from timeit import timeit
import random
import bubble, insertion, quick, merge, heap


def test1(sort):
    array = [0, 1, 2, 3, 4, 5]
    copy = array.copy()
    print(array, ' -> ', sort(copy))

    array = [5, 4, 3, 2, 1, 0]
    copy = array.copy()
    print(array, ' -> ', sort(copy))

    array = [0, 4, 3, 5, 2, 1]
    copy = array.copy()
    print(array, ' -> ', sort(copy))


def test2(N, sort):
    a = random.sample(range(0, N), N)
    print(timeit(lambda: sort(a), number=5))


#test1(heap.sort)
test2(1_0_000, quick.sort)