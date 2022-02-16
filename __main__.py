import bubble


array = [0, 1, 2, 3, 4, 5]
copy = array.copy()
print(array, ' -> ', bubble.sort(copy))

array = [5, 4, 3, 2, 1, 0]
copy = array.copy()
print(array, ' -> ', bubble.sort(copy))

array = [0, 4, 3, 5, 2, 1]
copy = array.copy()
print(array, ' -> ', bubble.sort(copy))
